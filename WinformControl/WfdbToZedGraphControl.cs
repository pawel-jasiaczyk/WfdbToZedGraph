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
    public partial class WfdbToZedGraphControl : UserControl
    {
        public ZedGraph.ZedGraphControl ZedGraphControl 
        {
            get { return this.signalsTreeView.ZedGraphConrol; }
            set { this.signalsTreeView.ZedGraphConrol = value; }
        }
        public WfdbToZedGraphBinder WfdbBinder { get; set; }
        public TreeNodeCollection TreeNodes { get { return this.signalsTreeView.Nodes; } }
        public WfdbToZedGraphControl()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            this.signalsTreeView.LoadToGraph();
        }

        private void signalsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is SignalTreeNode)
                this.textBoxInfo.Text = (e.Node as SignalTreeNode).GetInfo();
        }
    }
}
