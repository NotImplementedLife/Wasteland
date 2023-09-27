using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileScrollTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
            
            using(var g=Graphics.FromImage(VramBg))
            {
                for(int y=0;y<32;y++)
                {
                    for (int x = 0; x < 32; x++)
                        g.FillRectangle((x + y) % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray, Zoom * 8 * x, Zoom * 8 * y, Zoom * 8, Zoom * 8);
                }
            }

        }

        Point ScrollReg = new Point(0, 0);
        Bitmap VramBg = new Bitmap(256, 256);

        private void VramViewer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(VramBg, 0, 0);
            DrawViewArea(e.Graphics);
        }

        private int Zoom = 1;

        private void DrawRect(Graphics g, int x, int y)
        {
            var r = new Rectangle(x * Zoom, y * Zoom, 240 * Zoom - 1, 160 * Zoom - 1);
            g.DrawRectangle(Pens.Red, r);
            g.DrawLine(Pens.Red, r.Left, r.Top, r.Right, r.Bottom);
            g.DrawLine(Pens.Red, r.Right, r.Top, r.Left, r.Bottom);
        }

        private void DrawViewArea(Graphics g)
        {
            int x = (ScrollReg.X % 256 + 256) % 256;
            int y = (ScrollReg.Y % 256 + 256) % 256;

            DrawRect(g, x, y);
            DrawRect(g, x + 256, y);
            DrawRect(g, x - 256, y);

            DrawRect(g, x, y-256);
            DrawRect(g, x + 256, y-256);
            DrawRect(g, x - 256, y-256);

            DrawRect(g, x, y + 256);
            DrawRect(g, x + 256, y + 256);
            DrawRect(g, x - 256, y + 256);            

            ScrollCoordLabel.Text = $"Scroll X = {ScrollReg.X} ({x})\nScroll Y = {ScrollReg.Y} ({y})";
            ScrollCoordLabel.Text += $"\n\nCenter X = {ScrollReg.X + 120} ({(x + 120) % 256})\nCenter Y = {ScrollReg.Y + 80} ({(y + 80) % 256})";

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var d = ModifierKeys.HasFlag(Keys.Control) ? 4 : 1;

            if (e.KeyCode == Keys.Right) ScrollReg.X+=d;
            if (e.KeyCode == Keys.Left) ScrollReg.X -= d;

            if (e.KeyCode == Keys.Up) ScrollReg.Y -= d;
            if (e.KeyCode == Keys.Down) ScrollReg.Y += d;


            VramViewer.Invalidate();
        }
    }
}
