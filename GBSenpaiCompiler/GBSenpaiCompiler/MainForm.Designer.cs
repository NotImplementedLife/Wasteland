namespace GBSenpaiCompiler
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
            this.label1 = new System.Windows.Forms.Label();
            this.ProjPath = new System.Windows.Forms.TextBox();
            this.ProjPathSel = new System.Windows.Forms.Button();
            this.CompileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project path";
            // 
            // ProjPath
            // 
            this.ProjPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjPath.Location = new System.Drawing.Point(82, 6);
            this.ProjPath.Name = "ProjPath";
            this.ProjPath.Size = new System.Drawing.Size(395, 20);
            this.ProjPath.TabIndex = 1;
            // 
            // ProjPathSel
            // 
            this.ProjPathSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjPathSel.Location = new System.Drawing.Point(483, 4);
            this.ProjPathSel.Name = "ProjPathSel";
            this.ProjPathSel.Size = new System.Drawing.Size(26, 23);
            this.ProjPathSel.TabIndex = 2;
            this.ProjPathSel.Text = "...";
            this.ProjPathSel.UseVisualStyleBackColor = true;
            this.ProjPathSel.Click += new System.EventHandler(this.ProjPathSel_Click);
            // 
            // CompileBtn
            // 
            this.CompileBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CompileBtn.Location = new System.Drawing.Point(216, 36);
            this.CompileBtn.Name = "CompileBtn";
            this.CompileBtn.Size = new System.Drawing.Size(75, 23);
            this.CompileBtn.TabIndex = 3;
            this.CompileBtn.Text = "Create GBA";
            this.CompileBtn.UseVisualStyleBackColor = true;
            this.CompileBtn.Click += new System.EventHandler(this.CompileBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 71);
            this.Controls.Add(this.CompileBtn);
            this.Controls.Add(this.ProjPathSel);
            this.Controls.Add(this.ProjPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "GBSenpaiCompiler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProjPath;
        private System.Windows.Forms.Button ProjPathSel;
        private System.Windows.Forms.Button CompileBtn;
    }
}

