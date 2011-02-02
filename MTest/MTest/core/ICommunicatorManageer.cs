using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core
{
    public interface ICommunicatorManageer
    {
        bool IsConnected { get; }
        long TestTime { get; }
    }

    public class CommunicatorException : System.Exception
    {
        public CommunicatorException() : base() { }
        public CommunicatorException(string message) : base(message) { }
        public CommunicatorException(string message, System.Exception inner) : base(message, inner) { }
    }
}
