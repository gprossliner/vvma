using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vvma {
    class Client {

        TcpClient tcpClient;
        Thread readerThread;
        NetworkStream stream;
        bool stop;
        string address;
        int port;

        public bool Connected { get; private set; }

        public const string END = "a4a8c2e3";

        public Client(string address, int port) {
            this.address = address;
            this.port = port;
        }

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> MessageSend;
        public event EventHandler<EventArgs> StatusUpdated; 

        public int ActiveFile { get; private set; }

        public List<string> Files { get; private set; }

        public void Start() {

            tcpClient = new TcpClient();

            readerThread = new Thread(readerMain);
            readerThread.IsBackground = true;
            readerThread.Start();
        }

        void readerMain() {
            while (!stop) {

                if (!this.Connected) {
                    try {
                        tcpClient.Connect(address, port);
                        tcpClient.ReceiveTimeout = 10;
                        stream = tcpClient.GetStream();
                        this.Connected = true;

                        Thread.Sleep(500);
                    } catch (Exception ex) {

                    }
                    continue;
                }

                var data = stream.ReadMessage(ref stop);
                if (this.MessageReceived != null) {
                    this.MessageReceived(this, data);
                }

                if (data.StartsWith("c30c38")) {
                    this.ParseFileList(data);
                    if (this.StatusUpdated != null) {
                        this.StatusUpdated(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void Send(string msg) {
            var data = Encoding.ASCII.GetBytes(msg);
            stream.Write(data, 0, data.Length);

            if (this.MessageSend != null) {
                this.MessageSend(this, msg);
            }
        }

        public void StopListen() {
            stop = true;
            readerThread.Join();
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
