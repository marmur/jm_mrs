using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public interface IMapFactory
    {
        IMapManagment CreateMap(Vector startPosition);
        MapHolder CreateMapHolder(double startx, double starty, double stopx, double stopy, double width);
        WorldProperties GetWorldProperties();
    }


    public class MapFactory : IMapFactory
    {
        private WorldProperties _wp;
        private MapHolderBuilder _mhb;
        #region IMapFactory Members



        public IMapManagment CreateMap(Vector startPosition)
        {
            return new Map(null);
        }

        public MapHolder CreateMapHolder(double startx, double starty, double stopx, double stopy, double width)
        {
            return _mhb.buildUpdate(startx, starty, stopx, stopy, width);
        }


        public WorldProperties GetWorldProperties()
        {
            return _wp;
        }

        #endregion

        public MapFactory(WorldProperties wp)
        {
            this._wp = wp;
            this._mhb = new MapHolderBuilder(wp);
        }
    }
}
