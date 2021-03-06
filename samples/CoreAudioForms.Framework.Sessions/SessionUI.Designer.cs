﻿namespace CoreAudioForms.Framework.Sessions {
    partial class SessionUI {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.ProgressBarVU = new System.Windows.Forms.ProgressBar();
            this.TrackBarVol = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVol)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxIcon
            // 
            this.PictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxIcon.Name = "PictureBoxIcon";
            this.PictureBoxIcon.Size = new System.Drawing.Size(64, 64);
            this.PictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxIcon.TabIndex = 0;
            this.PictureBoxIcon.TabStop = false;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(73, 3);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(75, 13);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "Session Name";
            // 
            // ProgressBarVU
            // 
            this.ProgressBarVU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarVU.Location = new System.Drawing.Point(73, 19);
            this.ProgressBarVU.Name = "ProgressBarVU";
            this.ProgressBarVU.Size = new System.Drawing.Size(154, 16);
            this.ProgressBarVU.TabIndex = 2;
            // 
            // TrackBarVol
            // 
            this.TrackBarVol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackBarVol.AutoSize = false;
            this.TrackBarVol.Location = new System.Drawing.Point(73, 41);
            this.TrackBarVol.Maximum = 100;
            this.TrackBarVol.Name = "TrackBarVol";
            this.TrackBarVol.Size = new System.Drawing.Size(154, 22);
            this.TrackBarVol.TabIndex = 3;
            this.TrackBarVol.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // SessionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TrackBarVol);
            this.Controls.Add(this.ProgressBarVU);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.PictureBoxIcon);
            this.MaximumSize = new System.Drawing.Size(100000, 70);
            this.MinimumSize = new System.Drawing.Size(230, 70);
            this.Name = "SessionUI";
            this.Size = new System.Drawing.Size(230, 70);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxIcon;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.ProgressBar ProgressBarVU;
        private System.Windows.Forms.TrackBar TrackBarVol;
    }
}
