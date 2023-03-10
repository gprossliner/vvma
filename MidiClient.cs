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
        int lastPlayedIndex;

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
            this.inputDevice.ErrorOccurred += this.InputDevice_ErrorOccurred;
            this.inputDevice.MidiTimeCodeReceived += this.InputDevice_MidiTimeCodeReceived;
            inputDevice.StartEventsListening();
            OnLog($"MIDI Port '{this.portName}' opened");

            return true;
        }

        private void InputDevice_MidiTimeCodeReceived(object sender, MidiTimeCodeReceivedEventArgs e) {
            OnLog($"MIDI TC {e.Format}: {e.Hours.ToString("00")}:{e.Minutes.ToString("00")}:{e.Seconds.ToString("00")}");
        }

        private void InputDevice_ErrorOccurred(object sender, ErrorOccurredEventArgs e) {
            OnLog($"MIDI Error: {e.Exception.Message}");
        }

        bool IsInRange(int noteNumber) {
            return noteNumber >= startNote && noteNumber < startNote + FilesCount - 1;
        }

        int NoteToIndex(int noteNumber) {
            return noteNumber - startNote + 2;
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
                            var index = NoteToIndex(n.NoteNumber);
                            lastPlayedIndex = index;
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
                            if (NoteToIndex(n.NoteNumber) == lastPlayedIndex) {
                                OnPlayFile(1);
                            }
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
