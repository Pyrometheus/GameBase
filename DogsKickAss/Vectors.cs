using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsKickAss
{
    public class Point
    {
        public float x;
        public float y;
        public readonly Point Grid;
        public Point(int nx, int ny)
        {
            this.x = (float)nx;
            this.y = (float)ny;
        }
        public Point(float nx, float ny)
        {
            this.x = nx;
            this.y = ny;
        }
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
    }
    public class Vector
    {
        public Point current;
        public Point future;
        public readonly float Magnitude;
        public readonly float xDist;
        public readonly float yDist;
        public Vector(Point c, Point v)
        {
            current = c;
            future = v;
            xDist = current.x - future.x;
            yDist = current.y - future.y;
            Magnitude = (float)Math.Sqrt(xDist*xDist + yDist*yDist);
        }
        public Vector()
        {
            current = new Point();
            future = new Point();
            xDist = current.x - future.x;
            yDist = current.y - future.y;
            Magnitude = (float)Math.Sqrt(xDist * xDist + yDist * yDist);
        }
    }
}