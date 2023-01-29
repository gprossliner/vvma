using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace vvma {
    class StreamHandler {

        NetworkStream stream;
        byte[] buffer = new byte[1024];
        const string END = "a4a8c2e3";

        public event EventHandler<string> MessageReceived;
        public event EventHandler<EventArgs> ConnectionClosed;

        public StreamHandler(NetworkStream stream) {
            this.stream = stream;
        }

        protected void OnMessageReceived(string message) {
            this.MessageReceived?.Invoke(this, message);
        }

        public void Start() {
            BeginRead();
        }

        void BeginRead() {
            stream.BeginRead(buffer, 0, buffer.Length, ar => {
                var r = 0;
                try {
                    r = stream.EndRead(ar);
                } catch (IOException ioex) {
                    if (ioex.HResult == -2146232800) {
                        // connnection closed
                        this.ConnectionClosed?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }

                var sbuffer = Encoding.ASCII.GetString(buffer, 0, r);

                // check for messages
                while(sbuffer.Length > 0) {
                    var p = sbuffer.IndexOf(END);
                    if (p > 0) {
                        var msg = sbuffer.Substring(0, p + END.Length);
                        OnMessageReceived(msg);
                        sbuffer = sbuffer.Substring(p + END.Length);
                    } else
                        break;
                }

                BeginRead();

            }, null);
        }

        public void Send(string msg) {
            var d = Encoding.ASCII.GetBytes(msg);
            stream.BeginWrite(d, 0, d.Length, ar => {
                stream.EndWrite(ar);
            }, null);
        }

    }
}
