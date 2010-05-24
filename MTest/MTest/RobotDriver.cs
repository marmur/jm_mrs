using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest
{
    interface IRobotDriver
    {
        void Refresh();

        int id
        {
            get;
        }

        string name
        {
            get;
        }

        string type
        {
            get;
        }

        unsafe double* position
        {
            get;
        }
    }
}
