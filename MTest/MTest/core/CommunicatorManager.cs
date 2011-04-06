using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoBOSSCommunicator;
using Common.Logging;

namespace MTest.core
{
    class CommunicatorManager : ICommunicatorManageer
    {
        #region Logging Definition

        private static readonly ILog LOG = LogManager.GetLogger(typeof(CommunicatorManager));

        #endregion


        private Communicator communicator;

        public bool IsConnected { get; private set; }

        public CommunicatorManager()
        {
            communicator = null;
            IsConnected = false;
        }

        public void connect(String ipAddr, String port)
        {
            lock (this)
            {
                if (!IsConnected)
                {
                    communicator = new Communicator();
                    if (communicator.Connect(ipAddr, port, TestController.robossClientName) < 0)
                    {
                        string msg = "Unable to connect RoboSS controller " + ipAddr + ":" + port;
                        LOG.Debug(msg);
                        communicator = null;
                        throw new CommunicatorException(msg);
                    }
                    LOG.Info("Connected to RoboSS controller " + ipAddr + ":" + port);
                    IsConnected = true;

                }
            }
        }

        public void disconnect()
        {
            lock (this)
            {
                if (IsConnected)
                {
                    communicator.Dispose();
                    communicator = null;
                    IsConnected = false;
                    LOG.Info("Disconnected from RoboSS controller");
                }
            }
        }

        public Robot[] getAllRobots()
        {
            List<Robot> robotsList = new List<Robot>();
            lock (this)
            {
                if (!IsConnected)
                {
                    string msg = "RoboSS controller not connected";
                    LOG.Debug(msg);
                    throw new CommunicatorException(msg);
                }
                else
                {
                    foreach (Robot r in communicator.robots)
                    {
                        LOG.Info("Requesting for robot " + r.name);
                        if (r.Request() == 0)
                        {
                            robotsList.Add(r);
                        }
                        else
                        {
                            LOG.Warn("Robot " + r.name + " NOT assigned " + Communicator.GetLastError());
                        }
                    }
                }
            }
            return robotsList.ToArray();
        }



        internal void Reset()
        {
            lock (this)
            {
                if (IsConnected)
                {
                    if (communicator.ResetSimulation() < 0)
                    {
                        string msg = "Unable to reset RoboSS controller";
                        LOG.Debug(msg);
                        throw new CommunicatorException(msg);
                    }
                }
            }
        }


        public long TestTime
        {
            get
            {
                lock (this)
                {
                    if (IsConnected)
                    {
                        return communicator.simulationTime;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        internal void Start()
        {
            lock (this)
            {
                SimulationStart();
            }
        }

        internal void Resume()
        {
            lock (this)
            {
                SimulationStart();
            }
        }

        private void SimulationStart()
        {
            if (IsConnected)
            {
                LOG.Info("Starting RoboSS controller");
                if (communicator.StartSimulation() < 0)
                {
                    string msg = "Unable to start RoboSS controller";
                    LOG.Debug(msg);
                    throw new CommunicatorException(msg);
                }

            }
        }

        internal void Pause()
        {
            lock (this)
            {
                if (IsConnected)
                {
                    LOG.Info("Stop RoboSS controller");
                    if (communicator.StopSimulation() < 0)
                    {
                        string msg = "Unable to RoboSS controller";
                        LOG.Debug(msg);
                        throw new CommunicatorException(msg);
                    }
                }
            }
        }

        internal void Recive()
        {
            lock (this)
            {
                if (IsConnected)
                {
                    if (communicator.Receive(Communicator.RECEIVEBLOCKLEVEL_WaitForTimestamp) < 0)
                    {
                        string msg = "Unable to recive simulation status";
                        LOG.Debug(msg);
                        throw new CommunicatorException(msg);
                    }
                }
            }
        }



        internal void preStart()
        {
            if (IsConnected)
            {
                SimulationStart();
                SimulationStart();
                if (communicator.Receive(Communicator.RECEIVEBLOCKLEVEL_WaitForTimestamp) < 0)
                {
                    string msg = "Unable to recive simulation status";
                    LOG.Debug(msg);
                    throw new CommunicatorException(msg);
                }
                Reset();
            }
        }

        internal Geom[] GetAllWorldGeoms()
        {
            lock (this)
            {
                if (!IsConnected)
                {
                    string msg = "RoboSS controller not connected";
                    LOG.Debug(msg);
                    throw new CommunicatorException(msg);
                }
                else
                {
                    return communicator.environmentGeoms;
                }
            }
        }
    }
}
