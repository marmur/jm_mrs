using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTest.core.maps;

namespace MTest.core.maps
{
    /// <summary>
    /// Summary description for MapHelperBuilderTest
    /// </summary>
    [TestClass]
    public class MapHelperBuilderTest
    {

        private static WorldProperties wp;
        private static MapFactory mf;

        [TestInitialize()]
        public void testInitializer()
        {
            wp = new WorldProperties(100, 100, 100, 100, 0,0);
            mf = new MapFactory(wp);
        }


        private void assertHapHolderEqualsToMap(MapHolder result, int x, int y, int[][] expected)
        {
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);

            for (int i = 0; i < result.SizeX; i++)
            {
                for (int j = 0; j < result.SizeY; j++)
                {
                    Assert.AreEqual(expected[j][i], result.Map[i,j]);
                }
            }
        }

        [TestMethod]
        public void TestHorizontalMap1()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int [][] res = new int[10][];

            res[0] = new int[] { u, u, u, u, u, u, u, u, 0, 0 };
            res[1] = new int[] { u, u, u, u, u, u, u, 0, 0, 0 };
            res[2] = new int[] { u, u, u, u, u, u, 0, 0, 0, u };
            res[3] = new int[] { u, u, u, u, u, 0, 0, 0, u, u };
            res[4] = new int[] { u, u, u, u, 0, 0, 0, u, u, u };
            res[5] = new int[] { u, u, u, 0, 0, 0, u, u, u, u };
            res[6] = new int[] { u, u, 0, 0, 0, u, u, u, u, u };
            res[7] = new int[] { u, 0, 0, 0, u, u, u, u, u, u };
            res[8] = new int[] { 0, 0, 0, u, u, u, u, u, u, u };
            res[9] = new int[] { 0, 0, u, u, u, u, u, u, u, u };

            

            MapHolder result = mf.CreateMapHolder(0,9,9,0,1);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }


        [TestMethod]
        public void TestHorizontalMap2()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { u, u, u, u, u, u, u, u, 0, 0 };
            res[1] = new int[] { u, u, u, u, u, u, u, 0, 0, 0 };
            res[2] = new int[] { u, u, u, u, u, u, 0, 0, 0, u };
            res[3] = new int[] { u, u, u, u, u, 0, 0, 0, u, u };
            res[4] = new int[] { u, u, u, u, 0, 0, 0, u, u, u };
            res[5] = new int[] { u, u, u, 0, 0, 0, u, u, u, u };
            res[6] = new int[] { u, u, 0, 0, 0, u, u, u, u, u };
            res[7] = new int[] { u, 0, 0, 0, u, u, u, u, u, u };
            res[8] = new int[] { 0, 0, 0, u, u, u, u, u, u, u };
            res[9] = new int[] { 0, 0, u, u, u, u, u, u, u, u };



            MapHolder result = mf.CreateMapHolder(0, 9, 9, 0, 2);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }

        [TestMethod]
        public void TestHorizontalMap4()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { u, u, u, u, u, u, u, 0, 0, 0 };
            res[1] = new int[] { u, u, u, u, u, u, 0, 0, 0, 0 };
            res[2] = new int[] { u, u, u, u, u, 0, 0, 0, 0, 0 };
            res[3] = new int[] { u, u, u, u, 0, 0, 0, 0, 0, u };
            res[4] = new int[] { u, u, u, 0, 0, 0, 0, 0, u, u };
            res[5] = new int[] { u, u, 0, 0, 0, 0, 0, u, u, u };
            res[6] = new int[] { u, 0, 0, 0, 0, 0, u, u, u, u };
            res[7] = new int[] { 0, 0, 0, 0, 0, u, u, u, u, u };
            res[8] = new int[] { 0, 0, 0, 0, u, u, u, u, u, u };
            res[9] = new int[] { 0, 0, 0, u, u, u, u, u, u, u };



            MapHolder result = mf.CreateMapHolder(0, 9, 9, 0, 4);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }



       [Ignore]
        public void TestHorizontalMapNK()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[1] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[2] = new int[] { u, u, u, u, u, u, u, u, 0, u };
            res[3] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[4] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[5] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[6] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[7] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[8] = new int[] { u, u, u, u, u, u, u, u, u, u };
            res[9] = new int[] { u, u, u, u, u, u, u, u, u, u };



            MapHolder result = mf.CreateMapHolder(0, 9, 9, 0, 1);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }


        [TestMethod]
        public void TestHorizontalMapNK1()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { 0, 0, 0 };
            res[1] = new int[] { 0, 0, 0 };
            res[2] = new int[] { 0, 0, 0 };
            res[3] = new int[] { 0, 0, 0 };
            res[4] = new int[] { 0, 0, 0 };
            res[5] = new int[] { 0, 0, 0 };
            res[6] = new int[] { 0, 0, 0 };
            res[7] = new int[] { 0, 0, 0 };
            res[8] = new int[] { 0, 0, 0 };
            res[9] = new int[] { 0, 0, 0 };



            MapHolder result = mf.CreateMapHolder(1, 9, 1, 0, 1);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }


        [TestMethod]
        public void TestHorizontalMapKN()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            res[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };



            MapHolder result = mf.CreateMapHolder(0, 0, 9, 0, 1);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }



        [TestMethod]
        public void TestHorizontalMapNK4()
        {
            int u = Map.UNKNOWN_MAP_STATE;

            int[][] res = new int[10][];
            res[0] = new int[] { 0, 0, 0 };
            res[1] = new int[] { 0, 0, 0 };
            res[2] = new int[] { 0, 0, 0 };
            res[3] = new int[] { 0, 0, 0 };
            res[4] = new int[] { 0, 0, 0 };
            res[5] = new int[] { 0, 0, 0 };
            res[6] = new int[] { 0, 0, 0 };
            res[7] = new int[] { 0, 0, 0 };
            res[8] = new int[] { 0, 0, 0 };
            res[9] = new int[] { 0, 0, 0 };



            MapHolder result = mf.CreateMapHolder(0, 9, 0, 0, 4);

            assertHapHolderEqualsToMap(result, 0, 0, res);
        }
    
    
    
    
    
    
    
    
    
    
    
    }
}
