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

        public Client(string address, int port) {
            tcpClient = new TcpClient();
            tcpClient.Connect(address, port);
            tcpClient.ReceiveTimeout = 10;
            stream = tcpClient.GetStream();
        }

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> MessageSend;


        public void StartListen() {
            if (this.MessageReceived == null)
                throw new InvalidOperationException("No EventHander in MessageReceived event!");

            readerThread = new Thread(readerMain);
            readerThread.IsBackground = true;
            readerThread.Start();
        }

        void readerMain() {
            while (!stop) {
                var data = stream.ReadMessage();
                this.MessageReceived(this, data);
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
    }
}
