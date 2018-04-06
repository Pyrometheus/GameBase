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
        public readonly int Width;
        public readonly int Height;
        public readonly float Gravity = 1;
        public readonly float CellWidth = 100;
        public readonly float CellHeight = 100;

        public readonly Boolean?[,] Cells;

        public Model(int width, int height)
        {
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
        }
    }
    public class Player
    {
        //MOVEMENT
        public static float xVelocity = 0;
        public static float yVelocity = 0;
        public static float jumpForce = 10;
        public static float fallForce = 0;
        public static float xSpeeed = 5;
        public static float ySpeeed = 5;
        //Current and Future positions
        public static Point current = new Point(400, 400);
        public static Point future = new Point(400, 400);//(make future and current have same starting value)
        public static Vector Position = new Vector(current, future);
        public static Vector GridCoords = new Vector(new Point(0, 0), new Point(0, 0));
        //DIMENSIONS
        public static float height = 100;
        public static float width = 100;
        public static float weight = 25;
        //HITBOX INITIALIZATION
        public static Block hitbox = new Block(Position, weight, width, height);
        //MOVEMENT FUNCTION
        public void Move(Model model)
        {
            //Updates the PLAYER Properties
            Player.hitbox.Position.future.x = Player.hitbox.Position.current.x;//Binds FUTURE.X to CURRENT.X
            Player.hitbox.Position.future.y = Player.hitbox.Position.current.y;//Binds FUTURE.Y to CURRENT.Y
            Player.hitbox.Position.future.x += Player.xVelocity;//adds the key-inputs to FUTURE.X
            Player.hitbox.Position.future.y += Player.yVelocity + fallForce;//adds the key-inputs to FUTURE.Y
            //Renews the PLAYER Properties for ease of reference
            Position = Player.hitbox.Position;
            current = Position.current;
            future = Position.future;
            width = Player.hitbox.width;
            height = Player.hitbox.height;
            //Bounds
            int rightGridBounds = (int)(future.x + width / 2) / 100;
            int leftGridBounds = (int)(future.x - width / 2) / 100;
            int upperGridBounds = (int)(future.y - height / 2) / 100;
            int lowerGridBounds = (int)(future.y + height / 2) / 100;

            tryCollide(model, leftGridBounds, upperGridBounds);
            tryCollide(model, rightGridBounds, upperGridBounds);
            tryCollide(model, leftGridBounds, lowerGridBounds);
            tryCollide(model, rightGridBounds, lowerGridBounds);

            current.x = future.x;
            current.y = future.y;

        }

        public void tryCollide(Model model, int cellX, int cellY)
        {
            if (cellX < 0 || cellX >= model.Width)
                return;
            if (cellY < 0 || cellY >= model.Height)
                return;
            if (model.Cells[cellX, cellY] != null)
                collide(cellX, cellY);
        }

        public void collide(int cellX, int cellY)
        {
            int centerCellX = cellX * 100 + 50;
            int centerCellY = cellY * 100 + 50;

            float dx = Player.hitbox.Position.future.x - centerCellX;
            float dy = Player.hitbox.Position.future.y - centerCellY;

            if (dy > dx)
            {
                if (dy > -dx)
                {
                    //Console.WriteLine("Collide Down");
                    future.y = centerCellY + 50 + height / 2;
                } else
                {
                    //Console.WriteLine("Collide Right");
                    future.x = centerCellX - 50 - width / 2;
                }
            } else
            {
                if (dy > -dx)
                {
                    //Console.WriteLine("Collide Left");
                    future.x = centerCellX + 50 + width / 2;
                }
                else
                {
                    //Console.WriteLine("Collide Up");
                    future.y = centerCellY - 50 - height / 2;
                }
            }
        }

    }
}