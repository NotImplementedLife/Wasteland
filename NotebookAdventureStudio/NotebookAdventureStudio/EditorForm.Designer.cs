
namespace NotebookAdventureStudio
{
    partial class EditorForm
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
            this.components = new System.ComponentModel.Container();
            this.Workspace = new System.Windows.Forms.Panel();
            this.ZoomGroupBox = new System.Windows.Forms.GroupBox();
            this.Zoom4Button = new System.Windows.Forms.RadioButton();
            this.Zoom3Button = new System.Windows.Forms.RadioButton();
            this.Zoom2Button = new System.Windows.Forms.RadioButton();
            this.Zoom1Button = new System.Windows.Forms.RadioButton();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EditCatCoordLabel = new System.Windows.Forms.LinkLabel();
            this.EditPlayerCoordLabel = new System.Windows.Forms.LinkLabel();
            this.CatPosLabel = new System.Windows.Forms.Label();
            this.PlayerPosLabel = new System.Windows.Forms.Label();
            this.LevelNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentToolLabel = new System.Windows.Forms.Label();
            this.GfxPicture = new System.Windows.Forms.PictureBox();
            this.LevelCtxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spikesHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trmpolineHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obstacleHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activatorHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Workspace.SuspendLayout();
            this.ZoomGroupBox.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GfxPicture)).BeginInit();
            this.LevelCtxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Workspace
            // 
            this.Workspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Workspace.AutoScroll = true;
            this.Workspace.Controls.Add(this.GfxPicture);
            this.Workspace.Location = new System.Drawing.Point(12, 34);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(589, 404);
            this.Workspace.TabIndex = 0;
            // 
            // ZoomGroupBox
            // 
            this.ZoomGroupBox.Controls.Add(this.Zoom4Button);
            this.ZoomGroupBox.Controls.Add(this.Zoom3Button);
            this.ZoomGroupBox.Controls.Add(this.Zoom2Button);
            this.ZoomGroupBox.Controls.Add(this.Zoom1Button);
            this.ZoomGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ZoomGroupBox.Name = "ZoomGroupBox";
            this.ZoomGroupBox.Size = new System.Drawing.Size(177, 46);
            this.ZoomGroupBox.TabIndex = 2;
            this.ZoomGroupBox.TabStop = false;
            this.ZoomGroupBox.Text = "Zoom";
            // 
            // Zoom4Button
            // 
            this.Zoom4Button.AutoSize = true;
            this.Zoom4Button.Location = new System.Drawing.Point(132, 19);
            this.Zoom4Button.Name = "Zoom4Button";
            this.Zoom4Button.Size = new System.Drawing.Size(36, 17);
            this.Zoom4Button.TabIndex = 3;
            this.Zoom4Button.Text = "x4";
            this.Zoom4Button.UseVisualStyleBackColor = true;
            this.Zoom4Button.CheckedChanged += new System.EventHandler(this.ZoomButton_CheckedChanged);
            // 
            // Zoom3Button
            // 
            this.Zoom3Button.AutoSize = true;
            this.Zoom3Button.Location = new System.Drawing.Point(90, 19);
            this.Zoom3Button.Name = "Zoom3Button";
            this.Zoom3Button.Size = new System.Drawing.Size(36, 17);
            this.Zoom3Button.TabIndex = 2;
            this.Zoom3Button.Text = "x3";
            this.Zoom3Button.UseVisualStyleBackColor = true;
            this.Zoom3Button.CheckedChanged += new System.EventHandler(this.ZoomButton_CheckedChanged);
            // 
            // Zoom2Button
            // 
            this.Zoom2Button.AutoSize = true;
            this.Zoom2Button.Location = new System.Drawing.Point(48, 19);
            this.Zoom2Button.Name = "Zoom2Button";
            this.Zoom2Button.Size = new System.Drawing.Size(36, 17);
            this.Zoom2Button.TabIndex = 1;
            this.Zoom2Button.Text = "x2";
            this.Zoom2Button.UseVisualStyleBackColor = true;
            this.Zoom2Button.CheckedChanged += new System.EventHandler(this.ZoomButton_CheckedChanged);
            // 
            // Zoom1Button
            // 
            this.Zoom1Button.AutoSize = true;
            this.Zoom1Button.Checked = true;
            this.Zoom1Button.Location = new System.Drawing.Point(6, 19);
            this.Zoom1Button.Name = "Zoom1Button";
            this.Zoom1Button.Size = new System.Drawing.Size(36, 17);
            this.Zoom1Button.TabIndex = 0;
            this.Zoom1Button.TabStop = true;
            this.Zoom1Button.Text = "x1";
            this.Zoom1Button.UseVisualStyleBackColor = true;
            this.Zoom1Button.CheckedChanged += new System.EventHandler(this.ZoomButton_CheckedChanged);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlPanel.Controls.Add(this.CurrentToolLabel);
            this.ControlPanel.Controls.Add(this.label4);
            this.ControlPanel.Controls.Add(this.groupBox1);
            this.ControlPanel.Controls.Add(this.ZoomGroupBox);
            this.ControlPanel.Location = new System.Drawing.Point(607, 34);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(183, 404);
            this.ControlPanel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EditCatCoordLabel);
            this.groupBox1.Controls.Add(this.EditPlayerCoordLabel);
            this.groupBox1.Controls.Add(this.CatPosLabel);
            this.groupBox1.Controls.Add(this.PlayerPosLabel);
            this.groupBox1.Controls.Add(this.LevelNameBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level data";
            // 
            // EditCatCoordLabel
            // 
            this.EditCatCoordLabel.AutoSize = true;
            this.EditCatCoordLabel.Location = new System.Drawing.Point(143, 64);
            this.EditCatCoordLabel.Name = "EditCatCoordLabel";
            this.EditCatCoordLabel.Size = new System.Drawing.Size(25, 13);
            this.EditCatCoordLabel.TabIndex = 7;
            this.EditCatCoordLabel.TabStop = true;
            this.EditCatCoordLabel.Text = "Edit";
            this.EditCatCoordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EditCatCoordLabel_LinkClicked);
            // 
            // EditPlayerCoordLabel
            // 
            this.EditPlayerCoordLabel.AutoSize = true;
            this.EditPlayerCoordLabel.Location = new System.Drawing.Point(143, 42);
            this.EditPlayerCoordLabel.Name = "EditPlayerCoordLabel";
            this.EditPlayerCoordLabel.Size = new System.Drawing.Size(25, 13);
            this.EditPlayerCoordLabel.TabIndex = 6;
            this.EditPlayerCoordLabel.TabStop = true;
            this.EditPlayerCoordLabel.Text = "Edit";
            this.EditPlayerCoordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EditPlayerCoordLabel_LinkClicked);
            // 
            // CatPosLabel
            // 
            this.CatPosLabel.AutoSize = true;
            this.CatPosLabel.Location = new System.Drawing.Point(76, 64);
            this.CatPosLabel.Name = "CatPosLabel";
            this.CatPosLabel.Size = new System.Drawing.Size(22, 13);
            this.CatPosLabel.TabIndex = 5;
            this.CatPosLabel.Text = "0,0";
            // 
            // PlayerPosLabel
            // 
            this.PlayerPosLabel.AutoSize = true;
            this.PlayerPosLabel.Location = new System.Drawing.Point(76, 42);
            this.PlayerPosLabel.Name = "PlayerPosLabel";
            this.PlayerPosLabel.Size = new System.Drawing.Size(22, 13);
            this.PlayerPosLabel.TabIndex = 4;
            this.PlayerPosLabel.Text = "0,0";
            // 
            // LevelNameBox
            // 
            this.LevelNameBox.Location = new System.Drawing.Point(71, 19);
            this.LevelNameBox.Name = "LevelNameBox";
            this.LevelNameBox.Size = new System.Drawing.Size(100, 20);
            this.LevelNameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cat pos :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player pos :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current Tool :";
            // 
            // CurrentToolLabel
            // 
            this.CurrentToolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentToolLabel.AutoSize = true;
            this.CurrentToolLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentToolLabel.Location = new System.Drawing.Point(79, 388);
            this.CurrentToolLabel.Name = "CurrentToolLabel";
            this.CurrentToolLabel.Size = new System.Drawing.Size(39, 13);
            this.CurrentToolLabel.TabIndex = 5;
            this.CurrentToolLabel.Text = "(None)";
            // 
            // GfxPicture
            // 
            this.GfxPicture.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GfxPicture.ContextMenuStrip = this.LevelCtxMenu;
            this.GfxPicture.Location = new System.Drawing.Point(0, 0);
            this.GfxPicture.Name = "GfxPicture";
            this.GfxPicture.Size = new System.Drawing.Size(600, 840);
            this.GfxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GfxPicture.TabIndex = 0;
            this.GfxPicture.TabStop = false;
            this.GfxPicture.Click += new System.EventHandler(this.GfxPicture_Click);
            this.GfxPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GfxPicture_MouseDown);
            this.GfxPicture.MouseHover += new System.EventHandler(this.GfxPicture_MouseHover);
            // 
            // LevelCtxMenu
            // 
            this.LevelCtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spikesHereToolStripMenuItem,
            this.trmpolineHereToolStripMenuItem,
            this.obstacleHereToolStripMenuItem,
            this.activatorHereToolStripMenuItem});
            this.LevelCtxMenu.Name = "LevelCtxMenu";
            this.LevelCtxMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // spikesHereToolStripMenuItem
            // 
            this.spikesHereToolStripMenuItem.Name = "spikesHereToolStripMenuItem";
            this.spikesHereToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spikesHereToolStripMenuItem.Text = "Spikes here";
            this.spikesHereToolStripMenuItem.Click += new System.EventHandler(this.spikesHereToolStripMenuItem_Click);
            // 
            // trmpolineHereToolStripMenuItem
            // 
            this.trmpolineHereToolStripMenuItem.Name = "trmpolineHereToolStripMenuItem";
            this.trmpolineHereToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.trmpolineHereToolStripMenuItem.Text = "Trmpoline here";
            // 
            // obstacleHereToolStripMenuItem
            // 
            this.obstacleHereToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.obstacleHereToolStripMenuItem.Name = "obstacleHereToolStripMenuItem";
            this.obstacleHereToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.obstacleHereToolStripMenuItem.Text = "Obstacle here";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            // 
            // activatorHereToolStripMenuItem
            // 
            this.activatorHereToolStripMenuItem.Name = "activatorHereToolStripMenuItem";
            this.activatorHereToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.activatorHereToolStripMenuItem.Text = "Activator here";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.Workspace);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.Workspace.ResumeLayout(false);
            this.ZoomGroupBox.ResumeLayout(false);
            this.ZoomGroupBox.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GfxPicture)).EndInit();
            this.LevelCtxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Workspace;
        private System.Windows.Forms.PictureBox GfxPicture;
        private System.Windows.Forms.GroupBox ZoomGroupBox;
        private System.Windows.Forms.RadioButton Zoom4Button;
        private System.Windows.Forms.RadioButton Zoom3Button;
        private System.Windows.Forms.RadioButton Zoom2Button;
        private System.Windows.Forms.RadioButton Zoom1Button;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LevelNameBox;
        private System.Windows.Forms.LinkLabel EditCatCoordLabel;
        private System.Windows.Forms.LinkLabel EditPlayerCoordLabel;
        private System.Windows.Forms.Label CatPosLabel;
        private System.Windows.Forms.Label PlayerPosLabel;
        private System.Windows.Forms.Label CurrentToolLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip LevelCtxMenu;
        private System.Windows.Forms.ToolStripMenuItem spikesHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trmpolineHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obstacleHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activatorHereToolStripMenuItem;
    }
}