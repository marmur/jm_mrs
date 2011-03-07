using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{
    public class MapHolder
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
        }

        private int[,] map;
        public int[,] Map
        {
            get
            {
                return map;
            }
        }


        public int SizeX
        {
            get
            {
                return map.GetLength(0) ;
            }
        }


        public int SizeY
        {
            get
            {
                return map.GetLength(1);
            }
        }



        private int[,] cpMap(int[,] source)
        {
            if (source != null)
            {
                return (int[,])source.Clone();
            }
            else
            {
                return null;
            }
        }


        public MapHolder(MapHolder mapHolder)
        {
            x = mapHolder.x;
            y = mapHolder.y;
            map = cpMap(mapHolder.map);
        }


        public MapHolder(int[,] map, int x, int y)
        {
            this.map = cpMap(map);
            this.x = x;
            this.y = y;
        }
    }
}
