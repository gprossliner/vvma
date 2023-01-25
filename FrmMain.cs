using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace vvma {
    public partial class FrmMain : Form {

        Client client { get; set; }

        public FrmMain() {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            var devices = InputDevice.GetAll().ToArray();

            if (devices.Length == 0) {
                lstInputs.Items.Add("No MIDI Input device found!");
                cmdOpenMidi.Enabled = false;
            } else {
                lstInputs.Items.AddRange(devices);
            }

            lstInputs.SelectedIndex = 0;

            var config = Config.Open("config.yaml");
            lstTestMessages.Items.AddRange(config.TestCommands.ToArray());
        }

        private void cmdOpen_Click(object sender, EventArgs e) {
            var device = (InputDevice)lstInputs.SelectedItem;

            device.EventReceived += this.Device_EventReceived;
            device.StartEventsListening();
            cmdOpenMidi.Enabled = false;
        }

        private void Device_EventReceived(object sender, MidiEventReceivedEventArgs e) {
            switch (e.Event.EventType) {
                case MidiEventType.NoteOn:
                    var noteOn = (NoteOnEvent)e.Event;
                    lstMidiMessages.AddLogItem(noteOn);
                    break;

                case MidiEventType.NoteOff:
                    var noteOff = (NoteOffEvent)e.Event;
                    lstMidiMessages.AddLogItem(noteOff);
                    break;

                case MidiEventType.ControlChange:
                    lstMidiMessages.AddLogItem(e.Event);
                    break;
            }
        }


        private void cmdOpenClient_Click(object sender, EventArgs e) {
            this.client = new Client(txtAddress.Text, 2233);
            client.MessageReceived += this.Client_MessageReceived;
            client.MessageSend += this.Client_MessageSend;
            client.StartListen();
            lstClientMessages.AddLogItem("Connection estabished");
        }

        private void Client_MessageSend(object sender, string e) {
            lstClientMessages.AddLogItem("> " + e);
        }
        private void Client_MessageReceived(object sender, string e) {
            lstClientMessages.AddLogItem("< " + e);
        }

        private void cmdSend_Click(object sender, EventArgs e) {
            var cmd = (TestCommand)lstTestMessages.SelectedItem;
            this.client.Send(cmd.Value);
        }

        private void cmdStartTestServer_Click(object sender, EventArgs e) {
            var listener = new TcpListener(2233);
            listener.Start();
            lstServerLog.AddLogItem("Listening...");

            var acceptThread = new Thread(()=> {
                var client = listener.AcceptTcpClient();
                lstServerLog.AddLogItem("Client accepted");

                var stream = client.GetStream();
                for(; ; ) {
                    var msg = stream.ReadMessage();
                    lstServerLog.AddLogItem("< " + msg);

                    if (msg == "c31c38abca4a8c2e3") {
                        var resp = "c30c38alc280101 - Countdown5_circus.bin170202 - August.bin300303 - PromisedEnd - Black.bin170404 - Lilith.bin160505 - Idont.bin180606 - RealBoy.bin240707 - Puppenspieler.bin05ME11a4a8c2e3";
                        var respData = Encoding.ASCII.GetBytes(resp);
                        stream.Write(respData, 0, respData.Length);
                        lstServerLog.AddLogItem("> " + resp);
                    }
                }

            });
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }
    }
}
