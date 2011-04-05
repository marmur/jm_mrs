using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoBOSSCommunicator;

namespace MTest
{
    ///<summary>
    /// Describe the current state of robot 
    ///</summary>
    public enum DriverStatus 
    {
        Processing,     // robot is executing commands
        Done,           // robot has done his last command 
        Collision,      // robot has detected collision
        Obstacle        // robot has detected obstacle 
    }

    public interface IRobotDriver
    {
        string GetRobotType();
        void Process();
        void CommandTest(double leftEngine, double rightEngine);
        void CommandGoTo(double x, double y);
        void CommandLookAt(double x, double y);
        void CommandEmergencyStop();

        int Id
        {
            get;
        }

        string Name
        {
            get;
        }

        string Type
        {
            get;
        }

        DriverStatus Status
        {
            get;
        }

        double[] Position
        {
            get;
        }

        double[] SensorsValue
        {
            get;
        }

        Robot.Joint[] Joints
        {
            get;
        }

        Vector Direction
        {
            get;
        }
        
    }
}
