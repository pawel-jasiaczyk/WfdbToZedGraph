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

        private int signalNumber;
        private int numberOfSambples;
        private PointPairList samples;
        private string fileName;
        private string description;

        #endregion

        #region Properties

        public int SignalNumber
        {
            get { return this.signalNumber; }
        }

        public int SignalNumberOfSamples
        { 
            get { return this.numberOfSambples; } 
        }

        public string FileName { get { return this.fileName; } }
        public bool AlreadyOpened 
        { 
            get 
            {
                if (samples == null)
                    return false;
                else
                    return true;
            } 
        }

        public bool OpenedByWfdb { get; private set; }

        #endregion

        #region Constructors

        public WfdbSignalWraper(Signal signal)
        {
            this.signal = signal;
            this.signalNumber = signal.Number;
            this.numberOfSambples = signal.NumberOfSamples;
            this.fileName = signal.FileName;
            this.description = signal.Description;
            this.OpenedByWfdb = true;
        }

        public WfdbSignalWraper(PointPairList pointPairList, string name, int number)
        {
            if(pointPairList == null)
                throw new NullReferenceException();
            this.OpenedByWfdb = false;
            this.fileName = "";
            this.signalNumber = 0;
        }

        #endregion

        #region PublicMethods

        public PointPairList GetSamples()
        {
            if (this.samples == null)
            {
                return this.ReadSamplesFromRecord();
            }
            else
                return this.samples;
        }

        public PointPairList ReadSamplesFromRecord()
        { 
            this.samples = new PointPairList();
            List<WfdbCsharpWrapper.Sample> samples = signal.ReadAll().ToList();
            for (int i = 0; i < this.signal.NumberOfSamples; i++)
            {
                this.samples.Add(i, samples[i]);
            }
            return this.samples;
        }

        #endregion
    }
}
