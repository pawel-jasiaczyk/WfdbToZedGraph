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

            stb.Append("Sampling Frequency: ");
            stb.AppendLine(Signal.SamplingFrequency.ToString());

            stb.AppendLine();

            stb.Append("Adc resolution: ");
            stb.AppendLine(Signal.AdcResolution.ToString());

            stb.Append("Adc zero: ");
            stb.AppendLine(Signal.AdcZero.ToString());

            stb.Append("Base line: ");
            stb.AppendLine(Signal.Baseline.ToString());

            stb.Append("Block size: ");
            stb.AppendLine(Signal.BlockSize.ToString());

            stb.Append("CheckSum: ");
            stb.AppendLine(Signal.CheckSum.ToString());

            stb.Append("Current time: ");
            stb.AppendLine(Signal.CurrentTime.ToTimeSpan().ToString());

            stb.Append("Duration: ");
            stb.AppendLine(Signal.Duration.ToTimeSpan().ToString());

            stb.Append("Format: ");
            stb.AppendLine(Signal.Format.ToString());

            stb.Append("Gain: ");
            stb.AppendLine(Signal.Gain.ToString());

            stb.Append("Group: ");
            stb.AppendLine(Signal.Group);

            stb.Append("Is Eof: ");
            if (Signal.IsEof)
                stb.AppendLine("Yes");
            else
                stb.AppendLine("No");

            stb.Append("Samples per frame: ");
            stb.AppendLine(Signal.SamplesPerFrame.ToString());

            stb.Append("Skew: ");
            stb.AppendLine(Signal.Skew.ToString());

            stb.Append("Units: ");
            stb.AppendLine(Signal.Units.ToString());

            return stb.ToString();
        }
    }
}
