namespace YouSaw_0._3
{
    partial class Form_Search
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
            this.flowLayoutPanelChannels = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelChannels
            // 
            this.flowLayoutPanelChannels.AutoScroll = true;
            this.flowLayoutPanelChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.flowLayoutPanelChannels.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelChannels.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelChannels.Name = "flowLayoutPanelChannels";
            this.flowLayoutPanelChannels.Size = new System.Drawing.Size(776, 52);
            this.flowLayoutPanelChannels.TabIndex = 1;
            this.flowLayoutPanelChannels.WrapContents = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 52);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(776, 380);
            this.flowLayoutPanel.TabIndex = 2;
            this.flowLayoutPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanel_Scroll);
            // 
            // Form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 432);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.flowLayoutPanelChannels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChannels;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}