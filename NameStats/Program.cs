using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameStats
{
    internal class Program
    {
        static Dictionary<int, int> CharCodes = new Dictionary<int, int>();

        static void AddIdentical(int a, int b)
        {
            for (int i = a; i <= b; i++)
                CharCodes[i] = i;
        }
        static void AddIdentical(params int[] codes)
        {
            foreach(var c in codes)
                CharCodes[c] = c;
        }
        static void AddCode(int k, int v) => CharCodes[k] = v;   
        
        static void AddStartingFrom(int offset, params int[] codes)
        {
            foreach (var c in codes)
                CharCodes[c] = offset++;
        }

        static void AddStartingFrom(int offset, int a, int b)
        {
            for (int c = a; c <= b; c++)
                CharCodes[c] = offset++;
        }

        static void AddStartingFrom(int offset, string chars)
        {
            foreach (var c in chars) 
                CharCodes[c] = offset++;
        }

        static Font font = new Font("Arial Narrow", 8);
        public static Size MeasureString(string s, Font font)
        {
            using (var image = new Bitmap(16, 16)) 
            using (var g = Graphics.FromImage(image))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.PageUnit = GraphicsUnit.Pixel;

                g.DrawString(s, font, Brushes.White, 2, 1);

                List<int> xs = new List<int>();
                List<int> ys = new List<int>();

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++) 
                    {
                        var c = image.GetPixel(x, y);
                        if(c.R==255)
                        {
                            xs.Add(x);
                            ys.Add(y);
                        }
                    }
                }
                int w = xs.Count == 0 ? 0 : (xs.Max() - xs.Min() + 1);
                int h = ys.Count == 0 ? 0 : (ys.Max() - ys.Min() + 1);

                return new Size(w, h);
            }
        }

        public static byte[,] GetMatrix(string s, Font font)
        {
            byte[,] res = new byte[16, 16];
            using (var image = new Bitmap(16, 16))
            using (var g = Graphics.FromImage(image))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.PageUnit = GraphicsUnit.Pixel;

                g.DrawString(s, font, Brushes.White, 2, 1);

                List<int> xs = new List<int>();
                List<int> ys = new List<int>();

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        var c = image.GetPixel(x, y);
                        if (c.R == 255)
                        {
                            xs.Add(x);
                            ys.Add(y);
                        }
                    }
                }

                if (xs.Count == 0) return res;

                int xmin = xs.Min();
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        var c = image.GetPixel(x, y);
                        if (c.R == 255)
                        {
                            res[y, x - xmin + 1] = 1;
                        }
                    }
                }

                return res;
            }
        }

        static Dictionary<int, int> Specials = new Dictionary<int, int>
        {
            { 0xE000, 0x24B6},
            { 0xE001, 0x24B7},
            { 0xE002, 0x24CD},
            { 0xE003, 0x24CE},
            { 0xE004, 0x24C1},
            { 0xE005, 0x24C7},
            { 0xE006, 0x2795},
            { 0xE007, 0x23F0},
            // vvv emojis not working vvv
            { 0xE008, 0x01F603},
            { 0xE009, 0x01F620},
            { 0xE00A, 0x01F614},
            { 0xE00B, 0x01F611},
            { 0xE00C, 0x2600},
            { 0xE00D, 0x2601},
            { 0xE00E, 0x2614},
            { 0xE00F, 0x26C4},
            { 0xE010, 0x2757},
            { 0xE011, 0x2753},
            { 0xE012, 0x2709},
            { 0xE013, 0x01F4F1 },
            { 0xE015, 0x2660},
            { 0xE016, 0x2666},
            { 0xE017, 0x2665},
            { 0xE018, 0x2663},
            { 0xE019, 0x27A1},
            { 0xE01A, 0x2B05},
            { 0xE01B, 0x2B06},
            { 0xE01C, 0x2B07},
            { 0xE028, 0x2715},
        };

        static void Main(string[] args)
        {            
            AddIdentical(0x20, 0x7E);
            AddIdentical(0x00A1, 0x00A2, 0x00A3, 0x00A9, 0x00AE, 0x00B0, 0x00B1, 0x00BF, 0x00C0, 0x00C1, 0x00C2, 0x00C4, 0x00C7, 0x00C8, 0x00C9, 0x00CA, 0x00CB, 0x00CC, 0x00CD, 0x00CE, 0x00CF, 0x00D1, 0x00D2, 0x00D3, 0x00D4, 0x00D6, 0x00D7, 0x00D9, 0x00DA, 0x00DB, 0x00DC, 0x00DF, 0x00E0, 0x00E1, 0x00E2, 0x00E4, 0x00E7, 0x00E8, 0x00E9, 0x00EA, 0x00EB, 0x00EC, 0x00ED, 0x00EE, 0x00EF, 0x00F1, 0x00F2, 0x00F3, 0x00F4, 0x00F6, 0x00F7, 0x00F9, 0x00FA, 0x00FB, 0x00FC);            

            AddStartingFrom(0x120, Encoding.GetEncoding("ISO-8859-2").GetString(Enumerable.Range(0xA0, 0x100 - 0xA0).Select(_ => (byte)_).ToArray()));
            AddStartingFrom(0x180, Encoding.GetEncoding("windows-1251").GetString(Enumerable.Range(0x80, 0x100 - 0x80).Select(_ => (byte)_).ToArray()));            

            CharCodes = CharCodes.OrderBy(_ => _.Key).ToDictionary(_ => _.Key, _ => _.Value);

            foreach (var kv in CharCodes)
            {
                Console.WriteLine($"{kv.Key:X4} : {kv.Value:X3}");
            }
            Console.ReadLine();

            int[] table=new int[512];
            foreach (var kv in CharCodes) 
            {
                if (table[kv.Value] != 0)
                    throw new ArgumentException($"Duplicate entry: {kv.Key:X4}, {table[kv.Value]:X4} ue the same offset {kv.Value:X3}");
                table[kv.Value] = kv.Key;
            }

            for(int i=0;i<32;i++)
            {
                if (i % 8 == 0)
                    Console.WriteLine("---------------------------------------");
                Console.Write($"{i:X2} | ");
                for (int j=0;j<16;j++)
                {
                    Console.Write($"{table[16 * i + j]:X4}  ");
                }
                Console.WriteLine();                
            }

            string str = "";
            for(int i=0;i<512;i++)
            {
                if (table[i] == 0) continue;
                str += char.ConvertFromUtf32(table[i]);
                var sz = MeasureString(char.ConvertFromUtf32(table[i]), font);
                Console.WriteLine($"{i:X3} : {sz}");
            }
            /*var bmp = new Bitmap(8*512, 16);
            using (var g = Graphics.FromImage(bmp))
            {                
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.PageUnit = GraphicsUnit.Pixel;
                g.DrawString(str, font, Brushes.Black, 0, 2);
            }            
            bmp.Save("res.png");*/

            var bmp = new Bitmap(16, 16 * 512);            
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.FillRectangle(Brushes.Yellow, 0, 0, 8, 16*512);
                for(int i=0;i<512;i++)
                {
                    if (table[i] == 0) continue;
                    string c = char.ConvertFromUtf32(table[i]);
                    var f2 = font;
                    float sz = 8;
                    while(MeasureString(c, f2).Width>=8)
                    {
                        sz -= 0.1f;
                        f2 = new Font("Arial Narrow", sz, GraphicsUnit.Pixel);
                    }
                    
                    var mat = GetMatrix(c, f2);
                    for(int y=0;y<16;y++)
                    {
                        for(int x=0;x<16;x++)
                        {
                            if (mat[y, x] == 1)
                                bmp.SetPixel(x, 16 * i + y, Color.Black);
                        }
                    }
                }
            }
            bmp.Save("res2.png");


            /*var chars = Directory.GetFiles(@"D:\Software\Emulators\DeSmuMe\R4wood\flipnotes23")
                .Select(f =>
                {
                    var bytes = File.ReadAllBytes(f).Skip(0x14).Take(66).ToArray();
                    var hwords = bytes.Select((b, i) => (b, i / 2)).GroupBy(_ => _.Item2)
                        .Select(l => l.ToList()).Select(l => (ushort)(l[0].b + 256 * l[1].b)).ToArray();
                    return hwords;
                })
                .SelectMany(_ => _)
                .Distinct()
                .OrderBy(_ => _)
                .ToList();
            Console.WriteLine(string.Join("\n", chars.Select(_ => _.ToString("X4") + " "
            + Char.ConvertFromUtf32(_))));
            Console.WriteLine(chars.Count);

            Directory.GetFiles(@"D:\Software\Emulators\DeSmuMe\R4wood\flipnotes23")
               .Select(f =>
               {
                   var bytes = File.ReadAllBytes(f).Skip(0x14).Take(66).ToArray();
                   var hwords = bytes.Select((b, i) => (b, i / 2)).GroupBy(_ => _.Item2)
                       .Select(l => l.ToList()).Select(l => (ushort)(l[0].b + 256 * l[1].b)).ToArray();
                   return (f, hwords);
               }).Where(p => p.hwords.Any(h => h / 256 == 0x20))
               .ToList()
               .ForEach(_=>Console.WriteLine(_.f));
            */


            Console.ReadLine();
        }
    }
}
