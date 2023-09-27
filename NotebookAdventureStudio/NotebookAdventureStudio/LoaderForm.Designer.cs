
namespace NotebookAdventureStudio
{
    partial class LoaderForm
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
            this.LoadGfxButton = new System.Windows.Forms.Button();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.GfxPathBox = new System.Windows.Forms.TextBox();
            this.DataPathBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.GfxDialog = new System.Windows.Forms.OpenFileDialog();
            this.DataDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadGfxButton
            // 
            this.LoadGfxButton.Location = new System.Drawing.Point(12, 12);
            this.LoadGfxButton.Name = "LoadGfxButton";
            this.LoadGfxButton.Size = new System.Drawing.Size(111, 23);
            this.LoadGfxButton.TabIndex = 0;
            this.LoadGfxButton.Text = "Load GFX";
            this.LoadGfxButton.UseVisualStyleBackColor = true;
            this.LoadGfxButton.Click += new System.EventHandler(this.LoadGfxButton_Click);
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(12, 41);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(111, 23);
            this.LoadDataButton.TabIndex = 1;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // GfxPathBox
            // 
            this.GfxPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GfxPathBox.Location = new System.Drawing.Point(129, 14);
            this.GfxPathBox.Name = "GfxPathBox";
            this.GfxPathBox.ReadOnly = true;
            this.GfxPathBox.Size = new System.Drawing.Size(351, 20);
            this.GfxPathBox.TabIndex = 2;
            this.GfxPathBox.Text = "/";
            // 
            // DataPathBox
            // 
            this.DataPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataPathBox.Location = new System.Drawing.Point(129, 40);
            this.DataPathBox.Name = "DataPathBox";
            this.DataPathBox.ReadOnly = true;
            this.DataPathBox.Size = new System.Drawing.Size(351, 20);
            this.DataPathBox.TabIndex = 3;
            this.DataPathBox.Text = "/";
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(405, 90);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start editing";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // GfxDialog
            // 
            this.GfxDialog.Filter = "PNG Files (*.png)|*.png";
            // 
            // DataDialog
            // 
            this.DataDialog.Filter = "Data files (*.bin)|*.bin";
            // 
            // LoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 125);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DataPathBox);
            this.Controls.Add(this.GfxPathBox);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.LoadGfxButton);
            this.Name = "LoaderForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadGfxButton;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.TextBox GfxPathBox;
        private System.Windows.Forms.TextBox DataPathBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.OpenFileDialog GfxDialog;
        private System.Windows.Forms.OpenFileDialog DataDialog;
    }
}

