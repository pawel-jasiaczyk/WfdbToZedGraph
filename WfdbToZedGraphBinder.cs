using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ZedGraph;
using WfdbCsharpWrapper;
using WfdbToZedGraph.LocalFilesManager;

namespace WfdbToZedGraph
{
    public class WfdbToZedGraphBinder
    {
        #region Variables

        private Record record;
        private List<PointPairList> points;
        private WfdbLocalFilesManager pathsManager;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets array of PointPairLists for ZedGraph made from WFDB record
        /// </summary>
        public PointPairList[] Points { get { return this.points.ToArray(); } }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of ZedGraphForWfdbControl
        /// </summary>
        public WfdbToZedGraphBinder()
        {
            this.points = new List<PointPairList>();
            // at this moment, path manager (and all elements connected with wfdb.dll)
            // must be enabled externaly, becouse WinForms Designer do not want
            // work with them
            // this.pathsManager = new WfdbLocalPathsManager(this);

        }

        #endregion

        #region Open record methods
        
        /// <summary>
        /// Opens WFDB record and returns PointPairList array
        /// with dataset for ZedGraph
        /// 
        /// Database location must be set first!!!
        /// </summary>
        /// <param name="path">Path to files you want to read</param>
        /// <returns>Array of PointPairList</returns>
        public PointPairList[] GetProbesFromRecord(string path)
        {
            try
            {
                OpenRecordFile(path);
                return this.Points;
            }
            catch 
            {
                throw;
            }
            finally
            {
                if (!Object.ReferenceEquals(this.record, null)) record.Dispose();
            }
        }
        
        /// <summary>
        /// Opens new record from selected path
        /// Database location must be set first!!!!
        /// </summary>
        /// <param name="path"></param>
        public void OpenRecord(string path)
        {
            try
            {
                OpenRecordFile(path);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (!Object.ReferenceEquals(this.record, null)) record.Dispose();
            }
        }
        
        private void OpenRecordFile(string path)
        {
            
            try
            {
                Record record = LoadRecordFile(path);

                WfdbRecordWraper rec = new WfdbRecordWraper(record);
                
                // record.Open();
                
                // reset point list for all chanels
                // this.points = new List<PointPairList>();
                // foreach(Signal signal in record.Signals)
                // {
                //     PointPairList temp = new PointPairList();
                //     List<WfdbCsharpWrapper.Sample> samples = signal.ReadAll().ToList();
                //     for (int i = 0; i < signal.NumberOfSamples; i++ )
                //     {
                //         temp.Add(i, samples[i]);   
                //     }

                //     this.points.Add(temp);
                // }
            }
            catch 
            {
                throw;
            }
        }
        
        /// <summary>
        /// Locate correct record in setted locations
        /// </summary>
        /// <param name="path">Path to record location</param>
        /// <returns>Record obcject</returns>
        /// <exception cref="">Rethrows catched exceptions from wfdb</exception>
        private Record LoadRecordFile(string path)
        {
            if (!this.pathsManager.IsWfdbPathSet)
                throw new WfdbPathException("Path to database is not set!");
            try
            {
                string name = Path.GetFileNameWithoutExtension(path);
                this.record = new Record(name);
                return record;
            }
            catch
            {
                throw;
            }
        }

        public void OpenSelectedRecordFromFile(string path)
        {

        }

        #endregion

        #region Database location methods
        /// <summary>
        /// Must be sure, that PathManager is set!
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetDataBaseLocation(string path)
        {
            try
            {
                return this.pathsManager.SetDataBaseLocation(path);
            }
            catch
            {
                throw;
            }
        }

        public bool AddDataBaseLocation(string path) 
        {
            try
            {
                return this.pathsManager.AddDataBaseLocation(path);
            }
            catch
            {
                throw;
            }
        }
    
        public bool IsWfdbPathCorrect(string path) 
        {
            try
            {
                return  WfdbLocalFilesManager.IsWfdbPathCorrect(path);

            }
            catch
            {
                throw;
            }
        }

        public bool SetTempLocation(string path) 
        {
            try
            {
                return this.pathsManager.TempCatalog.SetTempLocation(path);
            }
            catch
            {
                throw;
            }
        }

        public void AutomaticSetTempLocation() 
        {
            try
            {
                this.pathsManager.TempCatalog.AutomaticSetTempLocation();
            }
            catch
            {
                throw;
            }
        }
    
        #endregion

        //public void RunPathManager()
        //{
        //    this.pathsManager = new WfdbLocalFilesManager(this);
        //    this.pathsManager.AutomaticSetTempLocation();
        //}
    }
}
