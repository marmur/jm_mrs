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
        public string GetFormatedStartTime()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(StartTime * 1000);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        public string GetFormatedDeadLineTime()
        {
            if (DeadlineTime >= 0)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(DeadlineTime * 1000);
                return string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else
            {
                return "unlimited";
            }
        }
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
            return "Start: " + Description.StartTime + " Stop:" + Description.DeadlineTime + " ClientType:" + Description.ClientType;
        }

        internal bool shouldRun(long time)
        {
            if (Status == TestState.Waiting && (Description.StartTime * 1000000 <= time))
            {
                return true;
            }
            else
            {
                return false;
            }
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
