namespace vvma {
    partial class FrmMain {
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
            this.lstInputs = new System.Windows.Forms.ComboBox();
            this.cmdOpenMidi = new System.Windows.Forms.Button();
            this.lstMidiMessages = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstTestMessages = new System.Windows.Forms.ComboBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.lstClientMessages = new System.Windows.Forms.ListBox();
            this.cmdOpenClient = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstServerLog = new System.Windows.Forms.ListBox();
            this.cmdStartTestServer = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstInputs
            // 
            this.lstInputs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInputs.FormattingEnabled = true;
            this.lstInputs.Location = new System.Drawing.Point(6, 6);
            this.lstInputs.Name = "lstInputs";
            this.lstInputs.Size = new System.Drawing.Size(211, 21);
            this.lstInputs.TabIndex = 0;
            // 
            // cmdOpenMidi
            // 
            this.cmdOpenMidi.Location = new System.Drawing.Point(223, 4);
            this.cmdOpenMidi.Name = "cmdOpenMidi";
            this.cmdOpenMidi.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenMidi.TabIndex = 1;
            this.cmdOpenMidi.Text = "Open";
            this.cmdOpenMidi.UseVisualStyleBackColor = true;
            this.cmdOpenMidi.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // lstMidiMessages
            // 
            this.lstMidiMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMidiMessages.FormattingEnabled = true;
            this.lstMidiMessages.Location = new System.Drawing.Point(8, 33);
            this.lstMidiMessages.Name = "lstMidiMessages";
            this.lstMidiMessages.Size = new System.Drawing.Size(773, 303);
            this.lstMidiMessages.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 377);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstInputs);
            this.tabPage1.Controls.Add(this.lstMidiMessages);
            this.tabPage1.Controls.Add(this.cmdOpenMidi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MIDI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstTestMessages);
            this.tabPage2.Controls.Add(this.cmdSend);
            this.tabPage2.Controls.Add(this.lstClientMessages);
            this.tabPage2.Controls.Add(this.cmdOpenClient);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Commands";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstTestMessages
            // 
            this.lstTestMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTestMessages.FormattingEnabled = true;
            this.lstTestMessages.Location = new System.Drawing.Point(489, 5);
            this.lstTestMessages.Name = "lstTestMessages";
            this.lstTestMessages.Size = new System.Drawing.Size(211, 21);
            this.lstTestMessages.TabIndex = 4;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(706, 3);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // lstClientMessages
            // 
            this.lstClientMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClientMessages.FormattingEnabled = true;
            this.lstClientMessages.Location = new System.Drawing.Point(8, 32);
            this.lstClientMessages.Name = "lstClientMessages";
            this.lstClientMessages.Size = new System.Drawing.Size(773, 316);
            this.lstClientMessages.TabIndex = 3;
            // 
            // cmdOpenClient
            // 
            this.cmdOpenClient.Location = new System.Drawing.Point(225, 4);
            this.cmdOpenClient.Name = "cmdOpenClient";
            this.cmdOpenClient.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenClient.TabIndex = 2;
            this.cmdOpenClient.Text = "Open";
            this.cmdOpenClient.UseVisualStyleBackColor = true;
            this.cmdOpenClient.Click += new System.EventHandler(this.cmdOpenClient_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(8, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(211, 20);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "localhost";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmdStartTestServer);
            this.tabPage3.Controls.Add(this.lstServerLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(789, 351);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test-Server";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstServerLog
            // 
            this.lstServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServerLog.FormattingEnabled = true;
            this.lstServerLog.Location = new System.Drawing.Point(6, 39);
            this.lstServerLog.Name = "lstServerLog";
            this.lstServerLog.Size = new System.Drawing.Size(773, 316);
            this.lstServerLog.TabIndex = 4;
            // 
            // cmdStartTestServer
            // 
            this.cmdStartTestServer.Location = new System.Drawing.Point(9, 7);
            this.cmdStartTestServer.Name = "cmdStartTestServer";
            this.cmdStartTestServer.Size = new System.Drawing.Size(75, 23);
            this.cmdStartTestServer.TabIndex = 5;
            this.cmdStartTestServer.Text = "Start";
            this.cmdStartTestServer.UseVisualStyleBackColor = true;
            this.cmdStartTestServer.Click += new System.EventHandler(this.cmdStartTestServer_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 377);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.Text = "VVMA";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lstInputs;
        private System.Windows.Forms.Button cmdOpenMidi;
        private System.Windows.Forms.ListBox lstMidiMessages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button cmdOpenClient;
        private System.Windows.Forms.ListBox lstClientMessages;
        private System.Windows.Forms.ComboBox lstTestMessages;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdStartTestServer;
        private System.Windows.Forms.ListBox lstServerLog;
    }
}

