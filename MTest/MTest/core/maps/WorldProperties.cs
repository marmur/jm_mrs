using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core.maps
{

    public class RealWorldPosition
    {
        public double x;
        public double y;

        public RealWorldPosition()
            : this(0, 0)
        {
        }

        public RealWorldPosition(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class SimulatedWorldPosition
    {
        public int x;
        public int y;

        public SimulatedWorldPosition()
            : this(0, 0)
        {
        }

        public SimulatedWorldPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    public class WorldProperties
    {
        private double SimulationWorldSizeX;
        private double SimulationWorldSizeY;

        private double RealWorldSizeX;
        private double RealWorldSizeY;

        private double RealWorldTopX;
        private double RealWorldTopY;


        private double oneDimSimToRealConvert(double SimWorld, double RealWorld, double SimVal, double shift)
        {
            double ratio = RealWorld / SimWorld;
            return ((ratio * SimVal) + shift);
        }


        public RealWorldPosition convertSimulatedToRealPositions(SimulatedWorldPosition swp)
        {
            double x = oneDimSimToRealConvert(SimulationWorldSizeX, RealWorldSizeX, swp.x, RealWorldTopX);
            double y = oneDimSimToRealConvert(SimulationWorldSizeY, RealWorldSizeY, swp.y, RealWorldTopY);
            return new RealWorldPosition(x,y) ;
        }


        private int oneDimRealToSimConvert(double SimWorld, double RealWorld, double RealVal, double shift)
        {
            double ratio = SimWorld / RealWorld;
            return (int)((RealVal - shift) * ratio);
        }

        public SimulatedWorldPosition convertRealToSimulatedPositions(RealWorldPosition rwp)
        {
            int x = oneDimRealToSimConvert(SimulationWorldSizeX, RealWorldSizeX, rwp.x, RealWorldTopX);
            int y = oneDimRealToSimConvert(SimulationWorldSizeY, RealWorldSizeY, rwp.y, RealWorldTopY);

            return new SimulatedWorldPosition(x,y);
        }


        public WorldProperties(int SimulationWorldSizeX, int SimulationWorldSizeY,
                                double RealWorldSizeX, double RealWorldSizeY,
                                double RealWorldTopX, double RealWorldTopY)
        {
            this.SimulationWorldSizeX = SimulationWorldSizeX;
            this.SimulationWorldSizeY = SimulationWorldSizeY;

            this.RealWorldSizeX = RealWorldSizeX;
            this.RealWorldSizeY = RealWorldSizeY;

            this.RealWorldTopX = RealWorldTopX;
            this.RealWorldTopY = RealWorldTopY;
        }

        public int getCellsCount(double value)
        {
            double ratio = SimulationWorldSizeX / RealWorldSizeX;
            return (int)Math.Ceiling(value * ratio);

        }

    }
}
