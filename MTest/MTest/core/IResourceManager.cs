using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.core
{
    public interface IResourceManager: ITestEnviroment
    {
        void SetTestController(TestController testControlle);
        void Reset();

        void initTestCase(TestCase te);
    }
}
