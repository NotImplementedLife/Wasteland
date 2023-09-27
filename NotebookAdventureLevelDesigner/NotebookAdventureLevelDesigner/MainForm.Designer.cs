
namespace NotebookAdventureLevelDesigner
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapPicOfd = new System.Windows.Forms.OpenFileDialog();
            this.Container = new System.Windows.Forms.Panel();
            this.Workspace = new System.Windows.Forms.Panel();
            this.GreenBtn = new System.Windows.Forms.Button();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.ActivatorBtn = new System.Windows.Forms.Button();
            this.ObstacleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvlNameBox = new System.Windows.Forms.TextBox();
            this.TrampBtn = new System.Windows.Forms.Button();
            this.CatBtn = new System.Windows.Forms.Button();
            this.PlayerBtn = new System.Windows.Forms.Button();
            this.SpikesBtn = new System.Windows.Forms.Button();
            this.BlueBtn = new System.Windows.Forms.Button();
            this.RedBtn = new System.Windows.Forms.Button();
            this.MapBinSfd = new System.Windows.Forms.SaveFileDialog();
            this.BinOfd = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu.SuspendLayout();
            this.Container.SuspendLayout();
            this.ToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(740, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadBlocksToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadBlocksToolStripMenuItem
            // 
            this.loadBlocksToolStripMenuItem.Name = "loadBlocksToolStripMenuItem";
            this.loadBlocksToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadBlocksToolStripMenuItem.Text = "Load Blocks";
            this.loadBlocksToolStripMenuItem.Click += new System.EventHandler(this.loadBlocksToolStripMenuItem_Click);
            // 
            // MapPicOfd
            // 
            this.MapPicOfd.FileName = "MapPicOfdFilter";
            this.MapPicOfd.Filter = "PNG files (*.png)|*.png";
            // 
            // Container
            // 
            this.Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container.AutoScroll = true;
            this.Container.Controls.Add(this.Workspace);
            this.Container.Location = new System.Drawing.Point(12, 32);
            this.Container.MaximumSize = new System.Drawing.Size(650, 840);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(620, 556);
            this.Container.TabIndex = 1;
            this.Container.Resize += new System.EventHandler(this.Container_Resize);
            // 
            // Workspace
            // 
            this.Workspace.BackColor = System.Drawing.Color.Violet;
            this.Workspace.Location = new System.Drawing.Point(3, 3);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(600, 840);
            this.Workspace.TabIndex = 2;
            this.Workspace.Click += new System.EventHandler(this.Workspace_Click);
            this.Workspace.Paint += new System.Windows.Forms.PaintEventHandler(this.Workspace_Paint);
            this.Workspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Workspace_MouseDown);
            this.Workspace.MouseHover += new System.EventHandler(this.Workspace_MouseHover);
            this.Workspace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Workspace_MouseMove);
            this.Workspace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Workspace_MouseUp);
            // 
            // GreenBtn
            // 
            this.GreenBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.GreenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GreenBtn.Location = new System.Drawing.Point(3, 3);
            this.GreenBtn.Name = "GreenBtn";
            this.GreenBtn.Size = new System.Drawing.Size(24, 24);
            this.GreenBtn.TabIndex = 2;
            this.GreenBtn.UseVisualStyleBackColor = false;
            this.GreenBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsPanel.Controls.Add(this.ActivatorBtn);
            this.ToolsPanel.Controls.Add(this.ObstacleBtn);
            this.ToolsPanel.Controls.Add(this.label1);
            this.ToolsPanel.Controls.Add(this.lvlNameBox);
            this.ToolsPanel.Controls.Add(this.TrampBtn);
            this.ToolsPanel.Controls.Add(this.CatBtn);
            this.ToolsPanel.Controls.Add(this.PlayerBtn);
            this.ToolsPanel.Controls.Add(this.SpikesBtn);
            this.ToolsPanel.Controls.Add(this.BlueBtn);
            this.ToolsPanel.Controls.Add(this.RedBtn);
            this.ToolsPanel.Controls.Add(this.GreenBtn);
            this.ToolsPanel.Location = new System.Drawing.Point(638, 32);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(90, 556);
            this.ToolsPanel.TabIndex = 3;
            // 
            // ActivatorBtn
            // 
            this.ActivatorBtn.BackColor = System.Drawing.Color.Azure;
            this.ActivatorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivatorBtn.Location = new System.Drawing.Point(63, 63);
            this.ActivatorBtn.Name = "ActivatorBtn";
            this.ActivatorBtn.Size = new System.Drawing.Size(24, 24);
            this.ActivatorBtn.TabIndex = 14;
            this.ActivatorBtn.Text = "A";
            this.ActivatorBtn.UseVisualStyleBackColor = false;
            this.ActivatorBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // ObstacleBtn
            // 
            this.ObstacleBtn.BackColor = System.Drawing.Color.Azure;
            this.ObstacleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObstacleBtn.Location = new System.Drawing.Point(3, 63);
            this.ObstacleBtn.Name = "ObstacleBtn";
            this.ObstacleBtn.Size = new System.Drawing.Size(24, 24);
            this.ObstacleBtn.TabIndex = 13;
            this.ObstacleBtn.Text = "O";
            this.ObstacleBtn.UseVisualStyleBackColor = false;
            this.ObstacleBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Level name:";
            // 
            // lvlNameBox
            // 
            this.lvlNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lvlNameBox.Location = new System.Drawing.Point(3, 151);
            this.lvlNameBox.MaxLength = 15;
            this.lvlNameBox.Name = "lvlNameBox";
            this.lvlNameBox.Size = new System.Drawing.Size(84, 18);
            this.lvlNameBox.TabIndex = 11;
            // 
            // TrampBtn
            // 
            this.TrampBtn.BackColor = System.Drawing.Color.Azure;
            this.TrampBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrampBtn.Location = new System.Drawing.Point(63, 33);
            this.TrampBtn.Name = "TrampBtn";
            this.TrampBtn.Size = new System.Drawing.Size(24, 24);
            this.TrampBtn.TabIndex = 10;
            this.TrampBtn.Text = "T";
            this.TrampBtn.UseVisualStyleBackColor = false;
            this.TrampBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // CatBtn
            // 
            this.CatBtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.CatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CatBtn.Location = new System.Drawing.Point(33, 93);
            this.CatBtn.Name = "CatBtn";
            this.CatBtn.Size = new System.Drawing.Size(24, 24);
            this.CatBtn.TabIndex = 8;
            this.CatBtn.Text = "C";
            this.CatBtn.UseVisualStyleBackColor = false;
            this.CatBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // PlayerBtn
            // 
            this.PlayerBtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.PlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayerBtn.Location = new System.Drawing.Point(33, 63);
            this.PlayerBtn.Name = "PlayerBtn";
            this.PlayerBtn.Size = new System.Drawing.Size(24, 24);
            this.PlayerBtn.TabIndex = 6;
            this.PlayerBtn.Text = "P";
            this.PlayerBtn.UseVisualStyleBackColor = false;
            this.PlayerBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // SpikesBtn
            // 
            this.SpikesBtn.BackColor = System.Drawing.Color.Azure;
            this.SpikesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpikesBtn.Location = new System.Drawing.Point(3, 33);
            this.SpikesBtn.Name = "SpikesBtn";
            this.SpikesBtn.Size = new System.Drawing.Size(24, 24);
            this.SpikesBtn.TabIndex = 5;
            this.SpikesBtn.Text = "S";
            this.SpikesBtn.UseVisualStyleBackColor = false;
            this.SpikesBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // BlueBtn
            // 
            this.BlueBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.BlueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueBtn.Location = new System.Drawing.Point(63, 3);
            this.BlueBtn.Name = "BlueBtn";
            this.BlueBtn.Size = new System.Drawing.Size(24, 24);
            this.BlueBtn.TabIndex = 4;
            this.BlueBtn.UseVisualStyleBackColor = false;
            this.BlueBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // RedBtn
            // 
            this.RedBtn.BackColor = System.Drawing.Color.Red;
            this.RedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedBtn.Location = new System.Drawing.Point(33, 3);
            this.RedBtn.Name = "RedBtn";
            this.RedBtn.Size = new System.Drawing.Size(24, 24);
            this.RedBtn.TabIndex = 3;
            this.RedBtn.UseVisualStyleBackColor = false;
            this.RedBtn.Click += new System.EventHandler(this.GreenBtn_Click);
            // 
            // MapBinSfd
            // 
            this.MapBinSfd.Filter = "Map Data (*.bin) | *.bin";
            // 
            // BinOfd
            // 
            this.BinOfd.Filter = "Map Data (*.bin)|*.bin";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(740, 600);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Container.ResumeLayout(false);
            this.ToolsPanel.ResumeLayout(false);
            this.ToolsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog MapPicOfd;
        private System.Windows.Forms.Panel Container;
        private System.Windows.Forms.Panel Workspace;
        private System.Windows.Forms.Button GreenBtn;
        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.Button RedBtn;
        private System.Windows.Forms.Button BlueBtn;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog MapBinSfd;
        private System.Windows.Forms.ToolStripMenuItem loadBlocksToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog BinOfd;
        private System.Windows.Forms.Button SpikesBtn;
        private System.Windows.Forms.Button PlayerBtn;
        private System.Windows.Forms.Button CatBtn;
        private System.Windows.Forms.Button TrampBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lvlNameBox;
        private System.Windows.Forms.Button ObstacleBtn;
        private System.Windows.Forms.Button ActivatorBtn;
    }
}

