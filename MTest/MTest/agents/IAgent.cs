using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core;

namespace MTest
{
    public interface IAAgent
    {
        void setDriver(IRobotDriver driver);

        bool isWorkCompleat();

        void doWork();
    }

    public interface IAgent 
    {
        void DoWork();
        string Name { get; set; }
        void SetAgentEnviroment(IAgentEnviroment agentEnviroment);
    }

    public interface IRobotAgent : IAgent
    {
        string GetDriverType();
        void SetDriver(IRobotDriver driver);
        void SetLeader(IAgentLeader leader);
    }

    public interface IClientAgent : IRobotAgent
    {
        void SetTestEnviroment(ITestEnviroment enviroment);
    }

    public interface IScoutAgent : IRobotAgent
    {
       
    }

    public interface IAgentLeader : IAgent
    {
        void SetClient(IClientAgent client);
        void AssignScout(IScoutAgent scout);
        void SignalWorkDone();
    }

    public interface IAgentEnviroment
    {
        void LOG(IAgent from, string message);
        void UpdateAgentView(IAAgent from);
    }

}
