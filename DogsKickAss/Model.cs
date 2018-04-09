using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsKickAss
{
    public class Model
    {
        //initialize all the dimensions
        public readonly int width;
        public readonly int height;
        public readonly float gravity = 1;
        public readonly float cellWidth = 100;
        public readonly float cellHeight = 100;

        public readonly bool[,] cells;

        public Model(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new bool[width, height];
            //left wall
            cells[0, 0] = true;
            cells[0, 1] = true;
            cells[0, 2] = true;
            cells[0, 3] = true;
            cells[0, 4] = true;
            cells[0, 5] = true;
            //upper wall
            cells[15, 0] = true;
            cells[14, 0] = true;
            cells[13, 0] = true;
            cells[12, 0] = true;
            cells[11, 0] = true;
            cells[10, 0] = true;
            cells[9, 0] = true;
            cells[8, 0] = true;
            //upper divits
            cells[9, 1] = true;
            cells[11, 1] = true;
            cells[14, 1] = true;
            //bottom floor
            cells[0, 5] = true;
            cells[1, 5] = true;
            cells[2, 5] = true;
            cells[3, 5] = true;
            cells[4, 5] = true;
            cells[5, 5] = true;
            cells[6, 5] = true;
            cells[7, 5] = true;
            cells[12, 5] = true;
        }

        public bool Occupied(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return false;
            return cells[x, y];
        }
    }
}