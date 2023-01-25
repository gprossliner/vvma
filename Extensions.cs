using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vvma {
    static class Extensions {

        public static string ReadMessage(this NetworkStream stream, int timeout = 10, int bufferSize = 1024) {

            stream.ReadTimeout = timeout;
            while (true) {
                var buffer = new byte[bufferSize];

                try {   
                    var i = stream.Read(buffer, 0, buffer.Length);
                    var data = Encoding.ASCII.GetString(buffer, 0, i);
                    return data;
                } catch (System.IO.IOException ioex) {
                    continue;
                }

            }

        }

        public static void AddLogItem(this ListBox c, object item) {
            c.Invoke(((Action)(() => {
                c.Items.Add(item);
                c.SelectedIndex = c.Items.Count - 1;
            })));
        }

    }
}
