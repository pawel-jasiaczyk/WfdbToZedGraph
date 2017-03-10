using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WfdbToZedGraph.WinformControl 
{
    public class SignalTreeNode : TreeNode
    {
        public WfdbSignalWraper Signal { get; set; }
        public CurveItem Curve { get; set; }
        
        public SignalTreeNode() : base()
        { }

        public SignalTreeNode(string text) : base(text)
        { }

        public SignalTreeNode(WfdbSignalWraper signal) : base()
        {
            this.Signal = signal;
            this.Text = "Signal " + signal.SignalNumber;
        }
    }
}
