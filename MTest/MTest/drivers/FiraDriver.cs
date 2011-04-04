using System;
using System.Collections.Generic;
using System.Text;
using RoBOSSCommunicator;

namespace MTest
{
    class FiraDriver : IRobotDriver
    {
        private struct Command
        {
            public enum CType
            {
                LookAt,
                GoTo,
            }
            public CType type;
            public double x;
            public double y;

            public Command(CType type, double x, double y)
            {
                this.type = type;
                this.x = x;
                this.y = y;
            }
        }

        private const double rotationEpsilon = 0.005;
        private const double positionEpsilon = 0.005;
        private readonly double maxVelocity;
        private const double obstacleDetectionRange = 0.055;


        private const String rangeFinderName = "front_distance";
        private const String leftWheelName = "LeftFrontWheel";
        private const String rightWheelName = "RightFrontWheel";



        private Robot robot;
        private DriverStatus status;
        private Robot.SensorRangeFinder rangeFinder;
        private Vector direction;
        private Robot.Part leftWhell, rightWheel;
        private List<Command> commandQueue;


        public FiraDriver(double maxVelocity)
        {
            this.maxVelocity = maxVelocity;
        }

        public void SetRobot(Robot r)
        {
            this.robot = r;
            status = DriverStatus.Done;
            rangeFinder = robot.GetSensorByName(rangeFinderName) as Robot.SensorRangeFinder;
            leftWhell = robot.GetPartByName(leftWheelName);
            rightWheel = robot.GetPartByName(rightWheelName);
            direction = new Vector(0, 0);
            updateDirection();
            commandQueue = new List<Command>();
        }

        public FiraDriver(Robot r):this(10)
        {
            SetRobot(r);
        }

        #region Properties
        public DriverStatus Status
        {
            get { return status; }
        }

        public int Id
        {
            get { return robot.id; }
        }

        public string Name
        {
            get { return robot.name; }
        }

        public string Type
        {
            get { return robot.type; }
        }

        public double[] Position
        {
            get
            {
                unsafe
                {
                    return new double[] { robot.position[0], robot.position[1], robot.position[2] };
                }
            }
        }

        public double[] SensorsValue
        {
            get
            {
                rangeFinder.UpdateValue();
                return new double[] { rangeFinder.value };
            }
        }


        public Robot.Joint[] Joints
        {
            get
            {
                return robot.joints;
            }
        }

        public double MaxVelocity
        {
            get { return maxVelocity; }
        }

        public Vector Direction
        {
            get { updateDirection(); return direction; }
        }
        #endregion


        /// <summary>
        /// Calculate robot direction based on the wheel position 
        /// </summary>
        private void updateDirection()
        {
            unsafe
            {
                double ox, oy;
                ox = rightWheel.position[0] - leftWhell.position[0];
                oy = rightWheel.position[1] - leftWhell.position[1];
                direction.X = -oy;
                direction.Y = ox;
                direction.Normalize();
            }
        }


        /// <summary>
        /// Set wheels desired velocity
        /// </summary>
        /// <param name="leftEngine"></param>
        /// <param name="rightEngine"></param>
        private void SetEngineVelocity(double leftEngine, double rightEngine)
        {
            robot.joints[0].motorDesiredVelocity = leftEngine;
            robot.joints[1].motorDesiredVelocity = rightEngine;
        }

        /// <summary>
        /// Add command to inner queue, and change robotDriver status
        /// </summary>
        /// <param name="command"></param>
        private void addComand(Command command)
        {
            lock (commandQueue)
            {
                commandQueue.Add(command);
            }
        }

        private double RotationSpeedMap(double dV)
        {
            if (dV > 0.2)
                return 1.0;
            if (dV < 0.05)
                return 0.05;
            return dV * 6.32 - 0.264;

        }

        private double MovementSpeedMap(double dV)
        {
            if (dV > 0.1)
                return 1.0;
            if (dV > 0.05)
                return 0.5;
            return 0.1;

        }




        #region Commands
        public void Process()
        {
            //read position and direction
            updateDirection();
            rangeFinder.UpdateValue();
            Vector curnetPosition = new Vector(Position[0], Position[1]);
            //TODO: map update
            //TODO: colision detection
            Command toDo;
            lock (commandQueue)
            {
                if (commandQueue.Count == 0)
                { //nothing to do
                    if (status == DriverStatus.Processing)
                        status = DriverStatus.Done;
                    return;
                }
                toDo = commandQueue[0];
            }


            status = DriverStatus.Processing;
            Vector goal = new Vector(toDo.x, toDo.y);
            Vector dV;
            switch (toDo.type)
            {
                case Command.CType.LookAt:
                    goal.Sub(curnetPosition);
                    goal.Normalize();
                    dV = new Vector(goal);
                    dV.Sub(direction);
                    if (dV.Lenght() < rotationEpsilon || goal.Lenght() == 0.0)
                    {
                        SetEngineVelocity(0, 0);
                        lock (commandQueue)
                            commandQueue.RemoveAt(0);
                        return;
                    }
                    bool rotateRight = direction.IsRotateRightAGoodIdea(goal);
                    // set the engine velocity
                    double vel = maxVelocity * RotationSpeedMap(dV.Lenght());
                    if (rotateRight)
                    {
                        SetEngineVelocity(vel, -vel);
                    }
                    else
                    {
                        SetEngineVelocity(-vel, vel);
                    }
                    break;
                case Command.CType.GoTo:
                    // obstacle detection
                    if (rangeFinder.value < obstacleDetectionRange)
                    {
                        CommandEmergencyStop();
                        status = DriverStatus.Obstacle;
                        return;
                    }


                    dV = new Vector(goal);
                    dV.Sub(curnetPosition);
                    if (dV.Lenght() < positionEpsilon)
                    {
                        SetEngineVelocity(0, 0);
                        lock (commandQueue)
                            commandQueue.RemoveAt(0);
                        return;
                    }
                    double leftVel, rightVel;
                    leftVel = rightVel = maxVelocity * MovementSpeedMap(dV.Lenght());

                    //correction direction
                    Vector dDirection = new Vector(dV);
                    dDirection.Normalize();
                    Vector dDv = new Vector(dDirection);
                    dDv.Sub(direction);
                    if (dDv.Lenght() > rotationEpsilon)
                    {
                        if (direction.IsRotateRightAGoodIdea(dDirection))
                        {
                            rightVel -= rightVel * dDv.Lenght(); //rotationEpsilon < dDv.Length <= 2.0, 2.0 mean 180 degree error
                        }
                        else
                        {
                            leftVel -= leftVel * dDv.Lenght();
                        }
                    }
                    SetEngineVelocity(leftVel, rightVel);
                    break;
            }
        }

        public void CommandTest(double leftEngine, double rightEngine)
        {
            SetEngineVelocity(leftEngine, rightEngine);
        }
        public void CommandGoTo(double x, double y)
        {
            Command newComand = new Command(Command.CType.LookAt, x, y);
            addComand(newComand);
            newComand = new Command(Command.CType.GoTo, x, y);
            addComand(newComand);
        }
        public void CommandLookAt(double x, double y)
        {
            Command newComand = new Command(Command.CType.LookAt, x, y);
            addComand(newComand);
        }
        public void CommandEmergencyStop()
        {
            SetEngineVelocity(0, 0);
            lock (commandQueue)
            {
                commandQueue.Clear();
            }
            status = DriverStatus.Done;
        }
        #endregion
    }
}
