using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vvma;

namespace vvma_testserver {
    public partial class FrmTestServer : Form {

        TcpListener listener;

        public FrmTestServer() {
            InitializeComponent();
        }

        public int CurrentFile { get; private set; } = 1;
        
        private void FrmTestServer_Load(object sender, EventArgs e) {
            listener = new TcpListener(System.Net.IPAddress.Any, 5233);
            listener.Start();
            lstServerLog.AddLogItem("Listening...");

            BeginAccept();
        }

        void BeginAccept() {
            listener.BeginAcceptTcpClient(ar => {
                var client = listener.EndAcceptTcpClient(ar);
                lstServerLog.AddLogItem($"Client connected");

                var stream = client.GetStream();
                var handler = new StreamHandler(stream);

                handler.MessageReceived += this.Handler_MessageReceived;
                handler.ConnectionClosed += this.Handler_ConnectionClosed;
                handler.Start();
                BeginAccept();
            }, null);

        }

        private void Handler_ConnectionClosed(object sender, EventArgs e) {
            lstServerLog.AddLogItem("Connection closed");
        }

        private void Handler_MessageReceived(object sender, string msg) {
            var handler = (StreamHandler)sender;
            lstServerLog.AddLogItem("< " + msg);

            switch (msg.Substring(0, 6)) {
                // c31c38abca4a8c2e3 FileList
                case "c31c38":
                    var resp = $"c30c38alc280101 - Countdown5_circus.bin170202 - August.bin300303 - PromisedEnd - Black.bin170404 - Lilith.bin160505 - Idont.bin180606 - RealBoy.bin240707 - Puppenspieler.bin{this.CurrentFile.ToString("00")}ME11a4a8c2e3";
                    handler.Send(resp);
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

        
    }
}
