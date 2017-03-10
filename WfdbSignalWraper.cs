using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfdbCsharpWrapper;
using ZedGraph;

namespace WfdbToZedGraph
{
    public class WfdbSignalWraper
    {
        #region Variables

        private Signal signal;

        #endregion

        #region Properties

        public int SignalNumber
        {
            get { return signal.Number; }
        }

        public int SignalNumberOfSamples
        { 
            get { return this.signal.NumberOfSamples; } 
        }

        #endregion

        #region Constructors

        public WfdbSignalWraper(Signal signal)
        {
            this.signal = signal;
        }

        #endregion

        #region PublicMethods

        public PointPairList GetSamples()
        {
            PointPairList temp = new PointPairList();
            List<WfdbCsharpWrapper.Sample> samples = signal.ReadAll().ToList();
            for(int i = 0; i < this.signal.NumberOfSamples; i++)
            {
                temp.Add(i, samples[i]);
            }
            return temp;
        }

        #endregion
    }
}
