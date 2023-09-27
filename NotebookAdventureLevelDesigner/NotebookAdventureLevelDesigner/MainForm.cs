using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookAdventureLevelDesigner
{
    public partial class MainForm : Form
    {
        Bitmap mapPic = null;
        Bitmap mapBlocks = new Bitmap(600, 840);
        Bitmap spikes = new Bitmap(600, 840);        
        Bitmap tramp = new Bitmap(600, 840);
        Bitmap obst = new Bitmap(600, 840);
        Bitmap actv = new Bitmap(600, 840);

        byte[,] mapX = new byte[105, 75];
        byte[,] mapS = new byte[105, 75];
        byte[,] mapT = new byte[105, 150];
        byte[,] mapO = new byte[105, 75];
        byte[,] mapA = new byte[105, 150];
        short playerX, playerY;        
        
        ushort catX, catY;


        Button Tool = null;

        Color[] Colors = new Color[]
        {
            Color.FromArgb(0, 255, 0),
            Color.FromArgb(255, 0, 0),
            Color.FromArgb(0, 0, 255)
        };

        void setMapBlock(int x, int y, int v)
        {
            mapX[y, x] = (byte)v;
            Color cl = Colors[v];
            var fillbrush = new SolidBrush(Color.FromArgb(60, cl));
            using (var gr = Graphics.FromImage(mapBlocks)) 
            {
                gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                gr.FillRectangle(fillbrush, 8 * x, 8 * y, 8, 8);
            }
        }

        void setMapS(int x, int y)
        {
            mapS[y, x] ^= 1;            
            using (var gr = Graphics.FromImage(spikes)) 
            {
                gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                gr.FillRectangle(mapS[y, x] == 0 ? Brushes.Transparent : Brushes.Red, 8 * x, 8 * y + 4, 8, 4);
            }
        }

        void setMapT(int x, int y, int p = 0)
        {
            Debug.WriteLine($"Tr {x}:{p}, {y}");
            mapT[y, 2 * x + p] ^= 1;
            Debug.WriteLine(mapT[y, 2 * x + p]);
            using (var gr = Graphics.FromImage(tramp)) 
            {
                gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                gr.FillRectangle(mapT[y, 2 * x + p] == 0 ? Brushes.Transparent : Brushes.DarkRed, 8 * x + 4 * p + 2, 8 * y + 4, 4, 4);
                Debug.WriteLine("here");
            }

        }

        void setMapA(int x, int y, int p, int clear=0)
        {
            if (clear == 0)
            {
                mapA[y, 2 * x + p] = 0;
            }
            else
            {
                mapA[y, 2 * x + p] += 1;
                if (mapA[y, 2 * x + p] >= 15) 
                    mapA[y, 2 * x + p] = 0;
            }
            using (var gr = Graphics.FromImage(actv)) 
            {
                gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                gr.FillRectangle(mapA[y, 2 * x + p] == 0 ? Brushes.Transparent : new SolidBrush(OColors[mapA[y, 2 * x + p]-1]), 8 * x + 4 * p + 2, 8 * y + 2, 4, 6);
                gr.DrawRectangle(mapA[y, 2 * x + p] == 0 ? Pens.Transparent : Pens.Black, 8 * x + 4 * p + 2, 8 * y + 2, 4, 6);
            }
        }

        Color[] OColors = new Color[]
        {
            Color.DarkBlue,
            Color.DarkGreen,
            Color.DarkCyan,
            Color.DarkRed,
            Color.DarkMagenta,
            Color.Olive,
            Color.DarkGray,
            Color.Blue,
            Color.Green,
            Color.Cyan,
            Color.Red,
            Color.Magenta,
            Color.Yellow,
            Color.Gray
        };

        void setObst(int x, int y, byte id, byte o)
        {
            mapO[y, x] += (byte)((id << 4) | o);
            if ((mapO[y, x] & 0xF) > 8) mapO[y, x] = 0;
            if (mapO[y, x] / 16 >= 14) mapO[y, x] &= 0xF;

            using (var gr = Graphics.FromImage(obst)) 
            {
                gr.Clear(Color.Transparent);
                for (int ty = 0; ty < 105; ty++) 
                {
                    for (int tx = 0; tx < 75; tx++) 
                    {
                        if (mapO[ty, tx] != 0) 
                        {
                            int oid = mapO[ty, tx] / 16;
                            int oor = mapO[ty, tx] % 16;
                            var cl = OColors[oid];
                            var brush = new SolidBrush(cl);
                            var pen = new Pen(brush, 2);
                            gr.FillEllipse(brush, 8 * tx + 2, 8 * ty + 2, 4, 4);
                            if(oor==1)
                            {
                                gr.DrawRectangle(pen, 8 * tx, 8 * (ty - 3), 8, 32);
                            }                            
                            else if(oor==2)
                            {
                                gr.DrawRectangle(pen, 8 * tx, 8 * ty, 32, 8);
                            }
                            else if(oor==3)
                            {
                                gr.DrawRectangle(pen, 8 * tx, 8 * ty, 8, 32);
                            }
                            else if(oor==4)
                            {
                                gr.DrawRectangle(pen, 8 * (tx - 3), 8 * ty, 32, 8);
                            }
                            else if(oor>=5)
                            {
                                gr.DrawRectangle(pen, 8 * tx, 8 * ty, 32, 8);
                                if (oor == 5)
                                    gr.DrawLine(pen, 8 * tx + 4, 8 * ty + 4, 8 * tx + 4 + 16, 8 * ty + 4);
                                else if (oor == 6)
                                    gr.DrawLine(pen, 8 * tx + 4, 8 * ty + 4, 8 * tx + 4, 8 * ty + 4 - 16);
                                else if (oor == 7)
                                    gr.DrawLine(pen, 8 * tx + 4, 8 * ty + 4, 8 * tx + 4 - 16, 8 * ty + 4);
                                else if (oor == 8)
                                    gr.DrawLine(pen, 8 * tx + 4, 8 * ty + 4, 8 * tx + 4, 8 * ty + 4 + 16);
                            }

                        }
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
               | BindingFlags.Instance | BindingFlags.NonPublic, null,
               Workspace, new object[] { true });
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapPicOfd.ShowDialog() == DialogResult.OK) 
            {
                var bmp = new Bitmap(MapPicOfd.FileName);
                if (bmp.Width != 600 || bmp.Height != 840) 
                {
                    MessageBox.Show("Wrong map size");
                    return;
                }

                for(int y=0;y<105;y++)
                {
                    for(int x=0;x<75;x++)
                    {
                        mapX[y, x] = 0;
                        mapS[y, x] = 0;
                        mapT[y, 2 * x] = mapT[y, 2 * x + 1] = 0;
                    }                        
                }

                mapPic = new Bitmap(600, 840, PixelFormat.Format24bppRgb);
                Graphics.FromImage(mapPic).DrawImageUnscaled(bmp, 0, 0);                

                for(int y = 0; y < 840; y++)
                {
                    for (int x = 0; x < 600; x++)
                        if (mapPic.GetPixel(x, y).Equals(Color.FromArgb(0xfc, 0, 0xfc))) 
                        {
                            mapPic.SetPixel(x, y, Color.White);
                        }
                }

                for(int tx=0;tx<75;tx++)
                {
                    for (int ty = 0; ty < 105; ty++) 
                    {
                        int val = 0;

                        for (int x = 1; x < 7 && val == 0; x++)
                            for (int y = 1; y < 7; y++) 
                            {
                                var c = mapPic.GetPixel(8 * tx + x, 8 * ty + y);
                                if (!c.Equals(Color.FromArgb(255, 255, 255))) 
                                {                                    
                                    val = 1;
                                    break;
                                }
                            }
                        setMapBlock(tx, ty, val);
                    }
                }

                Workspace.Invalidate();
            }
        }

        private void Workspace_Paint(object sender, PaintEventArgs e)
        {
            if (mapPic != null)
            {                
                e.Graphics.DrawImageUnscaled(mapPic, 0, 0);
                e.Graphics.DrawImageUnscaled(mapBlocks, 0, 0);
                e.Graphics.DrawImageUnscaled(spikes, 0, 0);                
                e.Graphics.DrawImageUnscaled(obst, 0, 0);
                e.Graphics.DrawImageUnscaled(actv, 0, 0);
                e.Graphics.DrawImageUnscaled(tramp, 0, 0);

                e.Graphics.DrawRectangle(Pens.BlueViolet, playerX - 8, playerY - 32, 16, 32);
                e.Graphics.DrawRectangle(Pens.Yellow, catX - 8, catY - 16, 16, 16);                
            }
        }        

        private void Container_Resize(object sender, EventArgs e)
        {           
        }
  
        private void Workspace_Click(object sender, EventArgs e)
        {
            
        }
       
        private void GreenBtn_Click(object sender, EventArgs e)
        {
            if(Tool!=null)
            {
                Tool.FlatAppearance.BorderColor = Color.Black;
            }
            Tool = sender as Button;
            Tool.FlatAppearance.BorderColor = Color.Orange;
        }

        bool msdown = false;
        private void Workspace_MouseDown(object sender, MouseEventArgs e)
        {
            msdown = true;
            int x = e.X / 8;
            int y = e.Y / 8;
            if (Tool == GreenBtn) setMapBlock(x, y, 0);
            else if (Tool == RedBtn) setMapBlock(x, y, 1);
            else if (Tool == BlueBtn) setMapBlock(x, y, 2);
            else if (Tool == SpikesBtn) setMapS(x, y);
            else if (Tool == TrampBtn)
            {
                setMapT(x, y, e.Button == MouseButtons.Right ? 1 : 0);
            }
            else if (Tool == PlayerBtn)
            {
                playerX = (short)e.X;
                playerY = (short)e.Y;
            }
            else if (Tool == CatBtn)
            {
                catX = (ushort)e.X;
                catY = (ushort)e.Y;
            }
            else if (Tool == ObstacleBtn)
            {                
                if(e.Button==MouseButtons.Left)
                {                    
                    setObst(x, y, 0, 1);
                }                
                else if(e.Button==MouseButtons.Right)
                {                    
                    setObst(x, y, 1, 0);
                }
            }
            else if(Tool==ActivatorBtn)
            {
                if((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    setMapA(x, y, e.Button == MouseButtons.Right ? 1 : 0, 1);
                }
                else setMapA(x, y, e.Button == MouseButtons.Right ? 1 : 0);
            }
            
            Workspace.Refresh();
        }


        private void Workspace_MouseHover(object sender, EventArgs e)
        {

        }

        private void Workspace_MouseMove(object sender, MouseEventArgs e)
        {
            if (!msdown) return;
            int x = e.X / 8;
            int y = e.Y / 8;
            if (Tool == GreenBtn) setMapBlock(x, y, 0);
            if (Tool == RedBtn) setMapBlock(x, y, 1);
            if (Tool == BlueBtn) setMapBlock(x, y, 2);            
            Workspace.Refresh();
        }

        private void Workspace_MouseUp(object sender, MouseEventArgs e)
        {
            if (!msdown) return;
            msdown = false;
        }
       
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapBinSfd.ShowDialog() == DialogResult.OK)
            {
                using (var bw = new BinaryWriter(File.OpenWrite(MapBinSfd.FileName)))
                {
                    bw.Write(ToBytes<byte>(mapX));
                    bw.Write(lvlNameBox.Text.PadRight(16, '\0').ToCharArray());
                    bw.Write(playerX);
                    bw.Write(playerY);
                    bw.Write(catX);
                    bw.Write(catY);

                    List<byte> spkX = new List<byte>();
                    List<byte> spkY = new List<byte>();
                    List<byte> spkL = new List<byte>();

                    for (byte y = 0; y < 105; y++)
                    {
                        for (byte x = 0; x < 75; x++)
                        {
                            byte x0 = x;
                            byte len = 0;
                            while (x < 75 && mapS[y, x] != 0)
                            {
                                len++;
                                x++;
                            }
                            if (len > 0)
                            {
                                spkX.Add(x0);
                                spkY.Add(y);
                                spkL.Add(len);
                            }
                        }
                    }
                    if (spkX.Count > 100)
                    {
                        MessageBox.Show("Too many spikes");
                        return;
                    }
                    bw.Write((byte)spkX.Count);
                    for (int i = 0; i < spkX.Count; i++)
                    {
                        bw.Write(spkX[i]);
                        bw.Write(spkY[i]);
                        bw.Write(spkL[i]);
                    }


                    List<byte> trpX = new List<byte>();
                    List<byte> trpY = new List<byte>();
                    for (byte y = 0; y < 105; y++)
                    {
                        for (byte x = 0; x < 150; x++)
                        {
                            if (mapT[y, x] != 0)
                            {
                                trpX.Add((byte)(x + 1));
                                trpY.Add(y);
                            }
                        }
                    }
                    if (trpX.Count > 20)
                    {
                        MessageBox.Show("Too many trampolines");
                        return;
                    }
                    bw.Write((byte)trpX.Count);
                    for (int i = 0; i < trpX.Count; i++)
                    {
                        bw.Write(trpX[i]);
                        bw.Write(trpY[i]);
                    }


                    List<byte> actId = new List<byte>();
                    List<byte> actX = new List<byte>();
                    List<byte> actY = new List<byte>();
                    for (byte y = 0; y < 105; y++)
                    {
                        for (byte x = 0; x < 150; x++)
                        {
                            if (mapA[y, x] != 0)
                            {
                                actId.Add((byte)(mapA[y, x] - 1));
                                actX.Add(x);
                                actY.Add(y);
                            }
                        }
                    }

                    bw.Write((byte)actX.Count);
                    for (int i = 0; i < actX.Count; i++)
                    {
                        bw.Write(actId[i]);
                        bw.Write(actX[i]);
                        bw.Write(actY[i]);
                    }

                    List<byte> obsId = new List<byte>();
                    List<byte> obsO = new List<byte>();
                    List<byte> obsX = new List<byte>();
                    List<byte> obsY = new List<byte>();

                    for (byte y = 0; y < 105; y++)
                    {
                        for (byte x = 0; x < 75; x++)
                        {
                            if (mapO[y, x] != 0)
                            {
                                obsX.Add(x);
                                obsY.Add(y);
                                int val = mapO[y, x];
                                obsId.Add((byte)(val / 16));
                                int o = val % 16;
                                if (o == 1)
                                    o = 0x01;
                                else if (o == 2)
                                    o = 0x80;
                                else if (o == 3)
                                    o = 0x81;
                                else if (o == 4)
                                    o = 0x00;
                                else if (o == 5)
                                    o = 0x01 | 0x40;
                                else if (o == 6)
                                    o = 0x80 | 0x40;
                                else if (o == 7)
                                    o = 0x81 | 0x40;
                                else if (o == 8)
                                    o = 0x00 | 0x40;

                                obsO.Add((byte)o);
                            }
                        }
                    }
                    bw.Write((byte)obsX.Count);
                    for (int i = 0; i < obsX.Count; i++) 
                    {
                        bw.Write(obsId[i]);
                        bw.Write(obsO[i]);
                        bw.Write(obsX[i]);
                        bw.Write(obsY[i]);
                    }

                }
            }
        }       

        public static byte[] ToBytes<T>(T[,] array) where T : struct
        {
            var buffer = new byte[array.GetLength(0) * array.GetLength(1) * System.Runtime.InteropServices.Marshal.SizeOf(typeof(T))];
            Buffer.BlockCopy(array, 0, buffer, 0, buffer.Length);
            return buffer;
        }

        private void loadBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BinOfd.ShowDialog() == DialogResult.OK)
            {
                using(var br=new BinaryReader(File.OpenRead(BinOfd.FileName)))
                {
                    Buffer.BlockCopy(br.ReadBytes(mapX.Length), 0, mapX, 0, mapX.Length);

                    byte[] nm = br.ReadBytes(16);
                    lvlNameBox.Text = System.Text.Encoding.UTF8.GetString(nm);

                    playerX = br.ReadInt16();
                    playerY = br.ReadInt16();
                   
                   
                    catX = br.ReadUInt16();
                    catY = br.ReadUInt16();                                            

                    int spkcnt = br.ReadByte();                    
                    for(int i=0;i<spkcnt;i++)
                    {
                        int x = br.ReadByte();
                        int y = br.ReadByte();
                        int l = br.ReadByte();                        
                        for (int j = 0; j < l; j++) setMapS(x + j, y);
                    }
                
                    int trpcnt = br.ReadByte();
                    for (int i = 0; i < trpcnt; i++) 
                    {
                        int x = br.ReadByte();
                        int y = br.ReadByte();
                        x--;
                        Debug.WriteLine(x + " " + y);
                        setMapT(x / 2, y, x % 2);
                    }

                    int actcnt = br.ReadByte();
                    for (int i = 0; i < actcnt; i++)
                    {
                        int id = br.ReadByte();
                        int x = br.ReadByte();
                        int y = br.ReadByte();
                        for (int j = 0; j < 16 + id; j++)
                            setMapA(x / 2, y, x % 2, 1);
                    }

                    int obscnt = br.ReadByte();
                    for(int i=0;i<obscnt;i++)
                    {
                        int id = br.ReadByte();
                        int o = br.ReadByte();
                        int x = br.ReadByte();
                        int y = br.ReadByte();
                        if (o == 0x00) o = 4;
                        else if (o == 0x80) o = 2;
                        else if (o == 0x81) o = 3;
                        else if (o == 0x01) o = 1;
                        else if (o == 0x41) o = 5;
                        else if (o == 0xC0) o = 6;
                        else if (o == 0x40) o = 8;
                        else if (o == 0xC1) o = 7;
                        else o = 1;


                        mapO[y, x] = (byte)(id * 16 + o);
                        setObst(0, 0, 0, 0);
                    }                   

                }                

                for (int y = 0; y < 105; y++)
                {
                    for (int x = 0; x < 75; x++) 
                        setMapBlock(x, y, mapX[y, x]);
                }

            }
            tramp.Save("tramp.png");
            Workspace.Refresh();
        }
    }
}
