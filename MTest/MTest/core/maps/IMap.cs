using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public interface MapAware
    {
        void SetMap(IMap map);
        IMap GetMap();
    }

    public interface IMap
    {
        MapHolder getCurentMapView();
        MapHolder requestMapView(int topX, int topY, int sizeX, int sizeY);

        void pushMapUpdate(MapHolder update);
        bool isMapFullyUpdated();
        WorldProperties WorldProperties { get; }
    }

    public interface IMapManagment: IMap
    {
        void StartWork();
        void StopWork();
        void SetWorldProperties(WorldProperties wp);
        IMapManagment CreateChildMap();
    }


}
