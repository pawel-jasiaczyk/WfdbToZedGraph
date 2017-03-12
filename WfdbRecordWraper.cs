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
            if (this.UseTemp)
                this.DeleteFiles();
            return true;
        }

        private void DeleteFiles()
        { }

        #endregion
    }
}
