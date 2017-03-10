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

        public string GetInfo()
        {
            StringBuilder stb = new StringBuilder();
            stb.Append("Name: ");
            stb.Append(Signal.FileName);
            stb.Append(" signal: ");
            stb.AppendLine(Signal.SignalNumber.ToString());
            stb.Append("Samples: ");
            stb.AppendLine(Signal.SignalNumberOfSamples.ToString());
            stb.Append("Opened: ");
            if (Signal.AlreadyOpened)
                stb.AppendLine("Yes");
            else
                stb.AppendLine("No");
            return stb.ToString();
        }
    }
}
