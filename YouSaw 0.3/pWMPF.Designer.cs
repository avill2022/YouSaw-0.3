namespace YouSaw_0._3
{
    partial class pWMPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pWMPF));
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.panel_mute = new System.Windows.Forms.Panel();
            this.label_mute = new System.Windows.Forms.Label();
            this.pchannel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pB1 = new System.Windows.Forms.PictureBox();
            this.pB2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DUAL = new System.Windows.Forms.Label();
            this.lnombrechannel = new System.Windows.Forms.Label();
            this.lname_video = new System.Windows.Forms.Label();
            this.pError = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.p_error = new System.Windows.Forms.Label();
            this.pvolumen = new System.Windows.Forms.Panel();
            this.progresBarrVolumen = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.panel_mute.SuspendLayout();
            this.pchannel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pvolumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWMP
            // 
            this.axWMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWMP.Enabled = true;
            this.axWMP.Location = new System.Drawing.Point(0, 0);
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            this.axWMP.Size = new System.Drawing.Size(749, 567);
            this.axWMP.TabIndex = 0;
            // 
            // panel_menu
            // 
            this.panel_menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel_menu.Location = new System.Drawing.Point(73, 282);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(592, 250);
            this.panel_menu.TabIndex = 14;
            // 
            // panel_mute
            // 
            this.panel_mute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_mute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel_mute.Controls.Add(this.label_mute);
            this.panel_mute.Location = new System.Drawing.Point(58, 513);
            this.panel_mute.Name = "panel_mute";
            this.panel_mute.Size = new System.Drawing.Size(75, 28);
            this.panel_mute.TabIndex = 1002;
            this.panel_mute.Visible = false;
            // 
            // label_mute
            // 
            this.label_mute.AutoSize = true;
            this.label_mute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mute.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_mute.Location = new System.Drawing.Point(12, 5);
            this.label_mute.Name = "label_mute";
            this.label_mute.Size = new System.Drawing.Size(45, 20);
            this.label_mute.TabIndex = 7;
            this.label_mute.Text = "mute";
            // 
            // pchannel
            // 
            this.pchannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pchannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pchannel.Controls.Add(this.panel1);
            this.pchannel.Controls.Add(this.lname_video);
            this.pchannel.Location = new System.Drawing.Point(560, 12);
            this.pchannel.Name = "pchannel";
            this.pchannel.Size = new System.Drawing.Size(183, 114);
            this.pchannel.TabIndex = 1003;
            this.pchannel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pB1);
            this.panel1.Controls.Add(this.pB2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 53);
            this.panel1.TabIndex = 0;
            // 
            // pB1
            // 
            this.pB1.Image = ((System.Drawing.Image)(resources.GetObject("pB1.Image")));
            this.pB1.Location = new System.Drawing.Point(2, 3);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(50, 50);
            this.pB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB1.TabIndex = 3;
            this.pB1.TabStop = false;
            this.pB1.Visible = false;
            // 
            // pB2
            // 
            this.pB2.Image = ((System.Drawing.Image)(resources.GetObject("pB2.Image")));
            this.pB2.Location = new System.Drawing.Point(2, 3);
            this.pB2.Name = "pB2";
            this.pB2.Size = new System.Drawing.Size(50, 50);
            this.pB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB2.TabIndex = 1;
            this.pB2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(52, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 53);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel4.Controls.Add(this.DUAL);
            this.panel4.Controls.Add(this.lnombrechannel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 53);
            this.panel4.TabIndex = 1;
            // 
            // DUAL
            // 
            this.DUAL.AutoSize = true;
            this.DUAL.BackColor = System.Drawing.Color.Maroon;
            this.DUAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DUAL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DUAL.Location = new System.Drawing.Point(76, 5);
            this.DUAL.Name = "DUAL";
            this.DUAL.Size = new System.Drawing.Size(55, 13);
            this.DUAL.TabIndex = 1;
            this.DUAL.Text = "DUAL:f2";
            this.DUAL.Visible = false;
            // 
            // lnombrechannel
            // 
            this.lnombrechannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnombrechannel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lnombrechannel.Location = new System.Drawing.Point(0, -2);
            this.lnombrechannel.Name = "lnombrechannel";
            this.lnombrechannel.Size = new System.Drawing.Size(131, 54);
            this.lnombrechannel.TabIndex = 0;
            this.lnombrechannel.Text = "CA";
            // 
            // lname_video
            // 
            this.lname_video.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lname_video.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname_video.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lname_video.Location = new System.Drawing.Point(1, 52);
            this.lname_video.Name = "lname_video";
            this.lname_video.Size = new System.Drawing.Size(182, 62);
            this.lname_video.TabIndex = 4;
            // 
            // pError
            // 
            this.pError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pError.Controls.Add(this.label1);
            this.pError.Controls.Add(this.pictureBox2);
            this.pError.Controls.Add(this.p_error);
            this.pError.Location = new System.Drawing.Point(73, 129);
            this.pError.Name = "pError";
            this.pError.Size = new System.Drawing.Size(592, 147);
            this.pError.TabIndex = 1004;
            this.pError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(44, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Something is worng";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // p_error
            // 
            this.p_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.p_error.Location = new System.Drawing.Point(0, 55);
            this.p_error.Name = "p_error";
            this.p_error.Size = new System.Drawing.Size(592, 92);
            this.p_error.TabIndex = 36;
            this.p_error.Visible = false;
            // 
            // pvolumen
            // 
            this.pvolumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvolumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pvolumen.Controls.Add(this.progresBarrVolumen);
            this.pvolumen.Location = new System.Drawing.Point(73, 508);
            this.pvolumen.Name = "pvolumen";
            this.pvolumen.Size = new System.Drawing.Size(592, 28);
            this.pvolumen.TabIndex = 1005;
            this.pvolumen.Visible = false;
            // 
            // progresBarrVolumen
            // 
            this.progresBarrVolumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progresBarrVolumen.Location = new System.Drawing.Point(0, 0);
            this.progresBarrVolumen.Name = "progresBarrVolumen";
            this.progresBarrVolumen.Size = new System.Drawing.Size(592, 28);
            this.progresBarrVolumen.TabIndex = 0;
            // 
            // pWMPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(749, 567);
            this.Controls.Add(this.pvolumen);
            this.Controls.Add(this.pError);
            this.Controls.Add(this.pchannel);
            this.Controls.Add(this.panel_mute);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.axWMP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pWMPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pWMPF";
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.panel_mute.ResumeLayout(false);
            this.panel_mute.PerformLayout();
            this.pchannel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pError.ResumeLayout(false);
            this.pError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pvolumen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWMP;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_mute;
        private System.Windows.Forms.Label label_mute;
        private System.Windows.Forms.Panel pchannel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pB1;
        private System.Windows.Forms.PictureBox pB2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label DUAL;
        private System.Windows.Forms.Label lnombrechannel;
        private System.Windows.Forms.Label lname_video;
        private System.Windows.Forms.Panel pError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label p_error;
        private System.Windows.Forms.Panel pvolumen;
        private System.Windows.Forms.ProgressBar progresBarrVolumen;
    }
}