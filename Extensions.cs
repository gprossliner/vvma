using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vvma {
    static class Extensions {

        public static void AddLogItem(this ListBox c, object item) {
            c.Invoke(() => {
                c.Items.Add(item);
                c.SelectedIndex = c.Items.Count - 1;
            });
        }

        public static void Invoke(this Control ctl, Action action) {
            ctl.Invoke(action);
        }
    }
}
