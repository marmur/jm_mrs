using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MTest
{
    enum SimpleAgentStatus
    {
        DONE, GO, FIND
    }

    class SimpleAgent: IAAgent
    {
        private IRobotDriver driver;

        private MainForm mainForm;
        private Vector desierPosition;
        private double epsilon = 0.007;
        private SimpleAgentStatus state = SimpleAgentStatus.GO;
        private int findIndex;
        private const int findDirectionCount = 2;
        private double[] findValue =new double[findDirectionCount * 4 + 1];
        private Vector[] findDirection = new Vector[findDirectionCount * 4 + 1];

        public void setDriver(IRobotDriver driver)
        {
            this.driver = driver;
        }

        public void setMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void doWork()
        {
            if(state == SimpleAgentStatus.DONE){
                return;
            }
            Thread.Sleep(200);

            switch (driver.Status)
            {
                case DriverStatus.Processing:
                    return;
                   
                case DriverStatus.Done:
                    if(isInGoalPosition()){
                        mainForm.sLog.log("\tAgent: I'm done my work");
                        driver.CommandEmergencyStop();
                        state = SimpleAgentStatus.DONE;
                        return;
                    }else if(state == SimpleAgentStatus.GO){
                        mainForm.sLog.log("\tAgent: go straight to goal");
                        driver.CommandGoTo(desierPosition.X, desierPosition.Y);
                    }
                    else if (state == SimpleAgentStatus.FIND)
                    {
                        findValue[findIndex] = driver.SensorsValue[0];
                        mainForm.sLog.log("\tAgent: Finding <" + findIndex + "> direction:" + findDirection[findIndex].ToString() +" actual direction: " +driver.Direction.ToString()+" value = " + findValue[findIndex]);
                        findIndex++;
                        if (findIndex == findDirection.Length)
                        {
                            mainForm.sLog.log("\tAgent: must choose");
                            int maxIndex = 0;
                            double maxVal = -1;
                            for (int i = 0; i < findValue.Length; i++ )
                            {
                                if(findValue[i] >= maxVal){
                                    maxIndex = i;
                                    maxVal = findValue[i];
                                }
                            }
                            Vector toGo = findDirection[maxIndex];
                            Vector vGo = new Vector(toGo);
                            vGo.Sub(new Vector(driver.Position[0],driver.Position[1]));
                            vGo.Normalize();


                            double toX = vGo.X * 0.3 + driver.Position[0];
                            double toY = vGo.Y * 0.3 + driver.Position[1];
                            driver.CommandGoTo(toX , toY );
                            mainForm.sLog.log("\tAgent: choose ["+maxIndex+"] : going to [" + toX +" : " + toY + "]");
                            state = SimpleAgentStatus.GO;
                        }
                        else
                        {
                            driver.CommandLookAt(findDirection[findIndex].X, findDirection[findIndex].Y);
                        }
                    }
                    break;

                case DriverStatus.Collision:
                    mainForm.sLog.log("\tAgent: Collision");
                    break;

                case DriverStatus.Obstacle:
                    if (state == SimpleAgentStatus.GO)
                    {
                        mainForm.sLog.log("\tAgent: Obstacle, state:" + state);
                        mainForm.sLog.log("\tAgent: prepare finding table");
                        prepareFindTable();
                        state = SimpleAgentStatus.FIND;
                        driver.CommandLookAt(findDirection[findIndex].X, findDirection[findIndex].Y);
                        mainForm.sLog.log("\tAgent: look at");
                    }
                    break;
            }
        }

        private void prepareFindTable()
        {
            double dx = driver.Direction.X;
            double dy = driver.Direction.Y;
            //finding first point on the left;
            Vector lookAt = new Vector(findDirectionCount * dy, - findDirectionCount * dx);
            lookAt.Add(new Vector(dx, dy));
            lookAt.Add(new Vector(driver.Position[0],driver.Position[1]));  
            dx/=2.0;
            dy/=2.0;
            mainForm.sLog.log("\tAgent: position : "+ driver.Position[0] +" :" + driver.Position[1] + " direction :" + driver.Direction.ToString());
            for (int i = 0; i < findDirectionCount * 4 +1;i++ )
            {
                findValue[i] = -1;
                findDirection[i] = new Vector(lookAt);
                mainForm.sLog.log("\tAgent: "+i+">>"+findDirection[i].ToString());
                lookAt.Sub(new Vector(dy,-dx));
            }
            findIndex = 0;
        }

        private bool isInGoalPosition()
        {
            Vector currentPosition = new Vector(driver.Position[0], driver.Position[1]);
            currentPosition.Sub(desierPosition);
            return currentPosition.Lenght() < epsilon;
        }

        public bool isWorkCompleat()
        {
            return state == SimpleAgentStatus.DONE;
        }

        public void setGoalPosition(double x, double y)
        {
            desierPosition = new Vector(x, y);
        }
    }
}
