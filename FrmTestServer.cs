using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vvma {
    public partial class FrmTestServer : Form {

        Thread acceptThread;
        bool stop;

        public FrmTestServer() {
            InitializeComponent();
        }

        public int CurrentFile { get; private set; } = 1;
        

        private void FrmTestServer_FormClosing(object sender, FormClosingEventArgs e) {
            this.stop = true;
            acceptThread.Join();
        }

        private void FrmTestServer_Load(object sender, EventArgs e) {
            var listener = new TcpListener(5233);
            listener.Start();
            lstServerLog.AddLogItem("Listening...");

            acceptThread = new Thread(() => {
                var client = listener.AcceptTcpClient();
                lstServerLog.AddLogItem("Client accepted");

                var stream = client.GetStream();
                while (!stop) {
                    var msg = stream.ReadMessage(ref stop);
                    lstServerLog.AddLogItem("< " + msg);

                    switch (msg.Substring(0, 6)) {
                        // c31c38abca4a8c2e3 FileList
                        case "c31c38":
                            var resp = $"c30c38alc280101 - Countdown5_circus.bin170202 - August.bin300303 - PromisedEnd - Black.bin170404 - Lilith.bin160505 - Idont.bin180606 - RealBoy.bin240707 - Puppenspieler.bin{this.CurrentFile.ToString("00")}ME11a4a8c2e3";
                            var respData = Encoding.ASCII.GetBytes(resp);
                            stream.Write(respData, 0, respData.Length);
                            lstServerLog.AddLogItem("> " + resp);
                            break;

                        // c31c40abe01a4a8c2e3 PlayFile
                        case "c31c40":
                            var file = Convert.ToInt32(msg.Substring(9, 2));
                            this.CurrentFile = file;
                            break;

                        // c31c32abca4a8c2e3 PlayNext
                        case "c31c32":
                            this.CurrentFile++;
                            break;
                    }
                }

            });
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }
    }
}
