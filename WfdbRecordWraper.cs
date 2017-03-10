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
        #region Fields

        private WfdbCsharpWrapper.Record record;
        private List<WfdbSignalWraper> signals;

        #endregion

        #region Properties

        public List<WfdbSignalWraper> Signals { get { return this.signals; } }
        public string Name { get; set; }

        #endregion

        #region Constructors

        public WfdbRecordWraper(WfdbCsharpWrapper.Record record)
        {
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
   }
}
