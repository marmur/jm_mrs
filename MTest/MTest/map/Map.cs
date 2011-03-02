using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MTest.map
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
    }



    public class MapFactory : IMapFactory
    {
        #region IMapFactory Members

        public IMapManagment CreateMap()
        {
            return new Map();
        }

        #endregion
    }


}
