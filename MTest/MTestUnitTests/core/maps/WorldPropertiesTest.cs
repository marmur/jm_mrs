using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTest.core.maps;

namespace MTest.core.maps
{
    /// <summary>
    /// Summary description for WorldPropertiesTest
    /// </summary>
    [TestClass]
    public class WorldPropertiesTest
    {
        WorldProperties createBasicWP()
        {
            return new WorldProperties(100, 100, 100, 100, 0, 0);
        }

        WorldProperties createBasic1_3WP()
        {
            return new WorldProperties(100, 100, 300, 300, 0, 0);
        }

        WorldProperties createBasic3_1WP()
        {
            return new WorldProperties(300, 300, 100, 100, 0, 0);
        }

        WorldProperties createBasicMovedWP()
        {
            return new WorldProperties(100, 100, 100, 100, 10, 10);
        }

        WorldProperties createBasic1_3MovedWP()
        {
            return new WorldProperties(100, 100, 300, 300, 10, 10);
        }

        WorldProperties createBasic3_1MovedWP()
        {
            return new WorldProperties(300, 300, 100, 100, 10, 10);
        }


        WorldProperties createBasic4_1MovedWP()
        {
            return new WorldProperties(400, 400, 100, 100, 10, 10);
        }


        private void assertSingleRtoSTest(WorldProperties wp, double rwpx, double rwpy, int swpx, int swpy)
        {
            RealWorldPosition rwp = new RealWorldPosition(rwpx, rwpy);

            SimulatedWorldPosition swp = wp.convertRealToSimulatedPositions(rwp);
            Assert.AreEqual (swp.x, swpx);
            Assert.AreEqual (swp.y, swpy);
        }


        private void assertSingleStoRTest(WorldProperties wp, int swpx, int swpy, double rwpx, double rwpy)
        {
            SimulatedWorldPosition swp = new SimulatedWorldPosition(swpx, swpy);

            RealWorldPosition rwp = wp.convertSimulatedToRealPositions(swp);
            Assert.AreEqual (rwp.x, rwpx);
            Assert.AreEqual (rwp.y, rwpy);
        }




        [TestMethod]
        public void Test_1_to_1_cast_RtoS()
        {
            WorldProperties wp = createBasicWP();

            assertSingleRtoSTest(wp, 10, 10, 10, 10);
            assertSingleRtoSTest(wp, 34, 89, 34, 89);
        }


        [TestMethod]
        public void Test_1_to_3_cast_RtoS()
        {
            WorldProperties wp = createBasic3_1WP();

            assertSingleRtoSTest(wp, 10, 10, 30, 30);
            assertSingleRtoSTest(wp, 34, 89, 102, 267);
        }


        [TestMethod]
        public void Test_3_to_1_cast_RtoS()
        {
            WorldProperties wp = createBasic1_3WP();
            assertSingleRtoSTest(wp, 30, 30, 10, 10);
            assertSingleRtoSTest(wp, 102, 267, 34, 89);
        }


        [TestMethod]
        public void Test_1_to_1_moved_cast_RtoS()
        {
            WorldProperties wp = createBasicMovedWP();
            assertSingleRtoSTest(wp, 10, 10, 0, 0);
            assertSingleRtoSTest(wp, 34, 89, 24, 79);
        }
        
        [TestMethod]
        public void Test_3_to_1_moved_cast_RtoS()
        {
            WorldProperties wp = createBasic1_3MovedWP();
            assertSingleRtoSTest(wp, 10, 10, 0, 0);
            assertSingleRtoSTest(wp, 110, 160, 33, 50);
            assertSingleRtoSTest(wp, 310, 10, 100, 0);
        }

        [TestMethod]
        public void Test_1_to_3_moved_cast_RtoS()
        {
            WorldProperties wp = createBasic3_1MovedWP();
            assertSingleRtoSTest(wp, 10, 35, 0, 75);
            assertSingleRtoSTest(wp, 60, 110, 150, 300);
        }


        [TestMethod]
        public void Test_4_to_1_moved_cast_RtoS()
        {
            WorldProperties wp = createBasic4_1MovedWP();

            assertSingleRtoSTest(wp,10,35.5, 0, 102);
        }




        [TestMethod]
        public void Test_1_to_1_cast_StoR()
        {
            WorldProperties wp = createBasicWP();

            assertSingleStoRTest(wp, 0, 0, 0, 0);
            assertSingleStoRTest(wp, 50, 100, 50, 100);
        }


        [TestMethod]
        public void Test_1_to_3_cast_StoR()
        {
            WorldProperties wp = createBasic1_3WP();

            assertSingleStoRTest(wp, 0, 25, 0, 75);
            assertSingleStoRTest(wp, 50, 100, 150, 300);
        }

        [TestMethod]
        public void Test_3_to_1_cast_StoR()
        {
            WorldProperties wp = createBasic3_1WP();

            assertSingleStoRTest(wp, 0, 75, 0, 25);
            assertSingleStoRTest(wp, 150, 300, 50, 100);
        }

        [TestMethod]
        public void Test_1_to_1_moved_cast_StoR()
        {
            WorldProperties wp = createBasicMovedWP();

            assertSingleStoRTest(wp, 0, 25, 10, 35);
            assertSingleStoRTest(wp, 50, 100, 60, 110);
        }

        [TestMethod]
        public void Test_1_to_3_moved_cast_StoR()
        {
            WorldProperties wp = createBasic1_3MovedWP();

            assertSingleStoRTest(wp, 0, 25, 10, 85);
            assertSingleStoRTest(wp, 50, 100, 160, 310);
        }

        [TestMethod]
        public void Test_3_to_1_moved_cast_StoR()
        {
            WorldProperties wp = createBasic3_1MovedWP();

            assertSingleStoRTest(wp, 0, 75, 10, 35);
            assertSingleStoRTest(wp, 150, 300, 60, 110);
        }

        [TestMethod]
        public void Test_4_to_1_moved_cast_StoR()
        {
            WorldProperties wp = createBasic4_1MovedWP();

            assertSingleStoRTest(wp, 0, 102, 10, 35.5);
        }

    }
}
