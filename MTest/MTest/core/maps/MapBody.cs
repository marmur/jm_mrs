using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public class MapVault
    {
        public MapHolder mapHolder;
        int[,] dirtyState;
        int mapSize;
        int mapDirtyCount;



        public void markDirty(int x, int y)
        {
            if (dirtyState[x, y] == 0)
            {
                dirtyState[x, y] = 1;
                mapDirtyCount++;
            }
        }


        public MapVault(MapHolder newMap)
        {
            mapSize = newMap.SizeX * newMap.SizeY;
            mapDirtyCount = 0;
            dirtyState = MapBody.prepareArray(newMap.SizeX, newMap.SizeY, 0);
            mapHolder = newMap;
        }

        public double getDirtyProcentage()
        {
            return ((double)mapDirtyCount / (double)mapSize);
        }
    }

    public class MapBody: IMap
    {

        #region This should be done in configuration
        double oldValueWeight = 0.2;
        double minDirtyRateBeforeUpdate = 0.4;
        #endregion


        Queue<MapHolder> updateQueue;
        IMap parent;

        MapVault currentMap;



        public void setParent(IMap parent)
        {
            this.parent = parent;
        }






        public static int[,] prepareArray(int sizeX, int sizeY, int val)
        {
            int[,] map = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    map[i, j] = val;
                }
            }

            return map;
        }


        public void initializeMap(int sizeX, int sizeY)
        {
            int[,] map = prepareArray(sizeX, sizeY, Map.UNKNOWN_MAP_STATE);
            currentMap = new MapVault(new MapHolder( map, 0, 0));
        }


        public MapBody()
        {
            updateQueue = new Queue<MapHolder>();
            parent = null;

        }

        public MapHolder getCurentMapView()
        {
            if (currentMap == null)
            {
                return null;
            }
            else
            {
                return new MapHolder(currentMap.mapHolder);
            }
        }
        

        public MapHolder requestMapView(int topX, int topY, int sizeX, int sizeY)
        {
            //TODO: Throw exception
            if (topX < 0 || topY < 0 || sizeX < 0 || sizeY < 0)
            {
                throw new Exception("Values cannot be < 0");
            }

            if (currentMap != null && topX >= currentMap.mapHolder.X && topY >= currentMap.mapHolder.Y
                  && (topX + sizeX) <= (currentMap.mapHolder.X + currentMap.mapHolder.SizeX)
                  && (topY + sizeY) <= (currentMap.mapHolder.Y + currentMap.mapHolder.SizeY))
            {
                //This is part of current map
                int[,] map = new int[sizeX, sizeY];
                int dispX = topX - currentMap.mapHolder.X;
                int dispY = topY - currentMap.mapHolder.Y;

                for (int i = 0; i<sizeX; i++){
                    for (int j = 0; j<sizeY; j++){
                        map[i,j] = currentMap.mapHolder.Map[i+dispX,j+dispY];
                    }
                }

                return new MapHolder(map,topX,topY);
            }
            else
            {
                if (parent != null)
                {
                    if (currentMap != null)
                    {
                        parent.pushMapUpdate(currentMap.mapHolder);
                    }
                    currentMap = new MapVault(parent.requestMapView(topX, topY, sizeX, sizeY));
                    return new MapHolder(currentMap.mapHolder);
                }
                else
                {
                    throw new Exception("No such map");
                }
            }
        }

        public void pushMapUpdate(MapHolder update)
        {
            updateQueue.Enqueue(update);
        }

        public bool isMapFullyUpdated()
        {
            return (updateQueue.Count == 0);
        }

        public void retieveOneEmenentFormQueueAndUpdateMap()
        {
            if (updateQueue.Count > 0)
            {
                MapHolder singleUpdate = updateQueue.Dequeue();
                if (singleUpdate == null) return;

                Boolean updateParent = false;
                if (currentMap == null)
                {
                    if (parent == null)
                    {
                        throw new Exception("Map is not initialized and no parent map was specified");
                    }
                    else
                    {
                        //If map is not initialized, update parrent
                        updateParent = true;
                    }
                }
                else
                {                
                    //Find position of SingleUpdate map in CurrentMap
                    int baseX = singleUpdate.X - currentMap.mapHolder.X;
                    int baseY = singleUpdate.Y - currentMap.mapHolder.Y;

                    //Set iteration values
                    int xStart, xStop, yStart, yStop;
                    if (baseX < 0)
                    {
                        xStart = 0;
                        updateParent = true;
                    }
                    else
                    {
                        xStart = baseX;
                    }

                    if ((baseX + singleUpdate.SizeX) > currentMap.mapHolder.SizeX)
                    {
                        xStop = currentMap.mapHolder.SizeX;
                        updateParent = true;
                    }
                    else
                    {
                        xStop = baseX + singleUpdate.SizeX;
                    }

                    if (baseY < 0)
                    {
                        yStart = 0;
                        updateParent = true;
                    }
                    else
                    {
                        yStart = baseY;
                    }

                    if ((baseY + singleUpdate.SizeY) > currentMap.mapHolder.SizeY)
                    {
                        yStop = currentMap.mapHolder.SizeY;
                        updateParent = true;
                    }
                    else
                    {
                        yStop = baseY + singleUpdate.SizeY;
                    }


                    for (int i = xStart; i < xStop; i++)
                    {
                        for (int j = yStart; j < yStop; j++)
                        {
                            int newMapX = i + currentMap.mapHolder.X - singleUpdate.X;
                            int newMaxY = j + currentMap.mapHolder.Y - singleUpdate.Y;

                            if (singleUpdate.Map[newMapX, newMaxY] != Map.UNKNOWN_MAP_STATE)
                            {
                                if (currentMap.mapHolder.Map[i, j] == Map.UNKNOWN_MAP_STATE)
                                {
                                    currentMap.mapHolder.Map[i, j] = singleUpdate.Map[newMapX, newMaxY];
                                }
                                else
                                {
                                    currentMap.mapHolder.Map[i, j] = (int)(oldValueWeight * currentMap.mapHolder.Map[i, j] + (1 - oldValueWeight) * singleUpdate.Map[newMapX, newMaxY]);
                                }


                                if (!updateParent)
                                {
                                    currentMap.markDirty(i, j);
                                }
                            }
                        }
                    }
                }

                if (currentMap != null && currentMap.getDirtyProcentage() >= minDirtyRateBeforeUpdate && parent != null)
                {
                    updateParent = true;
                }

                if (updateParent){
                    if (parent == null)
                    {
                        throw new Exception("No parent map to be updated");
                    }
                    else
                    {
                        parent.pushMapUpdate(singleUpdate);
                    }
                }
            }
        }
    }
}
