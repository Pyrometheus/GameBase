using System;
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
            this.KeyUp += InputKeyUp;
            InitializeComponent();
            this.pictureBox1.Paint += PictureBox_Paint;
        }
        //GLOBAL VARIABLES
        Player Player = new Player();
        Model Model = new Model(25, 25);
        //KEYBOARD FUNCTIONS
        public void InputKeyDown(object sender, KeyEventArgs e)
        {
            //movement KEYS
            if (e.KeyCode == Keys.W)
                Player.jump = -Player.Yspeed;
            if (e.KeyCode == Keys.A)
                Player.left = -Player.Xspeed;
            if (e.KeyCode == Keys.S)
                Player.fall = Player.Yspeed;
            if (e.KeyCode == Keys.D)
                Player.right = Player.Xspeed;
            //Function KEYS
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        public void InputKeyUp(object sender, KeyEventArgs e)
        {
            //movement KEYS
            if (e.KeyCode == Keys.W)
                Player.jump = 0;
            if (e.KeyCode == Keys.A)
                Player.left = 0;
            if (e.KeyCode == Keys.D)
                Player.right = 0;
            if (e.KeyCode == Keys.S)
                Player.fall = 0;
        }
        //CHANGE FUNCTION
        public void update()
        {
            //Recalls ALL PLAYER VARIABLES To make certain they're current
            Player.Move(Model);
        }
        //DISPLAY FUNCTION
        public void Render(Graphics g)
        {
            //clears all previous drawings from the picturebox
            g.Clear(Color.FromArgb(200, 120, 120, 255));
            //BRUSHES AND PENS
            Pen background = new Pen(Color.Black);
            Brush black = new SolidBrush(Color.Black);
            Brush red = new SolidBrush(Color.Red);
            DrawGrid(g, background, black, Model);
            DrawBlock(g, red, Player.hitbox);
        }
        //RENDER FUNCTIONS
        public void DrawBlock(Graphics g, Brush brush, Block block)
        {
            g.FillRectangle(brush, new Rectangle((int)block.Position.current.x - (int)block.width / 2, (int)block.Position.current.y - (int)block.height / 2, (int)block.width, (int)block.height));
        }
        public void DrawGrid(Graphics g, Pen pen, Brush brush, Model model)
        {
            //loops through rows then individual cells within the rows
            for (int y = 0; y < model.Height; y++)
            {
                for (int x = 0; x < model.Width; x++)
                {
                    //defines the rectangle to be filled orr bordered
                    Rectangle Cell = new Rectangle((x) * 100, (y) * 100, 100, 100);
                    //Borders every cell in the map
                    g.DrawRectangle(pen, Cell);
                    //Fills in any true ones
                    if (model.Cells[x, y] == true)
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