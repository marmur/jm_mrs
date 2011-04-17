using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core;
using System.Threading;
using MTest.core.maps;

namespace MTest.agents
{
    class ScoutFira:IScoutAgent
    {
        private ITestEnviroment _testEnvironment;
        private IRobotDriver _driver;
        private IAgentLeader _leader;
        private IAgentEnviroment _agentEnviroment;
        private string _name;
        private IMap _map;


        public void SetMap(IMap map)
        {
            _map = map;
        }

        public IMap GetMap()
        {
            return _map;
        }


        public string GetDriverType()
        {
            return "ScoutDirver";
        }

        public void SetDriver(IRobotDriver driver)
        {
            _driver = driver;
        }

        public IRobotDriver GetDriver()
        {
           return _driver;
        }

        public void SetLeader(IAgentLeader leader)
        {
            _leader = leader;
        }

        public void DoWork()
        {
            double[] oldPosition = _driver.Position;
            double oldX = oldPosition[0];
            double oldY = oldPosition[1];

            double mulX = 1;
            double mulY = 1;

            MapHolderBuilder mhb = new MapHolderBuilder(_map.WorldProperties);
            MapHolder update = null;
            Random rnd = new Random();
            while(true){
                if (_driver.Status == DriverStatus.Processing)
                {
                    _agentEnviroment.AgentLOG(this, "Sleep");
                    Thread.Sleep(2000);
                }
                else
                {
                    if (_driver.Status == DriverStatus.Done)
                    {
                        //movement was successful - updating map (no course change)
                        double[] currentPosution = _driver.Position;

                        if (oldX != currentPosution[0] || oldY != currentPosution[1])
                        {
                            update = mhb.buildUpdate(oldX, oldY,
                                currentPosution[0], currentPosution[1], 0.05);

                            _agentEnviroment.AgentLOG(this, "-------------Send map update path: (" + oldX + ";" +
                                oldY + ") => (" + currentPosution[0] + ";" + currentPosution[1] + ")");

                            _map.pushMapUpdate(update);
                        }
                        else
                        {
                            _agentEnviroment.AgentLOG(this, "--------------No movement");
                        }
                    }
                    else
                    {
                        //Robot had found an obsitcle - changing course
                        _agentEnviroment.AgentLOG(this, "------------Status: " + _driver.Status);
                        update = null;
                        if ((rnd.Next() % 2) == 0)
                        {
                            mulX *= -1;
                        }
                        else
                        {
                            mulY *= -1;
                        }
                    }


                    //determining new point to goto
                    oldPosition = _driver.Position;
                    oldX = oldPosition[0];
                    oldY = oldPosition[1];
                    double nextX = rnd.NextDouble() * 0.1 * mulX + oldX;
                    double nextY = rnd.NextDouble() * 0.1 * mulY + oldY;

                    _agentEnviroment.AgentLOG(this, "------------GOTO: (" + nextX + "," + nextY +")");
                    //moving 
                    _driver.CommandGoTo(nextX,nextY);
                    
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string ToString()
        {
            return _name;
        }

        public void SetAgentEnviroment(IAgentEnviroment agentEnviroment)
        {
            _agentEnviroment = agentEnviroment;
        }

    }
}
