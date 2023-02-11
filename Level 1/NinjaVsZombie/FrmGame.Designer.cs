namespace NinjaVsZombie
{
    partial class FrmGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.pbSurface = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSurface)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // pbSurface
            // 
            this.pbSurface.BackColor = System.Drawing.Color.Transparent;
            this.pbSurface.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbSurface.Image = ((System.Drawing.Image)(resources.GetObject("pbSurface.Image")));
            this.pbSurface.Location = new System.Drawing.Point(0, 354);
            this.pbSurface.Name = "pbSurface";
            this.pbSurface.Size = new System.Drawing.Size(1008, 149);
            this.pbSurface.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSurface.TabIndex = 0;
            this.pbSurface.TabStop = false;
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 503);
            this.Controls.Add(this.pbSurface);
            this.DoubleBuffered = true;
            this.Name = "FrmGame";
            this.Text = "Ninja VS Zombie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSurface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.PictureBox pbSurface;
    }
}