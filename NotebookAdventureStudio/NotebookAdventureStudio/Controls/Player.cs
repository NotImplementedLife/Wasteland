using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookAdventureStudio.Controls
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.DrawImage(Properties.Resources.player, 0, 0, Width, Height);
        }     
    }
}
