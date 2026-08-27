using System;

namespace spaceshooter
{
    partial class gamedev
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameloop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            this.gameloop.Enabled = true;
            this.gameloop.Interval = 10;
            this.gameloop.Tick += new System.EventHandler(this.gameloop_Tick);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400); // ✅ 800,450 ki jagah            this.Name = "gamedev";
            this.Text = "Space Shooter";
            this.Load += new System.EventHandler(this.gamedev_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer gameloop;
        private System.Windows.Forms.PictureBox player;
    }
}