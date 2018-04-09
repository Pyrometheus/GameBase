using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsKickAss
{
    public class Model
    {
        //initialize all the dimensions
        public readonly int width;
        public readonly int height;
        public readonly int cellWidth = 100;
        public readonly int cellHeight = 100;
        public readonly bool[,] cells;

        public readonly float gravity = 1;

        public HashSet<Keys> keys;

        public Model(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new bool[width, height];
            keys = new HashSet<Keys>();

            //left wall
            fillArea(0,0, 0,5, true);
            //upper wall
            fillArea(8,0, 15,0, true);
            //bottom floor
            fillArea(0, 5, 12, 5, true);

            //upper divits
            cells[9, 1] = true;
            cells[11, 1] = true;
            cells[14, 1] = true;

            keys = new HashSet<Keys>();
        }

        public void fillArea(int x0, int y0, int x1, int y1, bool value)
        {
            for (int x = x0; x <= x1; x++)
            {
                for (int y = y0; y <= y1; y++)
                {
                    cells[x, y] = value;
                }
            }
        }

        public bool Occupied(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return false;
            return cells[x, y];
        }

        public void InputKeyDown(object sender, KeyEventArgs e)
        {
            keys.Add(e.KeyCode);
        }
        public void InputKeyUp(object sender, KeyEventArgs e)
        {
            keys.Remove(e.KeyCode);
        }

        public bool isKeyDown(Keys key)
        {
            return keys.Contains(key);
        }
    }
}