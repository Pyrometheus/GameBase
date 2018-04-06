using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsKickAss
{
    public class Model
    {
        //Camera controls
        public int cameraXOffSet;
        public int cameraYOffSet;
        //initialize all the dimensions
        public readonly int Width;
        public readonly int Height;
        public readonly float Gravity = 1;
        public readonly float CellWidth = 100;
        public readonly float CellHeight = 100;

        public readonly Boolean?[,] Cells;

        public Model(int width, int height)
        {
            this.cameraXOffSet = 0;
            this.cameraYOffSet = 0;
            this.Width = width;
            this.Height = height;
            Cells = new Boolean?[width, height];
            //left wall
            Cells[0, 0] = true;
            Cells[0, 1] = true;
            Cells[0, 2] = true;
            Cells[0, 3] = true;
            Cells[0, 4] = true;
            Cells[0, 5] = true;
            //upper wall
            Cells[15, 0] = true;
            Cells[14, 0] = true;
            Cells[13, 0] = true;
            Cells[12, 0] = true;
            Cells[11, 0] = true;
            Cells[10, 0] = true;
            Cells[9, 0] = true;
            Cells[8, 0] = true;
            //upper divits
            Cells[9, 1] = true;
            Cells[11, 1] = true;
            Cells[14, 1] = true;
            //bottom floor
            Cells[0, 5] = true;
            Cells[1, 5] = true;
            Cells[2, 5] = true;
            Cells[3, 5] = true;
            Cells[4, 5] = true;
            Cells[5, 5] = true;
            Cells[6, 5] = true;
            Cells[7, 5] = true;
            Cells[12, 5] = true;
        }
        public static void makeWall(Model model, int startX, int startY, int finishX, int finishY)
        {
            for (int y = startY; y < finishY; y++)
            {
                for(int x = startX; x < finishX; x++)
                {
                    model.Cells[x, y] = true;
                }
            }
        }
    }
}