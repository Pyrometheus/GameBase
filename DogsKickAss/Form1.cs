﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsKickAss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //KEY CONTROLS CALLED
            this.KeyDown += InputKeyDown;
            //this.KeyUp += InputKeyUp;

            this.KeyDown += model.InputKeyDown;
            this.KeyUp += model.InputKeyUp;

            InitializeComponent();
            this.pictureBox1.Paint += PictureBox_Paint;
        }
        //GLOBAL VARIABLES
        Player player = new Player();
        Model model = new Model(25, 25);

        //KEYBOARD FUNCTIONS
        public void InputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        //public void InputKeyUp(object sender, KeyEventArgs e)
        //{
        //}

        //CHANGE FUNCTION
        public void update()
        {
            //Recalls ALL PLAYER VARIABLES To make certain they're current
            player.Update(model);
            player.SquarePhysics(model);
        }
        //DISPLAY FUNCTION
        public void Render(Graphics g)
        {
            g.TranslateTransform(pictureBox1.Width / 2 - player.hitbox.Position.current.x, pictureBox1.Height / 2 - player.hitbox.Position.current.y);
            //clears all previous drawings from the picturebox
            g.Clear(Color.FromArgb(200, 120, 120, 255));
            //BRUSHES AND PENS
            Pen background = new Pen(Color.Black);
            Brush black = new SolidBrush(Color.Black);
            Brush red = new SolidBrush(Color.Red);
            DrawGrid(g, background, black, model);
            DrawBlock(g, red, player.hitbox);
        }
        //RENDER FUNCTIONS
        public void DrawBlock(Graphics g, Brush brush, Block block)
        {
            g.FillRectangle(brush, new Rectangle((int)block.Position.current.x - (int)block.width / 2, (int)block.Position.current.y - (int)block.height / 2, (int)block.width, (int)block.height));
        }
        public void DrawGrid(Graphics g, Pen pen, Brush brush, Model model)
        {
            //loops through rows then individual cells within the rows
            for (int y = 0; y < model.height; y++)
            {
                for (int x = 0; x < model.width; x++)
                {
                    //defines the rectangle to be filled orr bordered
                    Rectangle Cell = new Rectangle(
                        x * model.cellWidth, y * model.cellHeight, 
                       model.cellWidth,      model.cellWidth);
                    //Borders every cell in the map
                    g.DrawRectangle(pen, Cell);
                    //Fills in any true ones
                    if (model.Occupied(x, y))
                        g.FillRectangle(brush, Cell);
                }
            }
        }
        //RELOAD FUNCTION
        public void PictureBox_Paint(Object sender, PaintEventArgs e)
        {
            update();
            Render(e.Graphics);
            pictureBox1.Invalidate();
        }
    }
}