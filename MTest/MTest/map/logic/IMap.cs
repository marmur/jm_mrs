using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapSync.Logic
{
    interface IMap
    {
        MapHolder getCurentMapView();
        MapHolder getRequestedMapView(int topX, int topY, int sizeX, int sizeY);

        void pushMapUpdate(MapHolder update);
        bool isMapFullyUpdated();
    }
}
