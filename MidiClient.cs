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
        int endNote;

        InputDevice inputDevice;

        public event EventHandler<string> Log;
        public event EventHandler<int> PlayFile;    

        public MidiClient(string portName, int channel, int startNote, int endNote) {
            this.portName = portName;
            this.channel = channel;
            this.startNote = startNote;
            this.endNote = endNote;
        }

        public void Start() {
            this.inputDevice = InputDevice.GetByName(this.portName);
            this.inputDevice.EventReceived += this.InputDevice_EventReceived;
            inputDevice.StartEventsListening();
            OnLog($"MIDI Port '{this.portName}' opened");
        }

        private void InputDevice_EventReceived(object sender, MidiEventReceivedEventArgs e) {
            switch (e.Event.EventType) {
                case MidiEventType.NoteOn: {
                        var n = (NoteOnEvent)e.Event;
                        if (n.Channel != channel) {
                            return;
                        }

                        OnLog(n.ToString());

                        if (n.NoteNumber >= startNote && n.NoteNumber <= endNote) {
                            var index = n.NoteNumber - startNote + 2;
                            OnPlayFile(index);
                        }
                    }

                    break;

                case MidiEventType.NoteOff: {
                        var n = (NoteOnEvent)e.Event;
                        if (n.Channel != channel) {
                            return;
                        }

                        OnLog(n.ToString());

                        if (n.NoteNumber >= startNote && n.NoteNumber <= endNote) {
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
