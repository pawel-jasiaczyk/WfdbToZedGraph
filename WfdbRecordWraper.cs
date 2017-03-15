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
        public bool UseTemp { get; protected set; } 
        public string TempPath { get; set; }
        public string[] UsedExtensions { get; set; }
        public bool CreatedByWfdb { get; private set; }

        #endregion

        #region Events

        public event EventHandler OnRemove;

        #endregion

        #region Constructors

        public WfdbRecordWraper(WfdbCsharpWrapper.Record record) 
            : this()
        {
            this.record = record;
            this.record.Open();
            foreach(Signal s in this.record.Signals)
            {
                this.signals.Add(new WfdbSignalWraper(s));
            }
            this.Name = record.Name;
            this.CreatedByWfdb = true;
        }

        public WfdbRecordWraper(string name)
            : this()
        {
            this.Name = name;
            this.record = null;
            this.CreatedByWfdb = false;
            this.UseTemp = false;
        }

        private WfdbRecordWraper()
        {
            this.usedExtensions = new List<string>();
            this.signals = new List<WfdbSignalWraper>();
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

        #region Signal Methods
        /// <summary>
        /// Add Signal by SignalWraper.
        /// Signals can be added only for record created as empty.
        /// Record created by Wfdb will not allow to add signal.
        /// </summary>
        /// <param name="wfdbSignalWraper"></param>
        /// <returns></returns>
        public bool AddSignal(WfdbSignalWraper wfdbSignalWraper)
        {
            if (this.record == null)
            {
                this.signals.Add(wfdbSignalWraper);
                return true;
            }
            else
                return false;
        }

        #endregion
    }
}
