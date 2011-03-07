using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTest.core.maps;

namespace MTest.core.maps
{
    [TestClass]
    public class MapTest
    {
        public MapTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private void asserMapValueasAreEqual(MapHolder mapHolder, int value)
        {
            for (int i = 0; i < mapHolder.SizeX; i++)
            {
                for (int j = 0; j < mapHolder.SizeY; j++)
                {
                    Assert.AreEqual(mapHolder.Map[i, j], value);
                }
            }
        }

        private MapHolder initializeMapHolder(int size, int baseValue)
        {
            return initializeMapHolder(size, baseValue, 0, 0);
        }

        private MapHolder initializeMapHolder(int size, int baseValue, int X, int Y)
        {
            return initializeMapHolder(size, size, baseValue, X, Y);
        }

        private MapHolder initializeMapHolder(int sizeX, int sizeY, int baseValue, int X, int Y)
        {
            int[,] map = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    map[i, j] = baseValue;
                }
            }
            return new MapHolder( map, X, Y);
        }







        private MapBody parentMap;
        private MapBody childMap;
        int size=10;

        [TestInitialize()]
        public void TestInitializer() {
            parentMap = new MapBody();
            parentMap.initializeMap(size, size);

            childMap = new MapBody();
            childMap.setParent(parentMap);
        }

        [TestMethod]
        public void isMapUpdatedTest()
        {
            Assert.IsTrue(parentMap.isMapFullyUpdated());
        }


        [TestMethod()]
        public void isMapUpdatedAfterInsertion()
        {
            parentMap.pushMapUpdate(new MapHolder( null, 0, 0));
            Assert.IsFalse(parentMap.isMapFullyUpdated());
        }

        [TestMethod()]
        public void isMapUpdatedAfterInsertionAndIteration()
        {
            childMap.pushMapUpdate(new MapHolder( null, 0, 0));
            childMap.retieveOneEmenentFormQueueAndUpdateMap();

            Assert.IsTrue(childMap.isMapFullyUpdated());
        }

        [TestMethod()]
        public void testMapInitialization()
        {
            MapHolder mapHolder = parentMap.getCurentMapView();

            Assert.IsNotNull(mapHolder);
            Assert.AreEqual(mapHolder.SizeX, size);
            Assert.AreEqual(mapHolder.SizeY, size);
            Assert.AreEqual(mapHolder.X, 0);
            Assert.AreEqual(mapHolder.Y, 0);

            asserMapValueasAreEqual(mapHolder, Map.UNKNOWN_MAP_STATE);
        }


        [TestMethod()]
        public void testIfNewMapIsNull()
        {
            IMap baseObject = new MapBody();
            MapHolder mapHolder = baseObject.getCurentMapView();

            Assert.IsNull(mapHolder);
        }

        [TestMethod()]
        public void testFullMapUpdate()
        {
            childMap.requestMapView(0, 0, size, size);

            MapHolder mapHolder = initializeMapHolder(size, 1);

            childMap.pushMapUpdate(mapHolder);
            childMap.retieveOneEmenentFormQueueAndUpdateMap();

            MapHolder reslut = childMap.getCurentMapView();
            asserMapValueasAreEqual(reslut, 1);

            parentMap.retieveOneEmenentFormQueueAndUpdateMap();
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();
            Assert.IsTrue(parentMap.isMapFullyUpdated());
            MapHolder parentResult = parentMap.getCurentMapView();
            asserMapValueasAreEqual(parentResult, 1);
        }

        [TestMethod()]
        public void testIfMapDoesntChangeFromMapHolderManipulation()
        {
            MapHolder mapHolder = parentMap.getCurentMapView();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mapHolder.Map[i, j] = 1;
                }
            }



            MapHolder reslut = parentMap.getCurentMapView();

            asserMapValueasAreEqual(reslut, Map.UNKNOWN_MAP_STATE);
        }


        [TestMethod()]
        public void testTooBigUpdate()
        {
            int size = this.size / 2;
            childMap.requestMapView(0, 0, size, size);

            MapHolder mapHolder = initializeMapHolder(size * 2, 1);

            childMap.pushMapUpdate(mapHolder);
            childMap.retieveOneEmenentFormQueueAndUpdateMap();

            MapHolder reslut = childMap.getCurentMapView();
            asserMapValueasAreEqual(reslut, 1);

            MapHolder parenResult = parentMap.getCurentMapView();
            asserMapValueasAreEqual(parenResult, Map.UNKNOWN_MAP_STATE);

            parentMap.retieveOneEmenentFormQueueAndUpdateMap();
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();
            Assert.IsTrue(parentMap.isMapFullyUpdated());
            parenResult = parentMap.getCurentMapView();
            asserMapValueasAreEqual(parenResult, 1);
        }

        [TestMethod()]
        public void testPartialUpdate()
        {
            MapHolder mapHolder = initializeMapHolder(2, 1, 3, 3);

            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            MapHolder reslut = parentMap.getCurentMapView();


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i == 3 || i == 4) && (j == 3 || j == 4))
                    {
                        Assert.AreEqual(reslut.Map[i, j], 1);
                    }
                    else
                    {
                        Assert.AreEqual(reslut.Map[i, j], Map.UNKNOWN_MAP_STATE);
                    }
                }
            }
        }


        [TestMethod()]
        public void testPartialGetFromExistingMap()
        {

            MapHolder mapHolder = initializeMapHolder(4, 1, 3, 3);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            MapHolder mh = parentMap.requestMapView(3, 3, 4, 4);
            Assert.AreEqual(mh.SizeX, 4);
            Assert.AreEqual(mh.SizeY, 4);
            Assert.AreEqual(mh.X, 3);
            Assert.AreEqual(mh.Y, 3);
            asserMapValueasAreEqual(mh, 1);
        }

        [TestMethod()]
        public void testPartialGetFromParentMap()
        {
            MapHolder mapHolder = initializeMapHolder(2, 1, 3, 3);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();



            MapHolder mh = childMap.requestMapView(3, 3, 2, 2);
            Assert.AreEqual(mh.SizeX, 2);
            Assert.AreEqual(mh.SizeY, 2);
            Assert.AreEqual(mh.X, 3);
            Assert.AreEqual(mh.Y, 3);
            asserMapValueasAreEqual(mh, 1);
        }


        [TestMethod()]
        public void testMapPositionSwitch()
        {
            MapHolder mapHolder = initializeMapHolder(2, 1, 3, 3);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            mapHolder = initializeMapHolder(2, 2, 7, 6);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();


            MapHolder mh = childMap.requestMapView(3, 3, 2, 2);
            Assert.AreEqual(mh.SizeX, 2);
            Assert.AreEqual(mh.SizeY, 2);
            Assert.AreEqual(mh.X, 3);
            Assert.AreEqual(mh.Y, 3);
            asserMapValueasAreEqual(mh, 1);


            mh = childMap.requestMapView(7, 6, 2, 2);
            Assert.AreEqual(mh.SizeX, 2);
            Assert.AreEqual(mh.SizeY, 2);
            Assert.AreEqual(mh.X, 7);
            Assert.AreEqual(mh.Y, 6);
            asserMapValueasAreEqual(mh, 2);

            mh = childMap.getCurentMapView();
            Assert.AreEqual(mh.SizeX, 2);
            Assert.AreEqual(mh.SizeY, 2);
            Assert.AreEqual(mh.X, 7);
            Assert.AreEqual(mh.Y, 6);
            asserMapValueasAreEqual(mh, 2);
        }

        [TestMethod()]
        public void testSecondUpdate()
        {
            MapHolder mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, Map.UNKNOWN_MAP_STATE);


            mapHolder = initializeMapHolder(size, 10);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, 10);

            mapHolder = initializeMapHolder(size, 20);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            Assert.IsTrue(parentMap.isMapFullyUpdated());
            mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, 18);
        }


        [TestMethod()]
        public void testEmptyMapUpdate()
        {
            MapHolder mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, Map.UNKNOWN_MAP_STATE);


            mapHolder = initializeMapHolder(size, 10);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, 10);

            mapHolder = initializeMapHolder(size, Map.UNKNOWN_MAP_STATE);
            parentMap.pushMapUpdate(mapHolder);
            parentMap.retieveOneEmenentFormQueueAndUpdateMap();

            Assert.IsTrue(parentMap.isMapFullyUpdated());
            mapHolder = parentMap.getCurentMapView();
            asserMapValueasAreEqual(mapHolder, 10);
        }



    }
}
