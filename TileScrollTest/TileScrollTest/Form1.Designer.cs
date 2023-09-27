namespace TileScrollTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.VramViewer = new System.Windows.Forms.Panel();
            this.ScrollCoordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VramViewer
            // 
            this.VramViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.VramViewer, "VramViewer");
            this.VramViewer.Name = "VramViewer";
            this.VramViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.VramViewer_Paint);
            // 
            // ScrollCoordLabel
            // 
            resources.ApplyResources(this.ScrollCoordLabel, "ScrollCoordLabel");
            this.ScrollCoordLabel.Name = "ScrollCoordLabel";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScrollCoordLabel);
            this.Controls.Add(this.VramViewer);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel VramViewer;
        private System.Windows.Forms.Label ScrollCoordLabel;
    }
}

