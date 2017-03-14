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
    public class WfdbLocalFilesManager //: IDisposable
    {
        #region Fields

        private WfdbToZedGraphBinder master;
        private bool isWfdbPathSet = false;
        private bool tempWasSet = false;
        private string pathParamName = "wfdbTempDirectory";
        private List<string> paths;
        private TempCatalog tempCatalog;

        #endregion

        #region Static Fields

        private static char[] ForbidenInPath = { ' ', '\r', '\n' };
        private static string[] recordExtensions = { "ari", "atr", "dat", "hea" };

        #endregion

        #region Properties

        public bool IsWfdbPathSet { get { return this.isWfdbPathSet; } }
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
        /// This method set location hard.
        /// If you want to add location, use AddDataBaseLocation
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
                    this.paths.Clear();
                    this.paths.Add(path);
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
                    this.paths.Add(path);
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

        public WfdbRecordWraper OpenRecordFromFile(string path)
        {
            Record r;
            string[] exts =  {};
            try
            {
                if(Directory.Exists(Path.GetDirectoryName(path)))
                {
                    if(this.tempCatalog.IsSet)
                    {
                        exts = CopyRecordFiles(Path.GetFileNameWithoutExtension(path), path, this.tempCatalog.TempDirecotryPath);
                        r = new Record(Path.GetFileNameWithoutExtension(path));
                        // return toReturn;
                    }
                    else
                    {
                        // TODO manage path for open correct record, if this path is set in 
                        // environment variables
                        r = new Record(Path.GetFileNameWithoutExtension(path));
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
            // Record r = this.GetRecordFromFile(path);
            if (r != null)
            {
                WfdbRecordWraperInstance result = new WfdbRecordWraperInstance(r);
                result.UsedExtensions = exts;
                result.UseTemp = this.tempCatalog.IsSet;
                result.TempPath = this.tempCatalog.TempDirecotryPath;
                result.OnRemove += result_OnRemove;
                return result;
            }
            return null;
        }

        // All functionalities moved to OpenRecordFromFile
        private Record GetRecordFromFile(string path)
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
            if (!this.paths.Contains(path))
            {
                this.paths.Insert(0, path);
            }
            else
            {
                int index = paths.IndexOf(path);
                if (index != 0)
                {
                    paths.RemoveAt(index);
                    paths.Insert(0, path);
                }
            }
            LoadPathsToEnvirontmen();
        }

        public static void SaveTextFile(string text, string path, string name, string extension)
        {
            string fileName = name + "." + extension;
            string fullName = Path.Combine(path, fileName);
            SaveTextFile(text, fullName);
        }

        public static void SaveTextFile(string text, string fullName)
        {
            FileInfo fi = new FileInfo(fullName);
            using(StreamWriter sw = fi.CreateText())
            {
                sw.Write(text);
            }
        }

        #endregion

        #region Private Methods

        private string[] CopyRecordFiles(string recordName, string sourcePath, string targetPath)
        {
            List<string> usedExtensions = new List<string>();
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
                            usedExtensions.Add(ext);
                        }
                    }
                    return usedExtensions.ToArray();
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

        /// <summary>
        /// Delete only temporary files of record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private bool DeleteRecordFiles(WfdbRecordWraper record)
        {
            if (record.UseTemp)
            {
                foreach (string ext in record.UsedExtensions)
                {
                    string fileName = record.Name + "." + ext;
                    string fullPath = Path.Combine(record.TempPath, fileName);
                    FileInfo fi = new FileInfo(fullPath);
                    try
                    {
                        if (fi.Exists)
                            fi.Delete();
                    }
                    catch
                    {
                        throw;
                    }
                }
                return true;
            }
            return false;
        }

        private void result_OnRemove(object sender, EventArgs e)
        {
            WfdbRecordWraper rec = sender as WfdbRecordWraper;
            if (rec != null)
                this.DeleteRecordFiles(rec);
        }

        #endregion

        #region IDisposable implementation

//        public void Dispose()
//        {
////            RemoveTempDirectory();
//        }

        #endregion
    }
}
