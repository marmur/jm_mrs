using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public interface IMapFactory
    {
        IMapManagment CreateMap(Vector startPosition);
        MapHolder CreateMapHolder();
    }


    public class MapFactory : IMapFactory
    {
        #region IMapFactory Members

        public IMapManagment CreateMap(Vector startPosition)
        {
            return new Map();
        }

        public MapHolder CreateMapHolder()
        {
            return null;
        }


        #endregion
    }
}
