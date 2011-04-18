using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    class MapHolderBuilder
    {
        private WorldProperties wp;
        public MapHolder buildUpdate(double startx, double starty, double stopx, double stopy, double width)
        {
            
            SimulatedWorldPosition p1 = wp.convertRealToSimulatedPositions(new RealWorldPosition(startx,starty));
            SimulatedWorldPosition p2 = wp.convertRealToSimulatedPositions(new RealWorldPosition(stopx,stopy));
            int w = wp.getCellsCount(width/2);


            int minX, maxX;
            if (p1.x < p2.x)
            {
                minX = p1.x;
                maxX = p2.x;
            }
            else
            {
                minX = p2.x;
                maxX = p1.x;
            }

            int minY, maxY;
            if (p1.y < p2.y)
            {
                minY = p1.y;
                maxY = p2.y;
            }
            else
            {
                minY = p2.y;
                maxY = p1.y;
            }

            if (minX < 0 || minY < 0)
            {
                throw new Exception("Error douring creation of map - index out of bound");
            }


            int sizeX = maxX - minX;
            int sizeY = maxY - minY;

            int[,] map;
            if (sizeX != 0 && sizeY !=0)
            {
                map = new int[sizeX, sizeY];
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        map[i, j] = Map.UNKNOWN_MAP_STATE;
                    }
                }

                p1.x -= minX;
                p2.x -= minX;
                p1.y -= minY;
                p2.y -= minY;

                double a = ((double)p1.y - (double)p2.y) / (((double)p1.x - (double)p2.x));
                double b = (double)p1.y - a * (double)p1.x;

                for (int i = 0; i < sizeX; i++)
                {
                    int y = (int)(a * i + b);

                    for (int j = ((y - w) > 0 ? y - w : 0); j < ((y + w + 1) < sizeY ? y + w + 1 : sizeY); j++)
                    {
                        map[i, j] = 0;
                    }

                }

            }
            else
            {
                if (sizeX == 0)
                {
                    sizeX = 1 + w * 2;
                    minX = minX - w;
                    if (minX < 0)
                    {
                        sizeX += minX;
                        minX = 0;
                    }

                }


                if (sizeY == 0)
                {
                    sizeY = 1 + w * 2;
                    minY = minY - w;
                    if (minY < 0)
                    {
                        sizeY += minY;
                        minY = 0;
                    }
                }

                map = new int [sizeX , sizeY];
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        map[i, j] = 0;
                    }
                }

            }

            MapHolder result = new MapHolder(map, minX, minY);






            return result;
        }

        public MapHolderBuilder(WorldProperties wp)
        {
            this.wp = wp;
        }
    }
}
