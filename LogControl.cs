using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vvma {
    class LogControl : UserControl {

        ListBox listBox;

        public int MaxItems { get; set; } = 50;

        public LogControl() {
            listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            listBox.IntegralHeight = false;
            listBox.HorizontalScrollbar = true;
            this.Controls.Add(listBox);
        }

        public void AddLog(object item) {
            var c = listBox;
            c.Invoke(() => {
                c.Items.Insert(0, item);
                // c.SelectedIndex = c.Items.Count - 1;

                while (c.Items.Count > MaxItems) {
                    c.Items.RemoveAt(c.Items.Count - 1);
                }
            });
        }
    }
}
