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

        public void Initialize(Geom[] geoms, Robot[] robots)
        {
            Vector worldSize = FindLargestGeom(geoms);
            Vector robotSize = FindSmallestRobot(robots);
            double longEdge = robotSize.X > robotSize.Y ? robotSize.X : robotSize.Y;
            double cellSize = longEdge / 3.0;
            _mapSizeX = (int)Math.Ceiling(worldSize.X / cellSize);
            _mapSizeY = (int)Math.Ceiling(worldSize.Y / cellSize);
            LOG.Info("Map size : [ " + _mapSizeX + " , " + _mapSizeY + " ]");
            _worldProperties = new WorldProperties(_mapSizeX, _mapSizeY, worldSize.X, worldSize.Y, 0, 0);
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
                    Vector lMax = FindLargestGeom(p.geoms);
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

        private Vector FindLargestGeom(Geom[] geoms)
        {
            double sizeX = 0;
            double sizeY = 0;
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
                    }
                }
                return new Vector(sizeX, sizeY, 0);
            }
        }


        internal void Reset()
        {
            LOG.Info("Reseting base map");
            _baseMap.StopWork();
            _baseMap = createBaseMap();
            _baseMap.StartWork();
        }

        private Map createBaseMap()
        {
            _baseMap = new Map();
            _baseMap.GetMapBody().initializeMap(_mapSizeX, _mapSizeY);
            return _baseMap;
        }

        public void Dispose()
        {
            if (_baseMap != null)
            {
                _baseMap.StopWork();
            }
        }
    }
}
