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


        private int sizeX;
        public int SizeX
        {
            get
            {
                return sizeX;
            }
        }


        private int sizeY;
        public int SizeY
        {
            get
            {
                return sizeY;
            }
        }



        private int[,] cpMap(int sizeX, int sizeY, int[,] source)
        {
            int[,] res = new int[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    res[i, j] = source[i, j];
                }
            }
            return res;
        }


        public MapHolder(MapHolder mapHolder)
        {
            sizeY = mapHolder.sizeY;
            sizeX = mapHolder.sizeX;
            x = mapHolder.x;
            y = mapHolder.y;
            map = cpMap(sizeX, sizeY,mapHolder.map);
        }


        public MapHolder(int sizeX, int sizeY, int[,] map, int x, int y)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.map = cpMap(sizeX, sizeY, map);
            this.x = x;
            this.y = y;
        }
    }
}
