using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotebookAdventureStudio.Controls;

namespace NotebookAdventureStudio.Data
{
    public class Entity
    {
        public Panel Workspace;
        public Control Control;

        public int X, Y, Width, Height;
        public int AX, AY;

        public Entity(Panel workspace, Control control, int x, int y, int w, int h, int ax, int ay)
        {
            Workspace = workspace;
            Control = control;
            Control.Tag = this;

            AX = ax;
            AY = ay;

            X = x;
            Y = y;

            Control.Left = X - Width * AX / 255;
            Control.Top = Y - Height * AY / 255;
            Control.Width = Width = w;
            Control.Height = Height = h;
            Control.BringToFront();

            Workspace.Controls[0].Controls.Add(Control);

            if(Control is Spikes)
            {
                var ctm = new ContextMenu();                
                var rem_tsi = new MenuItem() { Text = "Remove" };
                ctm.MenuItems.Add(rem_tsi);
                Control.ContextMenu = ctm;
            }
        }

        public void ZoomControl(int zoom)
        {
            Control.Left = (X - Width * AX / 255) * zoom;
            Control.Top = (Y - Height * AY / 255) * zoom;
            Control.Width = Width * zoom;
            Control.Height = Height * zoom;
        }


        public void updatePos(int scrX, int scrY, int zoom)
        {
            X = scrX;
            Y = scrY;

            Control.Left = (X - Width * AX / 255) * zoom;
            Control.Top = (Y - Height * AY / 255) * zoom;          
        }
    }    
}
