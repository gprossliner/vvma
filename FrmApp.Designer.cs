namespace vvma {
    partial class FrmApp {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApp));
            this.panFiles = new System.Windows.Forms.Panel();
            this.btnStyleActive = new System.Windows.Forms.Button();
            this.btnStyleNotActive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMidiLog = new vvma.LogControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstConnectionLog = new vvma.LogControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panFiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panFiles
            // 
            this.panFiles.AutoScroll = true;
            this.panFiles.Controls.Add(this.btnStyleActive);
            this.panFiles.Controls.Add(this.btnStyleNotActive);
            this.panFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panFiles.Location = new System.Drawing.Point(3, 16);
            this.panFiles.Margin = new System.Windows.Forms.Padding(2);
            this.panFiles.Name = "panFiles";
            this.panFiles.Size = new System.Drawing.Size(420, 345);
            this.panFiles.TabIndex = 6;
            // 
            // btnStyleActive
            // 
            this.btnStyleActive.AutoEllipsis = true;
            this.btnStyleActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStyleActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStyleActive.Location = new System.Drawing.Point(2, 33);
            this.btnStyleActive.Margin = new System.Windows.Forms.Padding(2);
            this.btnStyleActive.Name = "btnStyleActive";
            this.btnStyleActive.Size = new System.Drawing.Size(362, 31);
            this.btnStyleActive.TabIndex = 0;
            this.btnStyleActive.Text = "btnStyleActive";
            this.btnStyleActive.UseVisualStyleBackColor = false;
            this.btnStyleActive.Visible = false;
            // 
            // btnStyleNotActive
            // 
            this.btnStyleNotActive.AutoEllipsis = true;
            this.btnStyleNotActive.Location = new System.Drawing.Point(2, 2);
            this.btnStyleNotActive.Margin = new System.Windows.Forms.Padding(2);
            this.btnStyleNotActive.Name = "btnStyleNotActive";
            this.btnStyleNotActive.Size = new System.Drawing.Size(362, 27);
            this.btnStyleNotActive.TabIndex = 0;
            this.btnStyleNotActive.Text = "btnStyleNotActive";
            this.btnStyleNotActive.UseVisualStyleBackColor = true;
            this.btnStyleNotActive.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMidiLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MIDI Input";
            // 
            // lstMidiLog
            // 
            this.lstMidiLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMidiLog.Location = new System.Drawing.Point(9, 19);
            this.lstMidiLog.MaxItems = 50;
            this.lstMidiLog.Name = "lstMidiLog";
            this.lstMidiLog.Size = new System.Drawing.Size(279, 156);
            this.lstMidiLog.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstConnectionLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 179);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // lstConnectionLog
            // 
            this.lstConnectionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConnectionLog.Location = new System.Drawing.Point(7, 19);
            this.lstConnectionLog.MaxItems = 50;
            this.lstConnectionLog.Name = "lstConnectionLog";
            this.lstConnectionLog.Size = new System.Drawing.Size(279, 154);
            this.lstConnectionLog.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panFiles);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 364);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(435, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 370);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // FrmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmApp";
            this.Text = "VVMA";
            this.Load += new System.EventHandler(this.FrmApp_Load);
            this.panFiles.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panFiles;
        private System.Windows.Forms.Button btnStyleNotActive;
        private System.Windows.Forms.Button btnStyleActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private LogControl lstMidiLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private LogControl lstConnectionLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}