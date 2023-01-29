using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace vvma {
    class MidiClient {

        string portName;
        int channel;
        int startNote;

        InputDevice inputDevice;

        public event EventHandler<string> Log;
        public event EventHandler<int> PlayFile;    

        public int FilesCount { get; set; }

        public MidiClient(string portName, int channel, int startNote) {
            this.portName = portName;
            this.channel = channel;
            this.startNote = startNote;
        }

        public bool Start() {
            try {
                this.inputDevice = InputDevice.GetByName(this.portName);
            } catch (ArgumentException) {
                var devices = string.Join(",", InputDevice.GetAll().Select(d => $"'{d.Name}'"));
                OnLog($"MIDI Input '{this.portName}' not found! Available Devices: {devices}");
                return false;
            }

            this.inputDevice.EventReceived += this.InputDevice_EventReceived;
            inputDevice.StartEventsListening();
            OnLog($"MIDI Port '{this.portName}' opened");

            return true;
        }

        bool IsInRange(int noteNumber) {
            return noteNumber >= startNote && noteNumber < startNote + FilesCount - 1;
        }

        private void InputDevice_EventReceived(object sender, MidiEventReceivedEventArgs e) {
            switch (e.Event.EventType) {
                case MidiEventType.NoteOn: {
                        var n = (NoteOnEvent)e.Event;
                        if (n.Channel != channel) {
                            return;
                        }

                        OnLog(n.ToString());

                        if (IsInRange(n.NoteNumber)) {
                            var index = n.NoteNumber - startNote + 2;
                            OnPlayFile(index);
                        }
                    }

                    break;

                case MidiEventType.NoteOff: {
                        var n = (NoteOffEvent)e.Event;
                        if (n.Channel != channel) {
                            return;
                        }

                        OnLog(n.ToString());

                        if (IsInRange(n.NoteNumber)) {
                            OnPlayFile(1);
                        }
                    }

                    break;
            }
        }

        protected void OnLog(string log) {
            if (this.Log != null) {
                this.Log(this, log);
            }
        }

        protected void OnPlayFile(int file) {
            if(this.PlayFile != null) {
                this.PlayFile(this, file);
            }
        }

        public static IEnumerable<string> GetPortNames() {
            return InputDevice.GetAll().Select(d => d.Name).ToArray();
        }

    }
}
