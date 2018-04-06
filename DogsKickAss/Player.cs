using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsKickAss
{
    public class Player
    {
        //MOVEMENT
        public float xVelocity;
        public float yVelocity;
        public float jumpForce;
        public float fallForce;
        public float xSpeeed;
        public float ySpeeed;
        //Current and Future positions
        public Point current;
        public Point future;//(make future and current have same starting value)
        public Vector Position;
        public Vector GridCoords;
        //DIMENSIONS
        public float height;
        public float width;
        public float weight;
        //HITBOX INITIALIZATION
        public Block hitbox = new Block();
        public Player()
        {
            //MOVEMENT
            this.xVelocity = 0;
            this.yVelocity = 0;
            this.jumpForce = 10;
            this.fallForce = 0;
            this.xSpeeed = 5;
            this.ySpeeed = 5;
            //Current and Future positions
            this.current = new Point(400, 400);
            this.future = new Point(400, 400);//(make future and current have same starting value)
            this.Position = new Vector(current, future);
            this.GridCoords = new Vector(new Point(0, 0), new Point(0, 0));
            //DIMENSIONS
            this.height = 100;
            this.width = 100;
            this.weight = 25;
            //HITBOX INITIALIZATION
            this.hitbox = new Block(Position, weight, width, height);

        }
        //MOVEMENT FUNCTION
        public void Move(Model model)
        {
            //Updates the PLAYER Properties
            hitbox.Position.future.x = hitbox.Position.current.x;//Binds FUTURE.X to CURRENT.X
            hitbox.Position.future.y = hitbox.Position.current.y;//Binds FUTURE.Y to CURRENT.Y
            hitbox.Position.future.x += xVelocity;//adds the key-inputs to FUTURE.X
            hitbox.Position.future.y += yVelocity + fallForce;//adds the key-inputs to FUTURE.Y
            //Renews the PLAYER Properties for ease of reference
            Position = hitbox.Position;
            current = Position.current;
            future = Position.future;
            width = hitbox.width;
            height = hitbox.height;
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
            if (cellX < 0 || cellX >= model.Width)//only collides with Grid Cells
                return;
            if (cellY < 0 || cellY >= model.Height)//only collides with Grid Cells
                return;
            if (model.Cells[cellX, cellY] != null)
                collide(cellX, cellY);
        }

        public void collide(int cellX, int cellY)
        {
            int centerCellX = cellX * 100 + 50;
            int centerCellY = cellY * 100 + 50;

            float dx = hitbox.Position.future.x - centerCellX;
            float dy = hitbox.Position.future.y - centerCellY;

            if (dy > dx)
            {
                if (dy > -dx)
                {
                    //Console.WriteLine("Collide Down");
                    future.y = centerCellY + 50 + height / 2;
                }
                else
                {
                    //Console.WriteLine("Collide Right");
                    future.x = centerCellX - 50 - width / 2;
                }
            }
            else
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
