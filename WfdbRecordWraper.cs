using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfdbCsharpWrapper;

namespace WfdbToZedGraph
{
    public abstract class WfdbRecordWraper
    {
        #region Fields

        private WfdbCsharpWrapper.Record record;
        private List<WfdbSignalWraper> signals;
        private List<string> usedExtensions;

        #endregion

        #region Properties

        public List<WfdbSignalWraper> Signals { get { return this.signals; } }
        public string Name { get; set; }
        public bool UseTemp { get; set; } 
        public string TempPath { get; set; }
        public string[] UsedExtensions { get; set; }

        #endregion

        #region Events

        public event EventHandler OnRemove;

        #endregion

        #region Constructors

        public WfdbRecordWraper(WfdbCsharpWrapper.Record record)
        {
            this.usedExtensions = new List<string>();
            this.record = record;
            this.record.Open();
            this.signals = new List<WfdbSignalWraper>();
            foreach(Signal s in this.record.Signals)
            {
                this.signals.Add(new WfdbSignalWraper(s));
            }
            this.Name = record.Name;
        }

        #endregion

        #region Remove Methods

        public bool AutoRemove()
        {
            this.record.Dispose();
            if (this.OnRemove != null)
                this.OnRemove(this, new EventArgs());
            return true;
        }

        #endregion

        #region Write Methods

        public string GetCsvString()
        {
            StringBuilder stb = new StringBuilder();
            // Get the longest signal;
            int maxLength = 0;
            foreach(WfdbSignalWraper sig in this.signals)
            {
                if (sig.SignalNumberOfSamples > maxLength)
                    maxLength = sig.SignalNumberOfSamples;
            }
            // loop over all samples
            for (int i = 0; i < maxLength; i++)
            {
                // loop over all signals
                for(int j = 0; j < this.signals.Count; j++)
                {
                    WfdbSignalWraper sig = this.signals[j];
                    if (sig.SignalNumberOfSamples > i)
                        stb.Append(sig.GetSamples()[i].Y);
                    else
                        stb.Append("0");
                    if (j == this.signals.Count - 1)
                        stb.AppendLine("");
                    else
                        stb.Append(',');
                }
            }
            return stb.ToString();
        }

        #endregion
    }
}
