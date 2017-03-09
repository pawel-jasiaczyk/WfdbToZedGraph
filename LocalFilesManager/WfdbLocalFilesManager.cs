using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WfdbCsharpWrapper;
using System.Configuration;

namespace WfdbToZedGraph.LocalFilesManager
{
    public class WfdbLocalFilesManager : IDisposable
    {
        #region Fields

        private WfdbToZedGraphBinder master;
        private bool isWfdbPathSet = false;
        private string tempPath = "";
        private bool tempWasSet = false;
        private string pathParamName = "wfdbTempDirectory";
        private List<string> paths;
        private TempCatalog tempCatalog;

        #endregion

        #region Static Fields

        private static char[] ForbidenInPath = { ' ', '\r', '\n' };
        private static string[] recordExtensions = { "atr", "dat", "hea" };

        #endregion

        #region Properties

        public bool IsWfdbPathSet { get { return this.isWfdbPathSet; } }
        // public string TempLocation { get { return this.tempPath; } }
        public TempCatalog TempCatalog 
        { 
            get 
            { 
                return this.tempCatalog; 
            } 
            set
            {
                this.tempCatalog = value;
            }
        }

        // Unused yet
        public bool UseAppSettings { get; set; }

        #endregion

        #region Constructors

        public WfdbLocalFilesManager(WfdbToZedGraphBinder wfdbToZedGraphBinder)
        {
            this.paths = new List<string>();
            LoadPathsFromEnvirontment();

            this.master = wfdbToZedGraphBinder;
            this.isWfdbPathSet = IsWfdbPathSetInSystem();
            // this.tempCatalog = new TempCatalog(this, true, true);
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Verify if path is correct for wfdb libraray
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsWfdbPathCorrect(string path)
        {
            // According to WFDB documentation, environtment variables should not have white 
            // spaces in names of catalogs
            
            // path set as " " is correct for current catalog of aplication
            if (path == " ") return true;

            // check if drive letters are the same
            // It do not want work with data on different drive
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appDriveLetter = Path.GetPathRoot(appPath);
            string pathDriveLetter = Path.GetPathRoot(path);
            if (pathDriveLetter.ToLower() != appDriveLetter.ToLower()) return false;
            
            // there could not be any white chars in path
            foreach(char forbiden in ForbidenInPath)
            {
                if (path.Contains(forbiden.ToString()))
                    return false;
            }

            return true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set this path as database location
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetDataBaseLocation(string path)
        {
            if (IsWfdbPathCorrect(path))
            {
                try
                {
                    Wfdb.WfdbPath = path;
                    this.isWfdbPathSet = true;
                    return true;
                }
                catch
                {
                    throw;
                }
            }
            else
                return false;
        }
        /// <summary>
        /// Adds ew path as database location
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddDataBaseLocation(string path)
        {
            if (IsWfdbPathCorrect(path))
            {
                try
                {
                    String lastPath = Wfdb.WfdbPath;
                    Wfdb.WfdbPath = Wfdb.WfdbPath + ";" + path;
                    this.isWfdbPathSet = true;
                    return true;
                }
                catch
                {
                    throw;
                }
            }
            else 
                return false;
        }

        public Record GetRecordFromFile(string path)
        {
            try
            {
                if(Directory.Exists(Path.GetDirectoryName(path)))
                {
                    if(this.tempCatalog.IsSet)
                    {
                        CopyRecordFiles(Path.GetFileNameWithoutExtension(path), path, this.tempCatalog.TempDirecotryPath);
                        Record toReturn = new Record(Path.GetFileNameWithoutExtension(path));
                        return toReturn;
                    }
                    else
                    {
                        // TODO manage path for open correct record, if this path is set in 
                        // environment variables
                        return new Record(Path.GetFileNameWithoutExtension(path));
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException(path);
                }
            }
            catch
            {
                throw;
            }
        }

        public void SetLocationAsFirst(string path)
        {
            LoadPathsFromEnvirontment();
            this.paths.Insert(0, path);
            LoadPathsToEnvirontmen();
        }
        #endregion

        #region Private Methods

        private void CopyRecordFiles(string recordName, string sourcePath, string targetPath)
        {
            try
            {
                if(Directory.Exists(Path.GetDirectoryName(sourcePath)) && 
                    Directory.Exists(Path.GetDirectoryName(targetPath)))
                {
                    foreach(string ext in recordExtensions)
                    {
                        string fileName = recordName + "." + ext;
                        string target = Path.Combine(targetPath, fileName);
                        // if any files of record exist in target path, delete it
                        // beause all record files must be get from fresh record
                        if(File.Exists(target))
                        {
                            File.Delete(target);
                        }
                        string source = Path.Combine(Path.GetDirectoryName(sourcePath), fileName);
                        // copy all record files
                        if(File.Exists(source))
                        {
                            File.Copy(source, target, true);
                        }
                    }
                }
                else
                {
                    // TODO specyfi whitch one directory do not exist
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            {
                throw;
            }
        }

        private bool IsWfdbPathSetInSystem()
        {
            string paths =
                Environment.GetEnvironmentVariable("WFDB", EnvironmentVariableTarget.Process);
            if (!String.IsNullOrEmpty(paths))
            {
                
                if(IsWfdbPathCorrect(paths)) return true;
            }
            return false;
        }
        
        private void LoadPathsFromEnvirontment()
        {
            this.paths = new List<string>();
            string locations = Wfdb.WfdbPath;
            int index = locations.IndexOf(';');
            while(index >= 0)
            {
                this.paths.Add(locations.Substring(0, index));
                locations = locations.Substring(index);
            }
        }

        private void LoadPathsToEnvirontmen()
        {
            StringBuilder stb = new System.Text.StringBuilder();
            for(int i = 0; i < this.paths.Count; i++)
            {
                stb.Append(this.paths[i]);
                if (i < this.paths.Count - 1)
                    stb.Append(";");
            }
            Wfdb.WfdbPath = stb.ToString();
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            
            //            RemoveTempDirectory();
        }

        #endregion
    }
}
