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

        Config Config { get; set; }

        public FrmMain() {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            var devices = InputDevice.GetAll().Select(d=>d.Name).ToArray();

            if (devices.Length == 0) {
                lstInputs.Items.Add("No MIDI Input device found!");
                cmdOpenMidi.Enabled = false;
            } else {
                lstInputs.Items.AddRange(devices);
            }

            lstInputs.SelectedIndex = 0;

            this.Config = Config.Open("config.yaml");
            lstTestMessages.Items.AddRange(this.Config.TestCommands.ToArray());
        }

        private void cmdOpen_Click(object sender, EventArgs e) {
            var deviceName = lstInputs.SelectedItem.ToString();
            var device = InputDevice.GetByName(deviceName);

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
            this.client = new Client(txtAddress.Text, 5233);
            this.client.Log += Client_Log;
            client.Start();
            lstClientMessages.AddLogItem("Connection estabished");
        }

        private void Client_Log(object sender, string e) {
            lstClientMessages.AddLogItem(e);
        }
        private void Client_MessageReceived(object sender, string e) {
            lstClientMessages.AddLogItem("< " + e);
        }

        private void cmdSend_Click(object sender, EventArgs e) {
            var cmd = (TestCommand)lstTestMessages.SelectedItem;
            this.client.Send(cmd.Value);
        }

   

        private void cmdRealApp_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) {

        }

        private void lstInputs_SelectedIndexChanged(object sender, EventArgs e) {

        }

    }
}
