using IsoTilesBuild.Controls;
using IsoTilesBuild.Data;
using IsoTilesBuild.Properties;
using IsoTilesBuild.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoTilesBuild
{
    public partial class MainForm : Form
    {
        private TileSelector ActiveTileSelector;
        public MainForm()
        {
            InitializeComponent();

            LandTileSelector.Source = new Bitmap(Resources.iso_farm);
            TransparentTileSelector.Source = new Bitmap(Resources.iso_transparent);
            CropsTileSelector.Source = new Bitmap(Resources.crops);

            ActiveTileSelector = LandTileSelector;
            MapView.SetSize(100, 200);

            //ExportBorderMap(@"C:\Users\NotImpLife\Desktop\border.png");
        }

        void ExportBorderMap(string path)
        {
            Bitmap bmp = new Bitmap(path);
            int w = bmp.Width / 24;
            int h = 2 * (bmp.Height / 16) - 1;

            byte[] buf = new byte[h * w];

            for (int y = 0; y < h; y++) 
            {
                for (int x = 0; x < w; x++)
                {
                    int px = 24 * x + 12 + (y % 2 == 1 ? 12 : 0);
                    int py = 16 * (y / 2) + 8 + (y % 2 == 1 ? 8 : 0);
                    Color cl = bmp.GetPixel(px, py);
                    if(cl.R>=cl.G+cl.B)
                    {
                        buf[y * w + x] = 1;
                    }                    
                }
            }
            File.WriteAllBytes($"border_{w}_{h}.bin", buf);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void SelectedTileChanged(object sender)
        {
            MapView.Tile = (sender as TileSelector).SelectedTile;
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
            {
                MapView.ShowGrid = !MapView.ShowGrid;
            }
            else if (e.KeyCode == Keys.S)
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    MapView.Image.Save(SFD.FileName);
                }
            }
            else if(e.KeyCode==Keys.O)
            {
                if(OFD.ShowDialog()==DialogResult.OK)
                {
                    MapView.SetImage(new Bitmap(OFD.FileName));
                }
            }
        }
    }
}
