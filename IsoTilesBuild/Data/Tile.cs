using IsoTilesBuild.Properties;
using IsoTilesBuild.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IsoTilesBuild.Data
{
    internal class Tile
    {
        public string Name { get; set; }
        public Bitmap Bitmap { get; set; }

        public Tile(string name, Bitmap bitmap)
        {
            Name = name;
            Bitmap = bitmap;
        }

        public Tile(string name, Bitmap bitmap, int row, int col)
        {
            Name = name;
            Bitmap = new Bitmap(24, 16);
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                if (row % 2 == 0)
                {
                    g.DrawImageUnscaled(bitmap, -col * 24, -(row / 2) * 16);
                }
                else
                {
                    g.DrawImageUnscaled(bitmap, -col * 24 - 12, -(row / 2) * 16 - 8);
                }
            }
            Bitmap = Bitmap.ApplyTransparencyMask(Resources.iso_mask);
        }

        public static Tile Combine(List<Tile> tiles, List<Point> pos)
        {
            foreach(var p in pos)
            {
                Debug.WriteLine(p.ToString());
            }
            int minx = pos.Select(p => p.X).Min();
            int miny = pos.Select(p => p.Y).Min();
            if (minx % 2 == 1) minx--;
            if (miny % 2 == 1) miny--;
            List<Point> crd = pos.Select(p => new Point(p.X - minx, p.Y - miny)).ToList();

            foreach (var p in crd)
            {
                Debug.WriteLine(p.ToString());
            }

            int maxx = crd.Select(p => p.X).Max();            
            int maxy = crd.Select(p => p.Y).Max();            

            Bitmap bmp = new Bitmap(maxx * 24 + 24, maxy * 16 + 16);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                for(int i=0;i<tiles.Count;i++)
                {                    
                    Debug.WriteLine("Here?");
                    int c = crd[i].X;
                    int r = crd[i].Y;
                    Debug.WriteLine($"{r} {c}");
                    int x0 = 12 + 24 * c + (r % 2 == 1 ? 12 : 0);
                    int y0 = 8 + 8 * r;
                    g.DrawImageUnscaled(tiles[i].Bitmap, x0 - 12, y0 - 8);
                }
            }
            bmp.Save("res.png");
            return new Tile("combined", bmp);
        }
    }
}
