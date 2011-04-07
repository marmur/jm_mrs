using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MTest.core.maps
{
    public class Map : IMapManagment
    {
        private bool _finish;
        private MapBody _mapBody;
        public static int UNKNOWN_MAP_STATE = -1;
        private MapManager _mapManager;
        private WorldProperties _worldProperties;

        public WorldProperties WorldProperties { get { return _worldProperties; } }

        private bool Finish
        {
            get
            {
                lock (this)
                {
                    return _finish;
                }

            }

            set
            {
                lock (this)
                {
                    _finish = value;
                }
            }
        }

        Thread mapThread;

        public void StartWork()
        {
            if (mapThread == null)
            {
                mapThread = new Thread(new ThreadStart(this.DoWork));
                mapThread.Name = "mapThread";
                mapThread.Start();
            }
        }

        public void StopWork()
        {
            if (mapThread != null)
            {
                Finish = true;
                if (!mapThread.Join(2000))
                {
                    mapThread.Abort();
                    mapThread.Join();
                }
                mapThread = null;
            }
        }


        private void DoWork()
        {
            while (!Finish)
            {
                _mapBody.retieveOneEmenentFormQueueAndUpdateMap();
                Thread.Sleep(2000);
            }
        }

        #region IMap Members


        public MapHolder getCurentMapView()
        {
            return _mapBody.getCurentMapView();
        }

        public MapHolder requestMapView(int topX, int topY, int sizeX, int sizeY)
        {
            return _mapBody.requestMapView(topX, topX, sizeX, sizeY);
        }

        public void pushMapUpdate(MapHolder update)
        {
            _mapBody.pushMapUpdate(update);
        }

        public bool isMapFullyUpdated()
        {
            return _mapBody.isMapFullyUpdated();
        }

        #endregion

        public MapBody GetMapBody()
        {
            return _mapBody;
        }

        public Map(MapManager mm)
        {
            _mapManager = mm;
            _mapBody = new MapBody();
        }

        public void SetWorldProperties(WorldProperties wp)
        {
            _worldProperties = wp;
        }

        public IMapManagment CreateChildMap()
        {
            Map child = new Map(_mapManager);
            child.GetMapBody().setParent(this);
            _mapManager.RegisterChildMap(child);
            child.SetWorldProperties(_worldProperties);
            child.StartWork();
            return child;
        }

    }
}
