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
    public class WfdbToZedGraphBinder : IDisposable
    {
        #region Variables

        private WfdbLocalFilesManager pathsManager;
        private List<WfdbRecordWraper> records;

        #endregion

        #region Properties

        public List<WfdbRecordWraper> Records { get { return this.records; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of ZedGraphForWfdbControl
        /// </summary>
        public WfdbToZedGraphBinder()
        {
            this.pathsManager = new WfdbLocalFilesManager(this);
            records = new List<WfdbRecordWraper>();
        }

        #endregion

        #region Open record methods
        
        public WfdbRecordWraper OpendRecordFromFile(string path)
        {
            try
            {
                WfdbRecordWraper result = this.pathsManager.OpenRecordFromFile(path);
                result.OnRemove += result_OnRemove;
                this.records.Add(result);
                return result;
            }
            catch
            {
                throw;
            }

        }

        public WfdbRecordWraper CreateEmptyRecord(string name)
        {
            WfdbRecordWraper result = 
                this.pathsManager.CreateEmptyRecord(name);
            this.records.Add(result);
            return result;
        }

        private void RemoveTempData(bool removeTempDirectory)
        {
            foreach(WfdbRecordWraper rec in this.records)
            {
                if(rec.UseTemp)
                {
                    rec.AutoRemove();
                }
            }
            this.pathsManager.TempCatalog.RemoveTempCatalog();
        }

        private void result_OnRemove(object sender, EventArgs e)
        {
            WfdbRecordWraper rec = sender as WfdbRecordWraper;
            if (rec != null)
            {
                if (this.records.Contains(rec))
                    this.records.Remove(rec);
            }
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
                this.pathsManager.TempCatalog =
                    new TempCatalog(this.pathsManager, true, true);
            }
            catch
            {
                throw;
            }
        }
    
        #endregion

        public void Dispose()
        {
            this.RemoveTempData(false);
        }
    }
}
