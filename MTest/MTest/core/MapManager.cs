using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core.maps;
using RoBOSSCommunicator;
using Common.Logging;

namespace MTest.core
{
    public class MapManager : IDisposable
    {
        #region Logging Definition
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MapManager));
        #endregion

        private Map _baseMap;
        private WorldProperties _worldProperties;
        private int _mapSizeX = 0;
        private int _mapSizeY = 0;
        private List<IMapManagment> _childMaps = new List<IMapManagment>();

        public void Initialize(Geom[] geoms, Robot[] robots)
        {
            StopAllChildMaps();
            Pair world = FindLargestGeom(geoms);
            Vector worldSize = world.Size;
            Vector floorPosition = world.Position;
            Vector robotSize = FindSmallestRobot(robots);
            double longEdge = robotSize.X > robotSize.Y ? robotSize.X : robotSize.Y;
            double cellSize = longEdge / 3.0;
            _mapSizeX = (int)Math.Ceiling(worldSize.X / cellSize);
            _mapSizeY = (int)Math.Ceiling(worldSize.Y / cellSize);
            double positionX = floorPosition.X - worldSize.X / 2.0;
            double positionY = floorPosition.Y - worldSize.Y /2.0;
            if (_baseMap != null)
            {
                _baseMap.StartWork();
            }
            LOG.Info("Map size : [ " + _mapSizeX + " , " + _mapSizeY + " ] position(0,0): [" + positionX + " , " + positionY + "]");
            _worldProperties = new WorldProperties(_mapSizeX, _mapSizeY, worldSize.X, worldSize.Y, positionX, positionY);
            _baseMap = createBaseMap();
            _baseMap.StartWork();
        }

        private Vector FindSmallestRobot(Robot[] robots)
        {
            Vector min = new Vector(Double.MaxValue, Double.MaxValue, 0);
            Vector gMax;
            foreach (Robot r in robots)
            {
                gMax = new Vector(0, 0, 0);
                foreach (RoBOSSCommunicator.Robot.Part p in r.parts)
                {
                    Vector lMax = FindLargestGeom(p.geoms).Size;
                    if (lMax.X * lMax.Y > gMax.X * gMax.Y)
                    {
                        gMax = lMax;
                    }
                }
                if (min.X * min.Y > gMax.X * gMax.Y)
                {
                    min = gMax;
                }
            }
            return min;
        }

        private void StopAllChildMaps()
        {
            _childMaps.Reverse();
            foreach (IMapManagment map in _childMaps)
            {
                map.StopWork();
            }
            _childMaps.Clear();
        }



        private Pair FindLargestGeom(Geom[] geoms)
        {
            double sizeX = 0;
            double sizeY = 0;
            double positionX = 0;
            double positionY = 0;
            double area = 0;
            unsafe
            {
                foreach (Geom g in geoms)
                {
                    if (area < g.size[0] * g.size[1])
                    {
                        area = g.size[0] * g.size[1];
                        sizeX = g.size[0];
                        sizeY = g.size[1];
                        positionX = g.position[0];
                        positionY = g.position[1];
                    }
                }
                return new Pair()
                {
                    Position = new Vector(positionX, positionY, 0),
                    Size = new Vector(sizeX, sizeY, 0)
                };
            }
        }


        internal void Reset()
        {
            LOG.Info("Reseting base map");
            StopAllChildMaps();
            _baseMap.StopWork();
            _baseMap = createBaseMap();
            _baseMap.StartWork();
        }

        private Map createBaseMap()
        {
            _baseMap = new Map(this);
            _baseMap.SetWorldProperties(_worldProperties);
            _baseMap.GetMapBody().initializeMap(_mapSizeX, _mapSizeY);
            return _baseMap;
        }

        public void Dispose()
        {
            StopAllChildMaps();
            if (_baseMap != null)
            {
                _baseMap.StopWork();
            }
        }

        internal void RegisterChildMap(Map child)
        {
            _childMaps.Add(child);
        }

        public Map GetMainMap()
        {
            return _baseMap;
        }
    }

    public class Pair
    {
        public Vector Position { set; get; }
        public Vector Size { set; get; }
    };
}
