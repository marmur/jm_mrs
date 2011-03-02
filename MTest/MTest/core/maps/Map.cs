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
                Thread.Sleep(2000);
            }
        }

        #region IMap Members


        public MapHolder getCurentMapView()
        {
            throw new NotImplementedException();
        }

        public MapHolder requestMapView(int topX, int topY, int sizeX, int sizeY)
        {
            throw new NotImplementedException();
        }

        public void pushMapUpdate(MapHolder update)
        {
            throw new NotImplementedException();
        }

        public bool isMapFullyUpdated()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class MapFactory : IMapFactory
    {
        #region IMapFactory Members

        public IMapManagment CreateMap(Vector startPosition)
        {
            return new Map();
        }

        #endregion
    }


}
