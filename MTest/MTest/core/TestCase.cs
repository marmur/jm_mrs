using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core
{
    public enum TestState
    {
        Waiting, Processing, Success, Fail
    }

    public class TestCaseDescription
    {
        public Vector StartPosition { get; set; }
        public Vector EndPosition { get; set; }
        public string ClientType { get; set; }
        public long StartTime { get; set; }
        public long DeadlineTime { get; set; }
    }


    public class TestCase
    {
        public TestCaseDescription Description { get; set; }
        public TestState Status { get; set; }
        public WorkingGroup WorkingGroup { get; set; }

        public TestCase(TestCaseDescription description)
        {
            this.Description = description;
            this.Status = TestState.Waiting;
        }

        public override string ToString()
        {
            return "Start: "+Description.StartTime+" Stop:"+ Description.DeadlineTime+" ClientType:"+Description.ClientType;
        }
    }

    public class WorkingGroup
    {
        private List<IScoutAgent> _scouts;
        public IAgentLeader Leader { get; set; }
        public IClientAgent Client { get; set; }

        public List<IScoutAgent> Scouts
        {
            get { return _scouts; }
        }

        public WorkingGroup()
        {
            _scouts = new List<IScoutAgent>();
        }

    }
}
