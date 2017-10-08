using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WfdbToZedGraph.WinformControl
{
    public partial class OpenrecordProgressBarPopUp : Form
    {
        private List<WfdbSignalWraper> signals;

        public OpenrecordProgressBarPopUp ()
        {
            InitializeComponent();
            this.signals = new List<WfdbSignalWraper>();
        }

        public OpenrecordProgressBarPopUp(WfdbSignalWraper[] signals)
            : this()
        {
            foreach(WfdbSignalWraper s in this.signals)
            {
                AddSignal(s);
            }
        }

        public void AddSignal(WfdbSignalWraper signal)
        {
            this.signals.Add(signal);
            OpenRecordProgresBar opf = new OpenRecordProgresBar(signal);
            this.Height += opf.Height;
            opf.Left = 0;
            opf.Top = (this.Controls.Count * opf.Height);
            this.Controls.Add(opf);
        }
    }
}
