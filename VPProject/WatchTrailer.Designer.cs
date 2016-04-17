namespace VPProject
{
    partial class WatchTrailer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchTrailer));
            this.sfPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.sfPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // sfPlayer
            // 
            this.sfPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfPlayer.Enabled = true;
            this.sfPlayer.Location = new System.Drawing.Point(0, 0);
            this.sfPlayer.Name = "sfPlayer";
            this.sfPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sfPlayer.OcxState")));
            this.sfPlayer.Size = new System.Drawing.Size(711, 364);
            this.sfPlayer.TabIndex = 0;
            // 
            // WatchTrailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 364);
            this.Controls.Add(this.sfPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "WatchTrailer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WatchTrailer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatchTrailer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sfPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash sfPlayer;
    }
}