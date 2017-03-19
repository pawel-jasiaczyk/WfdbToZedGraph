using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WfdbToZedGraph.SamplesConversion
{
    public partial class ConversionWindow : Form
    {
        public ZedGraphControl ZedGraphSource { get { return this.zedGraphControlSource; } }
        public ZedGraphControl ZedGraphSamples { get { return this.zedGraphControlSamples; } }

        public ConversionWindow()
        {
            InitializeComponent();
        }

        private void ConversionWindow_Load(object sender, EventArgs e)
        {
            this.zedGraphControlSource.PerformAutoScale();
            this.zedGraphControlSource.Refresh();
        }
    }
}
