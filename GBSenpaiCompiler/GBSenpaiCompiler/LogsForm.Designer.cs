namespace GBSenpaiCompiler
{
    partial class LogsForm
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
            this.Logs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Logs
            // 
            this.Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logs.Location = new System.Drawing.Point(0, 0);
            this.Logs.Multiline = true;
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logs.Size = new System.Drawing.Size(800, 450);
            this.Logs.TabIndex = 0;
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Logs);
            this.DoubleBuffered = true;
            this.Name = "LogsForm";
            this.Text = "LogsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Logs;
    }
}