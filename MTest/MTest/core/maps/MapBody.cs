using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    class MapBody: IMap
    {
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
}
