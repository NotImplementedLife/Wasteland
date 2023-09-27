using IsoTilesBuild.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoTilesBuild.Controls
{
    internal partial class MapMaker : UserControl
    {
        public MapMaker()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private int _RowsCount = 0;
        public int RowsCount { get => _RowsCount; }

        private int _ColsCount = 0;
        public int ColsCount { get => _ColsCount; }

        public Bitmap Image = null;
        public void SetSize(int rows_count, int cols_count)
        {
            _RowsCount = rows_count;
            _ColsCount = cols_count;
            Size = new Size(24 * (cols_count + 2) / 2, 16 * (rows_count + 2) / 2);
            Image = new Bitmap(Size.Width, Size.Height);
        }

        public void SetImage(Bitmap image)
        {
            _RowsCount = 2 * image.Height / 16;
            _ColsCount = 2 * image.Width / 24;
            Size = new Size(24 * (_ColsCount + 2) / 2, 16 * (_RowsCount + 2) / 2);
            Image = image;

        }

        private void MapMaker_Load(object sender, EventArgs e)
        {

        }

        bool _ShowGrid = true;
        public bool ShowGrid
        {
            get => _ShowGrid;
            set
            {
                _ShowGrid = value;
                Invalidate();
            }
        }

        private Tile _Tile = null;
        public Tile Tile
        {
            get => _Tile;
            set => _Tile = value;
        }

        private int TileRow = 0;
        private int TileCol = 0;
    
        private static bool InRange(int x, int a, int b) { return a <= x && x < b; }        

        protected override void OnPaint(PaintEventArgs e)        
        {
            if (Image != null)
            {
                e.Graphics.DrawImageUnscaled(Image, 0, 0);
            }
            if (Tile!=null)
            {                
                if (InRange(TileRow, 0, RowsCount) && InRange(TileCol, 0, ColsCount))
                {                    
                    int x0 = 12 + 24 * TileCol + (TileRow % 2 == 1 ? 12 : 0);
                    int y0 = 8 + 8 * TileRow;
                    //e.Graphics.FillEllipse(Brushes.Red, x0 - 2, y0 - 2, 4, 4);
                    e.Graphics.DrawImageUnscaled(Tile.Bitmap, x0 - 12, y0 - 8);
                }                    
            }

            if(ShowGrid)
            {                
                var pen = new Pen(new SolidBrush(Color.FromArgb(64, 0, 0, 0)));
                for (int r=0;r<RowsCount;r++)
                {
                    for(int c=0;c<ColsCount;c++)
                    {
                        int x0 = 12 + 24 * c + (r % 2 == 1 ? 12 : 0);
                        int y0 = 8 + 8 * r;                                 
                        e.Graphics.DrawLine(pen, x0, y0 - 8, x0 - 12, y0);
                        e.Graphics.DrawLine(pen, x0, y0 - 8, x0 + 12, y0);
                        e.Graphics.DrawLine(pen, x0, y0 + 8, x0 - 12, y0);
                        e.Graphics.DrawLine(pen, x0, y0 + 8, x0 + 12, y0);
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                using (var g = Graphics.FromImage(Image))
                {
                    for (int r = 0; r < RowsCount; r++)
                    {
                        for (int c = 0; c < ColsCount; c++)
                        {
                            int x0 = 12 + 24 * c + (r % 2 == 1 ? 12 : 0);
                            int y0 = 8 + 8 * r;                            
                            g.DrawImageUnscaled(Tile.Bitmap, x0 - 12, y0 - 8);
                        }
                    }
                }
                return;
            }

            Point pos = this.PointToClient(Cursor.Position);

            int x = (pos.Y / 8 + pos.X / 12) / 2;
            int y = (pos.Y / 8 - pos.X / 12) / 2;

            int xx = x + y;
            int yy = (x - y) / 2;

            //Debug.WriteLine(pos.ToString() + " " + new Point(xx, yy).ToString());
            //x /= 16;
            //y /= 16;

            TileRow = xx;
            TileCol = yy;

            if (Tile != null)
            {
                if (InRange(TileRow, 0, RowsCount) && InRange(TileCol, 0, ColsCount))
                {
                    int x0 = 12 + 24 * TileCol + (TileRow % 2 == 1 ? 12 : 0);
                    int y0 = 8 + 8 * TileRow;
                    //e.Graphics.FillEllipse(Brushes.Red, x0 - 2, y0 - 2, 4, 4);
                    using (var g = Graphics.FromImage(Image))
                    {
                        g.DrawImageUnscaled(Tile.Bitmap, x0 - 12, y0 - 8);
                    }
                }
            }

            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)        
        {
            Point pos = this.PointToClient(Cursor.Position);

            int x = (pos.Y / 8 + pos.X / 12) / 2;
            int y = (pos.Y / 8 - pos.X / 12) / 2;

            int xx = x + y;
            int yy = (x - y) / 2;

            //Debug.WriteLine(pos.ToString() + " " + new Point(xx, yy).ToString());
            //x /= 16;
            //y /= 16;

            TileRow = xx;
            TileCol = yy;

            if (e.Button == MouseButtons.Left)
            {
                if (Tile != null)
                {
                    if (InRange(TileRow, 0, RowsCount) && InRange(TileCol, 0, ColsCount))
                    {
                        int x0 = 12 + 24 * TileCol + (TileRow % 2 == 1 ? 12 : 0);
                        int y0 = 8 + 8 * TileRow;
                        //e.Graphics.FillEllipse(Brushes.Red, x0 - 2, y0 - 2, 4, 4);
                        using (var g = Graphics.FromImage(Image))
                        {
                            g.DrawImageUnscaled(Tile.Bitmap, x0 - 12, y0 - 8);
                        }
                    }
                }
            }

            Invalidate();
        }
    }
}
