using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoBOSSCommunicator;

namespace MTest.core
{

    class RobotsRepository
    {
        private class RobotInfo
        {
            public bool IsFree { get; set; }
            public Vector InitialPosition { get; set; }
            public Vector InitialRotation { get; set; }
            public string Type { set; get; }
            public int Id { set; get; }
            public Robot Robot { get; set; }
        }


        private Dictionary<int, RobotInfo> robotsInfo;
        private Dictionary<string, int> robotsTypeCount;

        public RobotsRepository()
        {
            robotsInfo = new Dictionary<int, RobotInfo>();
            robotsTypeCount = new Dictionary<string, int>();
        }

        public void FillRepo(Robot[] allRobots)
        {
            robotsInfo.Clear();
            robotsTypeCount.Clear();
            foreach (Robot r in allRobots)
            {
                RobotInfo info = new RobotInfo();
                info.Id = r.id;
                info.IsFree = true;
                info.Type = r.type;
                info.Robot = r;
                unsafe
                {
                    info.InitialPosition = new Vector(r.position[0], r.position[1], r.position[2]);
                    info.InitialRotation = new Vector(r.rotation[0], r.rotation[1], r.rotation[2]);
                }
                robotsInfo.Add(r.id, info);
                int value;
                if (robotsTypeCount.TryGetValue(info.Type, out value))
                {
                    robotsTypeCount[info.Type] = value + 1;
                }
                else
                {
                    robotsTypeCount.Add(info.Type, 1);
                }
            }
        }

        public int GetRobotsCount(string type)
        {
            int value;
            if (robotsTypeCount.TryGetValue(type, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public Robot GetFreeRobotByType(string type)
        {
            Robot result = null;
            foreach(KeyValuePair<int, RobotInfo> kvp in robotsInfo){
                if(kvp.Value.Type.Equals(type) && kvp.Value.IsFree){
                    result = kvp.Value.Robot;
                    kvp.Value.IsFree = false;
                    break;
                }
            }
            return result;
        }

        public void MarkRobotAsFree(Robot robot)
        {
            RobotInfo info = robotsInfo[robot.id];
            info.IsFree = true;
        }

        public Vector GetRobotInitialPosition(Robot robot)
        {
            return robotsInfo[robot.id].InitialPosition;
        }

        public Vector GetRobotInitialRotation(Robot robot)
        {
            return robotsInfo[robot.id].InitialRotation;
        }


        internal void Reset()
        {
            foreach (KeyValuePair<int, RobotInfo> kvp in robotsInfo)
            {
                kvp.Value.IsFree = true;
            }
        }
    }
}
