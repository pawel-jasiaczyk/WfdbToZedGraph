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
                for (int i = 0; i < this.pointPairList.Count; i++)
                {
                    int maxSampleNumber = (int)(this.pointPairList[i].X * freq);



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


        #endregion
    }
}
