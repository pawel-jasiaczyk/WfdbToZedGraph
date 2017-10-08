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

        #region events

        public event EventHandler StatusUpdate;

        #endregion


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

        // Added 2017-10-08
        public int AdcResolution { get; private set; }
        public int AdcZero { get; private set; }
        public int Baseline { get; private set; }
        public int BlockSize { get; private set; }
        public int CheckSum { get; private set; }
        public Time CurrentTime { get; private set; }
        public Time Duration { get; private set; }
        public String Format { get; private set; }
        public double Gain { get; private set; }
        public string Group { get; private set; }
        public bool IsEof { get; private set; }
        public int SamplesPerFrame { get; private set; }
        public int Skew { get; private set; }
        public string Units { get; private set; }

        public int InitValueSignalNumber { get; private set; }
        public int InitValueAdu { get; private set; }


        public TimeSpan TimeDiff { get; private set; }

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

            // added 2017-10-08
            this.AdcResolution = signal.AdcResolution;
            this.AdcZero = signal.AdcZero;
            this.Baseline = signal.Baseline;
            this.BlockSize = signal.BlockSize;
            this.CheckSum = signal.CheckSum;
            this.CurrentTime = signal.CurrentTime;
            this.Duration = signal.Duration;
            this.Format = signal.Format.ToString();
            this.Gain = signal.Gain; //  != null ? signal.Gain.Value: 0;
            this.Group = signal.Group.ToString();
            this.InitValueSignalNumber = signal.InitValue.SignalNumber;
            this.InitValueAdu = signal.InitValue.Adu;
            this.IsEof = signal.IsEof;
            // this.Record = signal.Record;
            this.SamplesPerFrame = signal.SamplesPerFrame;
            this.Skew = signal.Skew;
            this.Units = signal.Units != null ? signal.Units : "";

            this.TimeDiff = new TimeSpan(this.Duration.ToTimeSpan().Ticks / this.numberOfSambples);
        }

        public WfdbSignalWraper(PointPairList pointPairList, string name, int number)
        {
            if(pointPairList == null)
                throw new NullReferenceException();
            this.OpenedByWfdb = false;
            this.fileName = "";
            this.signalNumber = 0;
            this.numberOfSambples = pointPairList.Count;
            this.samples = pointPairList;
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
            int fivePercent = this.numberOfSambples / 20;

            this.samples = new PointPairList();
            List<WfdbCsharpWrapper.Sample> samples = signal.ReadAll().ToList();
            for (int i = 0; i < this.signal.NumberOfSamples; i++)
            {
                if (((i % fivePercent) == 0 && this.StatusUpdate != null))
                    this.StatusUpdate(this,
                        new OpenSignalEventArgs
                        {
                            Finished = false,
                            SignalName = string.Format("File: {0} Signal: {1}",this.fileName, SignalNumber.ToString()),
                            PercentageStatus = (int)(((double)i / this.signal.NumberOfSamples) * 100)
                        }
                     );
                this.samples.Add(i, samples[i]);
            }
            return this.samples;
        }

        public PointPairList ReadAndFormatSamplesFromRecord ()
        {
            // double timeDist = this.Duration.ToTimeSpan().Milliseconds / this.numberOfSambples; 

            this.samples = new PointPairList();
            List<WfdbCsharpWrapper.Sample> samples = signal.ReadAll().ToList();
            for(int i = 0; i < this.signal.NumberOfSamples; i++)
            {
                this.samples.Add(i, samples[i]);
            }
            return this.samples;
        }

        #endregion
    }

    public class OpenSignalEventArgs : EventArgs
    {
        public int PercentageStatus { get; set; }
        public bool Finished { get; set; }
        public string SignalName { get; set; }
    }
}
