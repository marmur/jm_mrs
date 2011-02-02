using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest.view
{
    public interface IControllerView
    {
        void UpdateAll();

        void UpdateProgress(string message, int percent);

        void showError(string message);

        void UpdateTestCasesList();
    }
}
