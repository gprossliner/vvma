using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace vvma {
    public partial class FrmApp : Form {

        Config Config { get; set; }

        Client Client { get; set; }

        public FrmApp() {
            InitializeComponent();
        }

        void Log(string text) {
            lstLog.AddLogItem(text);
        }

        void DebugLog(string text) {
            Log(text);
        }

        private void FrmApp_Load(object sender, EventArgs e) {

            var cfg = Config.Open("config.yaml");
            this.Config = cfg;

            Log($"Create Client for {cfg.ServerAddress}:{cfg.ServerPort}");

            this.Client = new Client(cfg.ServerAddress, cfg.ServerPort);
            this.Client.MessageReceived += this.Client_MessageReceived;
            this.Client.MessageSend += this.Client_MessageSend;
            this.Client.StatusUpdated += this.Client_StatusUpdated;
            this.Client.Start();

            //// Open MIDI Port
            //Log($"Open MIDI Port '{cfg.MidiInPort}'");
            //var input = InputDevice.GetByName(cfg.MidiInPort);

            //Log($"Port opened. Listen on Channel {cfg.MidiChannel} for Notest {cfg.StartNote}-{cfg.EndNote}");
            //input.EventReceived += this.Input_EventReceived;
            //input.StartEventsListening();

            timer.Interval = 5000;
            timer.Start();

        }

        private void Client_MessageSend(object sender, string e) {
            DebugLog("> " + e);
        }

        private void Client_MessageReceived(object sender, string e) {
            DebugLog("< " + e);
        }

        void PlayFile(int index) {
            Log($"PlayFile({index})");
            this.Client.PlayFile(index);
        }

        private void Input_EventReceived(object sender, MidiEventReceivedEventArgs e) {
            switch(e.Event.EventType) {
                case MidiEventType.NoteOn: {
                        var n = (NoteOnEvent)e.Event;
                        if (n.Channel != this.Config.MidiChannel) {
                            return;
                        }

                        DebugLog(n.ToString());

                        if (n.NoteNumber >= this.Config.StartNote && n.NoteNumber <= this.Config.EndNote) {
                            var index = n.NoteNumber - this.Config.StartNote + 2;
                            PlayFile(index);
                        }
                    }

                    break;

                case MidiEventType.NoteOff: {
                        var n = (NoteOnEvent)e.Event;
                        if (n.Channel != this.Config.MidiChannel) {
                            return;
                        }

                        DebugLog(n.ToString());

                        if (n.NoteNumber >= this.Config.StartNote && n.NoteNumber <= this.Config.EndNote) {
                            PlayFile(1);
                        }
                    }

                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        FrmTestServer _frmTestServer = new FrmTestServer();

        private void cmdTestServer_Click(object sender, EventArgs e) {
            _frmTestServer.Show();   
        }

        private void timer_Tick(object sender, EventArgs e) {

            if (this.Client.Connected) {

                // Get FileList
                this.Client.UpdateStatus();

                // Play empty
                PlayFile(1);
            }
        }

        private void Client_StatusUpdated(object sender, EventArgs e) {

            this.Invoke(((Action)(() => {
                lstFiles.Items.Clear();
                lstFiles.Items.AddRange(this.Client.Files.ToArray());
                lstFiles.SelectedIndex = this.Client.ActiveFile - 1;
            })));

        }
    }
}
