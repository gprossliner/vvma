namespace vvma {
    partial class FrmTestServer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstServerLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstServerLog
            // 
            this.lstServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServerLog.FormattingEnabled = true;
            this.lstServerLog.Location = new System.Drawing.Point(12, 13);
            this.lstServerLog.Name = "lstServerLog";
            this.lstServerLog.Size = new System.Drawing.Size(773, 368);
            this.lstServerLog.TabIndex = 6;
            // 
            // FrmTestServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 403);
            this.Controls.Add(this.lstServerLog);
            this.Name = "FrmTestServer";
            this.Text = "FrmTestServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTestServer_FormClosing);
            this.Load += new System.EventHandler(this.FrmTestServer_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstServerLog;
    }
}