using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoBOSSCommunicator;

namespace MTest
{
    class FiraDriver: IRobotDriver
    {
        private Robot robot;

        public FiraDriver(Robot r)
        {
            this.robot = r;
        }

        public int id
        {
            get { return robot.id; }
        }

        public string name
        {
            get { return robot.name; }
        }

        public string type
        {
            get { return robot.type; }
        }

        unsafe public double* position
        {
            get { return robot.position; }
        }

        public void Refresh()
        {
        }

        /*
        public void Refresh(double leftVelocity, double rightVelocity)
        {
            this.robot.joints[0].motorDesiredVelocity = leftVelocity;
            this.robot.joints[1].motorDesiredVelocity = rightVelocity;
        }
        */

    }
}
