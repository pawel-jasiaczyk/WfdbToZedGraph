using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfdbToZedGraph.WinformControl
{
    public partial class OpenRecordProgresBar : UserControl
    {
        public OpenRecordProgresBar ()
        {
            InitializeComponent();
        }

        public OpenRecordProgresBar(WfdbSignalWraper signal) : this()
        {
            this.SetLabel(string.Format("File: {0} Signal: {1}", signal.FileName, signal.SignalNumber));
            this.SetPercentage(0);
            signal.StatusUpdate += signal_StatusUpdate;
        }

        void signal_StatusUpdate (object sender, EventArgs e)
        {
            OpenSignalEventArgs arg = e as OpenSignalEventArgs;
            if(arg != null)
            {
                if (arg.Finished)
                {
                    int t = 0; // added for no empty if, bellow was commented
                    //this.Close();
                }
                else
                {
                    //MessageBox.Show("test");
                    SetPercentage(arg.PercentageStatus);
                }
            }
        }

        private void SetLabel(string text)
        {
            if (!this.labelCurrent.InvokeRequired)
                this.labelCurrent.Text = text;
            else
                Invoke(new Action<string>(SetLabel), text);
        }

        private void SetPercentage(int percentage)
        {
            if (!this.progressBarCurrent.InvokeRequired)
                this.progressBarCurrent.Value = percentage;
            else
                Invoke(new Action<int>(SetPercentage), percentage);
        }
    }
}
