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

            timer.Start();

            var cfg = Config.Open("config.yaml");
            this.Config = cfg;


            // Open MIDI Port
            Log($"Open MIDI Port '{cfg.MidiInPort}'");
            var input = InputDevice.GetByName(cfg.MidiInPort);

            Log($"Port opened. Listen on Channel {cfg.MidiChannel} for Notest {cfg.StartNote}-{cfg.EndNote}");
            input.EventReceived += this.Input_EventReceived;
            input.StartEventsListening();

            // Open client
            Log($"Connect to server {cfg.ServerAddress}:{cfg.ServerPort}");

            this.Client = new Client(cfg.ServerAddress, cfg.ServerPort);
            this.Client.MessageReceived += this.Client_MessageReceived;
            this.Client.MessageSend += this.Client_MessageSend;
            this.Client.StartListen();

            // Play empty
            PlayFile(0);
        }

        private void Client_MessageSend(object sender, string e) {
            DebugLog("> " + e);
        }

        private void Client_MessageReceived(object sender, string e) {
            DebugLog("< " + e);
        }

        void PlayFile(int index) {
            DebugLog($"PlayFile({index})");
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

                        if (n.NoteNumber > this.Config.StartNote && n.NoteNumber <= this.Config.EndNote) {
                            var index = n.NoteNumber - this.Config.StartNote + 1;
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

                        if (n.NoteNumber > this.Config.StartNote && n.NoteNumber <= this.Config.EndNote) {
                            PlayFile(0);
                        }
                    }

                    break;
            }
        }
    }
}
