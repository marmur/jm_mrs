﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public interface MapAware
    {
        void SetMap(IMap map);
    }

    public interface IMap
    {
        MapHolder getCurentMapView();
        MapHolder requestMapView(int topX, int topY, int sizeX, int sizeY);

        void pushMapUpdate(MapHolder update);
        bool isMapFullyUpdated();
    }

    public interface IMapManagment: IMap
    {
        void StartWork();
        void StopWork();
    }

    public interface IMapFactory
    {
        IMapManagment CreateMap(Vector startPosition);
    }
}