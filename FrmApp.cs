using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace vvma {
    public partial class FrmApp : Form {

        Config Config { get; set; }

        Client Client { get; set; }

        MidiClient MidiClient { get; set; }

        bool midiDirty;
        bool connectionDirty;
        bool inMainOp;

        public FrmApp() {
            InitializeComponent();
        }

        void Log(string text) {
            //lstLog.AddLogItem(text);
        }

        void DebugLog(string text) {
            Log(text);
        }

        private void FrmApp_Load(object sender, EventArgs e) {

            this.lstMidiInputs.Items.AddRange(MidiClient.GetPortNames().ToArray());

            if(this.lstMidiInputs.Items.Count == 0) {
                this.lstMidiLog.AddLog("No MIDI input port available!");
            }

        }

        private void Client_MessageSend(object sender, string e) {
            DebugLog("> " + e);
        }

        private void Client_MessageReceived(object sender, string e) {
            DebugLog("< " + e);
        }

        private void timerDebounce_Tick(object sender, EventArgs e) {
            if (midiDirty) {
                if (lstMidiInputs.SelectedItem != null) {
                    var name = lstMidiInputs.SelectedItem.ToString();
                    if (name != "") {
                        lstMidiLog.AddLog($"Open MIDI Port '{name}'");
                    }

                    this.MidiClient = new MidiClient(name, 0, 0, 10);
                    this.MidiClient.Log += this.MidiClient_Log;
                    this.MidiClient.PlayFile += this.MidiClient_PlayFile;
                    this.MidiClient.Start();
                }
                midiDirty = false;
            }

            if (connectionDirty) {
                var address = lstServer.SelectedItem.ToString();

                lstConnectionLog.AddLog($"Create connection to '{address}'");
                this.Client = new Client(address, 5233);
                this.Client.Log += this.VClient_Log;
                this.Client.Start();
                this.Client.StatusUpdated += this.VClient_StatusUpdated;
                this.Client.ConnectionEstablished += this.Client_ConnectionEstablished;

                connectionDirty = false;
                return;
            }

        }

        private void Client_ConnectionEstablished(object sender, EventArgs e) {
            if (!inMainOp) {
                this.Client.UpdateStatus();
            }
        }

        private void MidiClient_PlayFile(object sender, int e) {
            PlayFile(e);
        }

        private void PlayFile(int e) {
            if (this.Client.Connected) {
                this.Client.PlayFile(e);
                this.Client.UpdateStatus();
            }
        }

        private void MidiClient_Log(object sender, string e) {
            lstMidiLog.AddLog(e);
        }

        private void VClient_StatusUpdated(object sender, EventArgs e) {
            this.Invoke(((Action)(() => {
                lstConnectionLog.AddLog("GOT STATUS UPDATE!");

                if (!inMainOp) {
                    BuildFileList();
                    inMainOp = true;
                } else {
                    foreach(var btn in buttons) {
                        if ((int)btn.Tag == this.Client.ActiveFile) {
                            ButtonStyleActive(btn);
                        } else {
                            ButtonStyleNotActive(btn);
                        }
                    }
                }

            })));
        }

        Button[] buttons;

        void BuildFileList() {
            var files = this.Client.Files.ToArray();

            var pad = 2;
            var height = 27;

            var buttons = new List<Button>();

            for(var i=0; i<files.Length; i++) {
                var btn = new Button();
                btn.Top = (pad + height) * i + pad;
                btn.Height = height;
                btn.Width = panFiles.Width;
                btn.Text = files[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Tag = i + 1;
                btn.Click += this.BtnFile_Click;

                if (i+1 == Client.ActiveFile) {
                    ButtonStyleActive(btn);
                } else {
                    ButtonStyleNotActive(btn);
                }

                panFiles.Controls.Add(btn);
                buttons.Add(btn);
            }

            this.buttons = buttons.ToArray();
        }

        private void BtnFile_Click(object sender, EventArgs e) {
            var btn = (Button)sender;
            var index = (int)(btn.Tag);

            PlayFile(index);
        }

        void ButtonStyleNotActive(Button btn) {
            btn.BackColor = btnStyleNotActive.BackColor;
            btn.Font = btnStyleNotActive.Font;
        }

        void ButtonStyleActive(Button btn) {
            btn.BackColor = btnStyleActive.BackColor;
            btn.Font = btnStyleActive.Font;
        }

        private void VClient_Log(object sender, string e) {

            this.Invoke(((Action)(() => {
                lstConnectionLog.AddLog(e);
            })));

        }
        

        private void SetMidiDirty(object sender, EventArgs e) {
            midiDirty = true;
        }

        private void SetConnectionDirty(object sender, EventArgs e) {
            connectionDirty = true;
        }
    }
}
