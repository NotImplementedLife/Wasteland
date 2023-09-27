using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            Viewer, new object[] { true });

            Generate();
        }

        int width;
        int height;
        int[,] tiles;
        Random rand = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            Generate();
        }

        class Grid3
        {
            public List<Point> Points = new List<Point>();
            public byte Value;
            public List<Point> CanBeOrNot = new List<Point>();
        }

        List<Grid3> grids = new List<Grid3>
        {
            new Grid3
            {
                Value = 2,
                Points = new List<Point>
                {
                    new Point(-1,0),
                    new Point(0,-1)
                },
                CanBeOrNot = new List<Point>
                {
                    new Point(-1, -1),
                    new Point(-1, 1),
                    new Point(1, -1)
                }
            },           

            new Grid3
            {
                Value = 3,
                Points = new List<Point>
                {
                    new Point(1,0),
                    new Point(0,-1),
                },
                CanBeOrNot = new List<Point>
                {
                    new Point(-1, -1),
                    new Point(1, 1),
                    new Point(1, -1)
                }
            },           

            new Grid3
            {
                Value = 4,
                Points = new List<Point>
                {
                    new Point(-1,0),
                    new Point(0,1),
                },
                CanBeOrNot = new List<Point>
                {
                    new Point(-1, -1),
                    new Point(1, 1),
                    new Point(-1, 1)
                }
            },            

            new Grid3
            {
                Value = 5,
                Points = new List<Point>
                {
                    new Point(1,0),
                    new Point(0,1),
                },
                CanBeOrNot = new List<Point>
                {
                    new Point(1, -1),
                    new Point(1, 1),
                    new Point(-1, 1)
                }
            },
            new Grid3
            {
                Value = 5,
                Points = new List<Point>
                {
                    new Point(1,0),
                    new Point(0,1),
                    new Point(1,1),
                }
            },

            new Grid3
            {
                Value = 5,
                Points = new List<Point>
                {
                    new Point(1,0),
                    new Point(0,1),
                    new Point(1,1),
                    new Point(1,-1),
                    new Point(-1,1),
                }
            },            

        };


        //List<>

        byte[,] converted()
        {
            byte[,] data = new byte[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tiles[y, x] >= Trackbar.Value)
                    {
                        data[y, x] = 1;
                    }
                }
            }

            for (int y = 1; y < height-1; y++)
            {
                for (int x = 1; x < width-1; x++)
                {
                    if (data[y,x]==1)
                    {
                        List<Point> pts = new List<Point>();

                        foreach (var grd in grids) 
                        {
                            bool ok = true;
                            int cnt = 0;
                            for (int dy = -1; dy <= 1 && ok; dy++)
                            {
                                for (int dx = -1; dx <= 1 && ok; dx++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    if(data[y + dy, x + dx] > 0)
                                    {
                                        if(!grd.Points.Contains(new Point(dx,dy)))
                                        {
                                            if (!grd.CanBeOrNot.Contains(new Point(dx, dy)))
                                            {
                                                ok = false; break;
                                            }
                                            else continue;
                                        }
                                        cnt++;
                                    }                                    
                                }
                            }
                            if(ok && cnt==grd.Points.Count)
                            {
                                data[y, x] = grd.Value;
                                break;
                            }
                        }
                       

                    }
                }
            }

            return data;
        }

        Point Start = new Point(-1, -1);
        Point Finish = new Point(-1, -1);

        void Generate()
        {            
            seed = new Random().Next();
            width = 100;//64 + rand.Next(64);
            height = 500;// 64 + rand.Next(64);
            tiles = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                tiles[y, 0] = tiles[y, width - 1] = 1024;
            }

            for (int x = 0; x < width; x++)
            {
                tiles[0, x] = tiles[height - 1, x] = 1024;
            }

            int cnt = width * height / 6;
            int fcnt = cnt + rand.Next(cnt);
            for(int i=0;i<fcnt;i++)
            {
                int x = rand.Next(0,width);
                int y = rand.Next(0,height);
                tiles[y, x] = rand.Next(1024);
            }

            for (int k = 0; k < 10; k++)
            {
                tiles[0, 0] = (tiles[0, 1] + tiles[1, 0]) / 2;
                tiles[0, width - 1] = (tiles[0, width - 2] + tiles[1, width - 1]) / 2;
                tiles[height - 1, 0] = (tiles[height - 2, 0] + tiles[height - 1, 1]) / 2;
                tiles[height - 1, width - 1] = (tiles[height - 2, width - 1] + tiles[height - 1, width - 2]) / 2;

                for (int x = 1; x < width - 1; x++)
                {
                    tiles[0, x] = (tiles[1, x] + tiles[0, x-1] + tiles[0, x + 1]) / 3;
                    tiles[height-1, x] = (tiles[height - 2, x] + tiles[height - 1, x-1] + tiles[height - 1, x + 1]) / 3;
                }

                for(int y=1;y<height-1;y++)
                {
                    tiles[y,0] = (tiles[y, 1] + tiles[y-1, 0] + tiles[y+1,0]) / 3;
                    tiles[y, width - 1] = (tiles[y, width - 2] + tiles[y-1, width - 1] + tiles[y+1,width - 1]) / 3;
                }

                for(int y=1;y<height-1;y++)
                {
                    for (int x = 1; x < width - 1; x++) 
                    {
                        tiles[y, x] = (tiles[y - 1, x] + tiles[y + 1, x] + tiles[y, x - 1] + tiles[y, x + 1]) / 4;
                    }
                }
            }

            for (int y = 0; y < height; y++)
            {
                tiles[y, 0] = tiles[y, width - 1] = 256;
            }

            for (int x = 0; x < width; x++)
            {
                tiles[0, x] = tiles[height - 1, x] = 256;
            }


            /*for(int y=0;y<height;y++)
            {
                tiles[y, 0] = rand.Next(256) - 128;
            }
            for(int x=1;x<width;x++)
            {
                tiles[0, x] = rand.Next(256) - 128;
            }

            for(int y=1;y<height;y++)
            {
                for(int x=1;x<width;x++)
                {
                    int a = 1+rand.Next(7);
                    int b = 1+rand.Next(7);
                    tiles[y, x] = (a*tiles[y - 1, x] + b*tiles[y, x - 1]) / (a+b) + (rand.Next(128) - 64);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tiles[y, x] > 0) tiles[y, x] = tiles[y, x];//1;
                    else tiles[y, x] = 0;
                }
            }*/


            int min = tiles[0, 0];
            int max = tiles[0, 0];
            for(int y=0;y<height;y++)
            {
                for(int x=0;x<width;x++)
                {
                    min = Math.Min(min, tiles[y, x]);
                    max = Math.Max(max, tiles[y, x]);
                }
            }
            Trackbar.Minimum = min;
            Trackbar.Maximum = max;
              
            Viewer.Size = new Size(4 * width, 4 * height);
            Trackbar.Value = (min + max) / 2;
            Viewer.Invalidate();
        }

        int seed = 1234;

        bool is_enemy_chunk(int x, int y)
        {
            x /= 16;y /= 16;
            return (x * seed + y + 1) % 17 == 10;
        }

        private void Viewer_Paint(object sender, PaintEventArgs e)
        {
            byte[,] ts = converted();
            e.Graphics.Clear(Color.White);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tiles[y, x] > 0)
                    {
                        var color = Color.FromArgb(255, Color.DodgerBlue);
                        if (tiles[y,x]<255)
                        {
                            color = Color.FromArgb(tiles[y, x], Color.DodgerBlue);
                        }
                        e.Graphics.FillRectangle(new SolidBrush(color), 4 * x, 4 * y, 4, 4);
                        if (ts[y, x] == 1) 
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), 4 * x, 4 * y, 4, 4);
                        }
                        else if (ts[y,x]==2)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                            Point[] pts = new Point[3]
                            {
                                new Point(4*x, 4*y),
                                new Point(4*x, 4*y+4),
                                new Point(4*x+4, 4*y),
                            };
                            e.Graphics.FillPolygon(brush, pts);
                        }
                        else if (ts[y, x] == 3)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                            Point[] pts = new Point[3]
                            {
                                new Point(4*x, 4*y),
                                new Point(4*x+4, 4*y),
                                new Point(4*x+4, 4*y+4),
                            };
                            e.Graphics.FillPolygon(brush, pts);
                        }
                        else if (ts[y,x]==4)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                            Point[] pts = new Point[3]
                            {
                                new Point(4*x, 4*y),
                                new Point(4*x, 4*y+3),
                                new Point(4*x+4, 4*y+4),
                            };
                            e.Graphics.FillPolygon(brush, pts);
                        }
                        else if (ts[y, x] == 5)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                            Point[] pts = new Point[3]
                            {
                                new Point(4*x+4, 4*y),
                                new Point(4*x, 4*y+3),
                                new Point(4*x+4, 4*y+4),
                            };
                            e.Graphics.FillPolygon(brush, pts);
                        }

                        else if (ts[y,x]>1)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), 4 * x, 4 * y, 4, 4);
                        }

                        if(is_enemy_chunk(x,y))
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 255, 255)), 4 * x, 4 * y, 4, 4);
                        }
                    }
                    
                }                
            }

            if (Start.X >= 0)
            {
                e.Graphics.FillEllipse(Brushes.Blue, Start.X / 2 - 3, Start.Y / 2 - 3, 6, 6);
            }

            if (Finish.X >= 0)
            {
                e.Graphics.FillEllipse(Brushes.Red, Finish.X / 2 - 3, Finish.Y / 2 - 3, 6, 6);
            }
        }

        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            Viewer.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(SFD.ShowDialog()==DialogResult.OK)
            {
                byte[,] conv = converted();
                byte[] data = new byte[width * height];
                for(int y=0;y<height;y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        data[y * width + x] = conv[y, x];
                        /*if (tiles[y,x]>=Trackbar.Value)
                        {
                            data[y * width + x] = 1;
                        } */                       
                    }
                }
                using (var stream = File.OpenWrite(SFD.FileName)) 
                {
                    using(var bw = new BinaryWriter(stream))
                    {
                        bw.Write(width);
                        bw.Write(height);
                        bw.Write(data);
                    }
                }
                var name = Path.GetFileNameWithoutExtension(SFD.FileName);
                var fname = Path.GetDirectoryName(SFD.FileName);
                fname = Path.Combine(fname, name + ".mapdata.h");
                File.WriteAllText(fname, $"#include \"{name}.maps.h\"\n\n" +
                    $"#define MAP_DATA_{name} cr_map({name}, {Start.X}, {Start.Y}, {Finish.X}, {Finish.Y})\n");
            }
        }

        private void Viewer_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X * 2;
            int y = e.Y * 2;
            if(e.Button==MouseButtons.Left)
            {
                Start = new Point(x, y);
                Viewer.Invalidate();
            }
            else
            {
                Finish = new Point(x, y);
                Viewer.Invalidate();
            }
        }
    }
}
