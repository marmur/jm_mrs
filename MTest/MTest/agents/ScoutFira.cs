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
            Thread.Sleep(2000);
            Random rnd = new Random();

            double[] oldPosition = _driver.Position;
            double oldX = oldPosition[0];
            double oldY = oldPosition[1];

            double mulX = 1;
            double mulY = 1;

            if ((rnd.Next() % 2) == 0)
            {
                mulX *= -1;
            }
            if ((rnd.Next() % 2) == 0)
            {
                mulY *= -1;
            }

            double nextX = 0;
            double nextY = 0;
            MapHolderBuilder mhb = new MapHolderBuilder(_map.WorldProperties);
            MapHolder update = null;
            while(true){
                if (_driver.Status == DriverStatus.Processing)
                {
                    _agentEnviroment.AgentLOG(this, "Sleep(" + nextX + ";" + nextY + ")");
                    Thread.Sleep(2000);
                }
                else
                {

                    double[] currentPosution = _driver.Position;

                    if (oldX != currentPosution[0] || oldY != currentPosution[1])
                    {
                        update = mhb.buildUpdate(oldX, oldY,
                            currentPosution[0], currentPosution[1], 0.6);

                        _agentEnviroment.AgentLOG(this, "-------------Send map update path: (" + oldX + ";" +
                            oldY + ") => (" + currentPosution[0] + ";" + currentPosution[1] + ")");

                    }else{
                        _agentEnviroment.AgentLOG(this, "--------------No movement");
                        update = null;
                    }



                    if (_driver.Status != DriverStatus.Done)
                    {
                        //Robot had found an obsitcle - changing course
                        if (update != null)
                        {
                            int xToCover = 0;
                            int yToCover = 0;

                            double directionX = _driver.Direction.X;
                            double directionY = _driver.Direction.Y;
                            double alfa = 0;
                            if (directionX != 0)
                            {
                                alfa = (Math.Atan(Math.Tan(directionY / directionX)) * 180) / Math.PI;
                                if (directionX < 0)
                                {
                                    alfa += 180;
                                }

                                if (alfa < 0)
                                {
                                    alfa += 360;
                                }

                            }
                            else
                            {
                                if (directionY > 0)
                                {
                                    alfa = 90;
                                }
                                else
                                {
                                    alfa = 270;
                                }
                            }

                            _agentEnviroment.AgentLOG(this, "My directions: [" + directionX + ";" + directionY + "], a = " + alfa);


                            if ( (0.0 <= alfa && alfa <= 45)  || (315 <= alfa && alfa <= 360))
                            {
                                xToCover = update.SizeX - 1;
                            }
                            else if (135 <= alfa && alfa <= 225)
                            {
                                xToCover = 0;
                            }
                            else
                            {
                                xToCover = -1;
                            }

                            if (45 <= alfa && alfa <= 135)
                            {
                                yToCover = update.SizeY - 1;
                            }
                            else if (225 <= alfa && alfa <= 315)
                            {
                                yToCover = 0;
                            }
                            else
                            {
                                yToCover = -1;
                            }






                            if (xToCover != -1)
                            {
                                for (int i = 0; i < update.SizeY; i++)
                                {
                                    if (update.Map[xToCover, i] != Map.UNKNOWN_MAP_STATE)
                                    {
                                        update.Map[xToCover, i] = Int32.MaxValue;
                                    }
                                }
                            }

                            if (yToCover != -1)
                            {
                                for (int i = 0; i < update.SizeX; i++)
                                {
                                    if (update.Map[i, yToCover] != Map.UNKNOWN_MAP_STATE)
                                    {
                                        update.Map[i, yToCover] = Int32.MaxValue;
                                    }
                                }
                            }

                        }
                        //TODO: Update map
                        _agentEnviroment.AgentLOG(this, "------------Status: " + _driver.Status);
                        if ((rnd.Next() % 2) == 0)
                        {
                            mulX *= -1;
                        }
                        if ((rnd.Next() % 2) == 0)
                        {
                            mulY *= -1;
                        }
                    }


                    if (update != null)
                    {
                        _map.pushMapUpdate(update);
                    }
                    

                    //determining new point to goto
                    oldPosition = _driver.Position;
                    if (_driver.Status != DriverStatus.Done)
                    {
                        oldX = oldPosition[0];
                        oldY = oldPosition[1];
                    }
                    nextX = rnd.NextDouble() * 0.4 * mulX + oldPosition[0] + 0.3;
                    nextY = rnd.NextDouble() * 0.4 * mulY + oldPosition[1] + 0.3;

                    _agentEnviroment.AgentLOG(this, "------------GOTO: (" + nextX + ";" + nextY +")");
                    //moving 
                    _driver.CommandGoTo(nextX,nextY);

                    Thread.Sleep(4000);
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
