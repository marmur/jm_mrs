using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTest
{
    public class Vector
    {
        private double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(double x, double y):this(x,y,0.0)
        {
        }

        public Vector(double[] d):this(d[0],d[1],d[2])
        {
        }

        public Vector(Vector copy)
        {
            x = copy.X;
            y = copy.Y;
            z = copy.Z;
        }
       

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public double Lenght()
        {
            return Math.Sqrt(x*x + y*y);
        }


        public void Normalize()
        {
            double a = Lenght();
            if (a.Equals(0.0))
                return;
            x /= a;
            y /= a;
        }

        public override String ToString()
        {
            return String.Format("[{0:0.000}: {1:0.00}]",x,y);
        }

        public void Sub(Vector v)
        {
            x -= v.X;
            y -= v.Y;
        }

        public void Add(Vector v)
        {
            x += v.X;
            y += v.Y;
        }


        /// <summary>
        /// which way rotate vector
        /// </summary>
        /// <param name="toVector">desire direction</param>
        /// <returns>true if rotation right will be faster than left</returns>
        public bool IsRotateRightAGoodIdea(Vector toVector)
        {
            bool rotateRight = true;
            // finding which way the robot should be rotate
            if (toVector.X != 0)
            {
                if (y < (toVector.Y / toVector.X) * x)
                {
                    rotateRight = false;
                }
                if (toVector.X < 0.0)
                    rotateRight = !rotateRight;
            }
            else //toVector.X == 0.0
            {
                if (x > 0.0)
                    rotateRight = false;
                if (toVector.Y < 0.0)
                    rotateRight = !rotateRight;
            }
            return rotateRight;
        }
    }
}
