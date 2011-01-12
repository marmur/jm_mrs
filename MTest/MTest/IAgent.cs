using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest
{
    public interface IAgent
    {
       void setDriver(IRobotDriver driver);

       bool isWorkCompleat();

       void doWork();
    }
}
