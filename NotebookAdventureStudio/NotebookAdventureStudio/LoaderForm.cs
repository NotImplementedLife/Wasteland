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

namespace NotebookAdventureStudio
{
    public partial class LoaderForm : Form
    {
        public LoaderForm()
        {
            InitializeComponent();
        }

        private void LoadGfxButton_Click(object sender, EventArgs e)
        {
            if(GfxDialog.ShowDialog()==DialogResult.OK)
            {
                string png_file = GfxDialog.FileName;
                string dat_file = Directory.GetParent(Path.GetDirectoryName(png_file)).FullName;
                dat_file = Path.Combine(dat_file, "data", Path.GetFileNameWithoutExtension(png_file) + ".bin");

                GfxPathBox.Text = png_file;

                if (File.Exists(dat_file))
                {
                    DataPathBox.Text = dat_file;
                }
            }
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            if (DataDialog.ShowDialog() == DialogResult.OK)
            {
                DataPathBox.Text = DataDialog.FileName;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {            
            Hide();
            var editor = new EditorForm(GfxPathBox.Text, DataPathBox.Text);
            if (editor != null && !editor.IsDisposed) 
                editor.ShowDialog();
            Show();
        }
    }
}
