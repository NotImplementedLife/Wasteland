namespace IsoTilesBuild
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MapView = new IsoTilesBuild.Controls.MapMaker();
            this.TilesetTabs = new System.Windows.Forms.TabControl();
            this.Land = new System.Windows.Forms.TabPage();
            this.LandTileSelector = new IsoTilesBuild.Controls.TileSelector();
            this.TransparentTiles = new System.Windows.Forms.TabPage();
            this.TransparentTileSelector = new IsoTilesBuild.Controls.TileSelector();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CropsTileSelector = new IsoTilesBuild.Controls.TileSelector();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TilesetTabs.SuspendLayout();
            this.Land.SuspendLayout();
            this.TransparentTiles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SFD
            // 
            this.SFD.Filter = "PNG Images (*.png)|*.png";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.MapView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TilesetTabs);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 1;
            // 
            // MapView
            // 
            this.MapView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MapView.Location = new System.Drawing.Point(0, 0);
            this.MapView.Name = "MapView";
            this.MapView.ShowGrid = true;
            this.MapView.Size = new System.Drawing.Size(494, 450);
            this.MapView.TabIndex = 0;
            this.MapView.Tile = null;
            // 
            // TilesetTabs
            // 
            this.TilesetTabs.Controls.Add(this.Land);
            this.TilesetTabs.Controls.Add(this.TransparentTiles);
            this.TilesetTabs.Controls.Add(this.tabPage1);
            this.TilesetTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilesetTabs.Location = new System.Drawing.Point(0, 0);
            this.TilesetTabs.Name = "TilesetTabs";
            this.TilesetTabs.SelectedIndex = 0;
            this.TilesetTabs.Size = new System.Drawing.Size(302, 450);
            this.TilesetTabs.TabIndex = 0;
            // 
            // Land
            // 
            this.Land.AutoScroll = true;
            this.Land.Controls.Add(this.LandTileSelector);
            this.Land.Location = new System.Drawing.Point(4, 22);
            this.Land.Name = "Land";
            this.Land.Padding = new System.Windows.Forms.Padding(3);
            this.Land.Size = new System.Drawing.Size(294, 424);
            this.Land.TabIndex = 0;
            this.Land.Text = "Land";
            this.Land.UseVisualStyleBackColor = true;
            // 
            // LandTileSelector
            // 
            this.LandTileSelector.BackColor = System.Drawing.Color.Transparent;
            this.LandTileSelector.Location = new System.Drawing.Point(6, 3);
            this.LandTileSelector.Name = "LandTileSelector";
            this.LandTileSelector.Size = new System.Drawing.Size(308, 232);
            this.LandTileSelector.Source = null;
            this.LandTileSelector.TabIndex = 0;
            this.LandTileSelector.SelectedTileChanged += new IsoTilesBuild.Controls.TileSelector.OnSelectedTileChanged(this.SelectedTileChanged);
            // 
            // TransparentTiles
            // 
            this.TransparentTiles.Controls.Add(this.TransparentTileSelector);
            this.TransparentTiles.Location = new System.Drawing.Point(4, 22);
            this.TransparentTiles.Name = "TransparentTiles";
            this.TransparentTiles.Padding = new System.Windows.Forms.Padding(3);
            this.TransparentTiles.Size = new System.Drawing.Size(294, 424);
            this.TransparentTiles.TabIndex = 1;
            this.TransparentTiles.Text = "Transparent Tiles";
            this.TransparentTiles.UseVisualStyleBackColor = true;
            // 
            // TransparentTileSelector
            // 
            this.TransparentTileSelector.BackColor = System.Drawing.Color.Transparent;
            this.TransparentTileSelector.Location = new System.Drawing.Point(-1, 0);
            this.TransparentTileSelector.Name = "TransparentTileSelector";
            this.TransparentTileSelector.Size = new System.Drawing.Size(308, 232);
            this.TransparentTileSelector.Source = null;
            this.TransparentTileSelector.TabIndex = 1;
            this.TransparentTileSelector.SelectedTileChanged += new IsoTilesBuild.Controls.TileSelector.OnSelectedTileChanged(this.SelectedTileChanged);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            this.OFD.Filter = "PNG Images (*.png)|*.png";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CropsTileSelector);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(294, 424);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Crops";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CropsTileSelector
            // 
            this.CropsTileSelector.Location = new System.Drawing.Point(0, 0);
            this.CropsTileSelector.Name = "CropsTileSelector";
            this.CropsTileSelector.Size = new System.Drawing.Size(308, 232);
            this.CropsTileSelector.Source = null;
            this.CropsTileSelector.TabIndex = 0;
            this.CropsTileSelector.SelectedTileChanged += new IsoTilesBuild.Controls.TileSelector.OnSelectedTileChanged(this.SelectedTileChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TilesetTabs.ResumeLayout(false);
            this.Land.ResumeLayout(false);
            this.TransparentTiles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TilesetTabs;
        private System.Windows.Forms.TabPage Land;
        private Controls.TileSelector LandTileSelector;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.MapMaker MapView;
        private System.Windows.Forms.TabPage TransparentTiles;
        private Controls.TileSelector TransparentTileSelector;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.TileSelector CropsTileSelector;
    }
}

