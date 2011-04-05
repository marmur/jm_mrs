using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.view;
using System.ComponentModel;

namespace MTest.core
{

    public class TestControllerException : System.Exception
    {
        public TestControllerException() : base() { }
        public TestControllerException(string message) : base(message) { }
        public TestControllerException(string message, System.Exception inner) : base(message, inner) { }
    }

    public interface ITestController : IDisposable
    {
        IControllerView ControllerView { get; set; }

        ICommunicatorManageer CommunicatorManager { get; }

        void SetTestCases(List<TestCaseDescription> testCases);

        void Connect(String ipAddr, String port);

        bool IsInitialized();

        bool IsRunnign();

        bool IsPaused();

        bool IsFinished();

        void RunTest();

        void Reset();

        void PauseTest();

        void ResumeTest();

        void SetFocusOnAgent(IAgent agent);

        void SetFocusOnTestCase(TestCase testCase);

        void Disconnect();

        BindingList<TestCase> TestCasesList { get; }

        TestCase FocusedTestCase { get; }
    }

    public interface ITestEnviroment
    {
        void SeignalTestEnd(IClientAgent from);
    }
}
