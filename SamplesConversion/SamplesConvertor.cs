using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WfdbToZedGraph.SamplesConversion
{
    public class SamplesConvertor
    {
        #region Fieds

        private double freq;
        private int result;
        private PointPairList pointPairList;
        
        // bit resolution
        private uint bitResolution;
        private int maxDigitalValue;
        private int minDigitalValue;

        #endregion

        #region Properties

        public double TimeInterval 
        {
            get 
            {
                if (this.freq != 0)
                    return (1.0 / this.freq);
                else
                    return 1.0;
            }
            set 
            {
                if (value != 0)
                    this.freq = (1.0 / Math.Abs(value));
                else
                {
                    this.freq = 1.0;
                    throw new ArgumentException("Timeinterval cannot be zero!", "TimeInterval");
                }
            } 
        }
        
        public double SamplingFrequency 
        {
            get { return this.freq; }
            set
            {
                if (value != 0)
                    this.freq = Math.Abs(value);
                else
                {
                    this.freq = 1.0;
                    throw new ArgumentException("SamplingFrequency cannot be zero!", "SamplingFrequency");
                }
            }
        }

        public int SamplingMode { get; set; }

        public double MaxPhysicalValue { get; set; }
        public double MinPhysicalValue { get; set; }
        public uint BitResolution
        {
            get { return bitResolution; }
            set 
            { 
                bitResolution = value;
                SetDigitalRanges();
            }
        }

        #endregion

        #region Constructors

        public SamplesConvertor()
        {
            this.freq = 1.0;
        }
        
        #endregion

        #region Conversion Public Methds

        public int[] ConvertPointPairListToRegularSamples(PointPairList pointPainrList)
        {
            this.pointPairList = pointPairList;
            
            int[] result = new int[FindNumberOfSamples()];
            return result;
        }

        private int FindNumberOfSamples()
        {
            // find higher value of X
            if (!this.pointPairList.Sorted)
                this.pointPairList.Sort(SortType.XValues);
            int lastIndex = this.pointPairList.Count - 1;
            double maxValue = this.pointPairList[lastIndex].X;
            int result = (int)(Math.Floor(maxValue * freq) + 1);
            return result;
        }

        // Convert to private
        public double[] Sampling(PointPairList pointPairList)
        {
            this.pointPairList = pointPairList; // remove later
            int numberOfSamples = FindNumberOfSamples();
            double[] result = new double[numberOfSamples];
            int currentResultSample = 0;
            if (this.SamplingMode == 0) // Only one sample get last value
            {
                for (int i = 0; i < this.pointPairList.Count; i++) // not sure if it works properly - i'm tired
                {
                    int maxSampleNumber = (int)(this.pointPairList[i].X * freq);
                    for (; currentResultSample < maxSampleNumber; currentResultSample++)
                        result[currentResultSample] = 0.0;
                    result[maxSampleNumber] = this.pointPairList[i].Y;
                    currentResultSample = maxSampleNumber + 1;
                }
            }
            else // Each sample after one from source get ist vaule (untill there will not get another sample);
            {
                for(int i = 0; i < this.pointPairList.Count; i++)
                {
                    int maxSampleNumber = (int)(this.pointPairList[i].X * freq);
                    double sampleValue = 0.00; 
                    if(i > 0) sampleValue = this.pointPairList[i - 1].Y;
                    for (; currentResultSample <= maxSampleNumber; currentResultSample++)
                        result[currentResultSample] = sampleValue;
                }
            }


            for (int i = 0; i < numberOfSamples; i++) 
            {
//               pointPairList.
                int j = i;
            }

            return result;
        }
        
        private void SetDigitalRanges()
        {
            this.maxDigitalValue = (int)Math.Pow(2, bitResolution - 1) - 1;
            this.minDigitalValue = (-(int)Math.Pow(2, bitResolution - 1));
        }

        #endregion
    }
}
