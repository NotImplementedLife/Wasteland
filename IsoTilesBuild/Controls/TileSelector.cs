using IsoTilesBuild.Data;
using IsoTilesBuild.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoTilesBuild.Controls
{
    internal partial class TileSelector : UserControl
    {
        public TileSelector()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }        

        Bitmap _Source = null;
        public Bitmap Source
        {
            get => _Source;
            set
            {
                _Source = value;
                if (_Source != null)
                {
                    Width = _Source.Width;
                    Height = _Source.Height;                    
                }
                Invalidate();
            }
        }        

        static Bitmap HoverTileBmp = Mask.TileMask(Color.FromArgb(128, Color.Red));
        int HoveredTileRow = 1;
        int HoveredTileCol = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Source == null) return;
            e.Graphics.DrawImageUnscaled(Source,0,0);

            if (SelectionPos.Count == 0)
            {

                if (HoveredTileRow % 2 == 0)
                {
                    e.Graphics.DrawImageUnscaled(HoverTileBmp, HoveredTileCol * 24, (HoveredTileRow / 2) * 16);
                }
                else
                {
                    e.Graphics.DrawImageUnscaled(HoverTileBmp, 12 + HoveredTileCol * 24, 8 + (HoveredTileRow / 2) * 16);
                }
            }
            else
            {
                foreach(var p in SelectionPos)
                {
                    if (p.Y % 2 == 0)
                    {
                        e.Graphics.DrawImageUnscaled(HoverTileBmp, p.X * 24, (p.Y / 2) * 16);
                    }
                    else
                    {
                        e.Graphics.DrawImageUnscaled(HoverTileBmp, 12 + p.X * 24, 8 + (p.Y / 2) * 16);
                    }
                }
            }

        }

        public Tile _SelectedTile = null;
        internal Tile SelectedTile
        {
            get => _SelectedTile;
            set
            {
                _SelectedTile = value;
                SelectedTileChanged?.Invoke(this);
            }
        }

        List<Tile> SelectionTiles = new List<Tile>();
        List<Point> SelectionPos = new List<Point>();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point pos = this.PointToClient(Cursor.Position);

            int x = (pos.Y / 8 + pos.X / 12) / 2;
            int y = (pos.Y / 8 - pos.X / 12) / 2;

            int xx = x + y;
            int yy = (x - y) / 2;

            //Debug.WriteLine(pos.ToString()+" "+new Point(xx,yy).ToString());
            //x /= 16;
            //y /= 16;

            HoveredTileRow = xx;
            HoveredTileCol = yy;

            if (Form.ModifierKeys == Keys.Control)
            {
                if (!SelectionPos.Contains(new Point(HoveredTileCol, HoveredTileRow))) 
                {
                    Tile tile = new Tile($"({HoveredTileRow},{HoveredTileCol})", Source, HoveredTileRow, HoveredTileCol);
                    SelectionTiles.Add(tile);
                    SelectionPos.Add(new Point(HoveredTileCol, HoveredTileRow));
                    SelectedTile = Tile.Combine(SelectionTiles, SelectionPos);
                }
                
            }
            else
            {
                SelectedTile = new Tile($"({HoveredTileRow},{HoveredTileCol})", Source, HoveredTileRow, HoveredTileCol);
                SelectionTiles.Clear();
                SelectionPos.Clear();
                SelectionTiles.Add(SelectedTile);
                SelectionPos.Add(new Point(HoveredTileCol, HoveredTileRow));
            }

            Invalidate();

            base.OnMouseHover(e);
        }

        public delegate void OnSelectedTileChanged(object sender);
        public event OnSelectedTileChanged SelectedTileChanged;


    }
}
