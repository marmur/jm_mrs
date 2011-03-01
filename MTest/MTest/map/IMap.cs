using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.map
{
    public interface MapAware
    {
        void SetMap(IMap map);
    }

    public interface IMap
    {

    }

    public interface IMapManagment: IMap
    {
        void StartWork();
        void StopWork();
    }

    public interface IMapFactory
    {
        IMapManagment CreateMap();
    }
}
