using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace vvma {
    class Client {

        TcpClient tcpClient;
        StreamHandler handler;
       
        string address;
        int port;

        public bool Connected => handler != null;

        public const string END = "a4a8c2e3";

        public Client(string address, int port) {
            this.address = address;
            this.port = port;
        }

        public event EventHandler<string> Log;
        public event EventHandler<EventArgs> ConnectionEstablished;
        public event EventHandler<EventArgs> ConnectionClosed;

        public event EventHandler<EventArgs> StatusUpdated; 

        public int ActiveFile { get; private set; }

        public List<string> Files { get; private set; }

        public void Start() {

            OnLog("Try connect to server");
            tcpClient = new TcpClient();
            tcpClient.BeginConnect(address, port, ar => {
                try {
                    tcpClient.EndConnect(ar);
                } catch(SocketException sex) {
                    OnLog($"Connection error: {sex.SocketErrorCode}");
                    Start();
                    return;
                }
                OnLog("Connected to server");

                var stream = tcpClient.GetStream();
                handler = new StreamHandler(stream);

                handler.MessageReceived += this.Handler_MessageReceived;
                handler.ConnectionClosed += this.Handler_ConnectionClosed;
                handler.Start();
                this.ConnectionEstablished?.Invoke(this, EventArgs.Empty);
            }, null);
        }

        private void Handler_ConnectionClosed(object sender, EventArgs e) {
            OnLog("Connection closed by server!");
            handler = null;
            this.ConnectionClosed?.Invoke(this, EventArgs.Empty);
            Start();
        }

        private void Handler_MessageReceived(object sender, string msg) {

            OnLog("< " + msg);

            if (msg.StartsWith("c30c38")) {
                this.ParseFileList(msg);
                if (this.StatusUpdated != null) {
                    this.StatusUpdated(this, EventArgs.Empty);
                }
            }
        }

        protected void OnLog(string log) {
            this.Log?.Invoke(this, log);
        }

        public void Send(string msg) {
            handler.Send(msg);
            OnLog("> " + msg);
        }


        public void PlayFile(int index) {
            var cmd = $"c31c40abe{index.ToString("00")}{END}";
            Send(cmd);
        }

        public void UpdateStatus() {
            var cmd = "c31c38abc" + END;
            Send(cmd);
        }

        bool ParseFileList(string msg) {
            // "c30c38alc280101 - Countdown5_circus.bin170202 - August.bin300303 - PromisedEnd - Black.bin170404 - Lilith.bin160505 - Idont.bin180606 - RealBoy.bin240707 - Puppenspieler.bin05ME11a4a8c2e3

            if (!msg.EndsWith(END)) {
                return false;
            }

            // strip end
            msg = msg.Substring(0, msg.Length - END.Length);

            // strip start c30c38alc
            msg = msg.Substring(9);

            // read and stip status
            var status = msg.Substring(msg.Length - 6);
            this.ActiveFile = Convert.ToInt32(status.Substring(0, 2));
            msg = msg.Substring(0, msg.Length - 6);

            // "280101 - Countdown5_circus.bin170202 - August.bin300303 - PromisedEnd - Black.bin170404 - Lilith.bin160505 - Idont.bin180606 - RealBoy.bin240707 - Puppenspieler.bin05ME11a4a8c2e3
            var list = new List<string>();
            while(msg.Length > 0) {
                // read len
                var l = Convert.ToInt32(msg.Substring(0, 2)) - 2;
                var name = msg.Substring(4, l);
                list.Add(name);
                msg = msg.Substring(l + 4);
            }

            this.Files = list;

            return true;
        }
    }
}
