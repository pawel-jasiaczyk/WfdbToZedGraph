using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfdbCsharpWrapper;

namespace WfdbToZedGraph
{
    public class WfdbRecordWraper
    {
        private WfdbCsharpWrapper.Record record;
        // private List<Signal> sourceSignals;
        private List<WfdbSignalWraper> signals;

        public List<WfdbSignalWraper> Signals { get { return this.signals; } }

        public WfdbRecordWraper(WfdbCsharpWrapper.Record record)
        {
            this.record = record;
            this.record.Open();
            this.signals = new List<WfdbSignalWraper>();
            foreach(Signal s in this.record.Signals)
            {
                this.signals.Add(new WfdbSignalWraper(s));
            }
//          this.sourceSignals = new List<Signal>();
//             this.sourceSignals = this.record.Signals.ToList<Signal>();
        }
    }
}
