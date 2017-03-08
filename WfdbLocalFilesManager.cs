using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WfdbCsharpWrapper;
using System.Configuration;
using System.Text;
using System.Configuration;

namespace WfdbToZedGraph
{
    public class WfdbLocalFilesManager : IDisposable
    {
        #region Variables

        private WfdbToZedGraphBinder master;
        private bool isWfdbPathSet = false;
        private string tempPath = "";
        private string defaultTempName = "wfdbtemp";
        private char[] forbidenInPath = { ' ', '\r', '\n' };
        private bool tempWasSet = false;
        private string pathParamName = "wfdbTempDirectory";
        private List<string> paths;

        #endregion

        #region Properties

        public bool IsWfdbPathSet { get { return this.isWfdbPathSet; } }
        public string TempLocation { get { return this.tempPath; } }

        #endregion

        #region Constructors

        public WfdbLocalFilesManager(WfdbToZedGraphBinder zedgraphWfdbControl)
        {
            this.paths = new List<string>();
            LoadPathsFromEnvirontment();

            this.master = zedgraphWfdbControl;
            this.isWfdbPathSet = IsWfdbPathSetInSystem();
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
        /// <summary>
        /// Verify if path is correct for wfdb libraray
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsWfdbPathCorrect(string path)
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
            foreach(char forbiden in this.forbidenInPath)
            {
                if (path.Contains(forbiden.ToString()))
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Do not implemented
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetTempLocation(string path)
        {
            throw new NotImplementedException();
        }

        public void AutomaticSetTempLocation()
        {
            // TODO check if this path is set in app configuration
            // if it is - get it from app configuration and check if it is OK
            // if it is - set it for this object and return

            string userTempPath = Path.GetTempPath();
            string baseForTemp = "";
            if(IsWfdbPathCorrect(userTempPath))
                baseForTemp = userTempPath;
            else
            {
                baseForTemp = Path.GetPathRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            {
                string[] dirs = 
                    Directory.GetDirectories(baseForTemp);
                if (!dirs.Contains<string>(Path.Combine(baseForTemp, this.defaultTempName)))
                {
                    try
                    {
                        CreateTempDirectory(baseForTemp, defaultTempName);
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    bool done = false;
                    int i = 0;
                    string tempName = defaultTempName;
                    string p = "";
                    do
                    {
                        p = Path.Combine(baseForTemp, defaultTempName + i);
                        if(!dirs.Contains<string>(p))
                        {
                            try
                            {
                                CreateTempDirectory(baseForTemp, tempName + i);
                            }
                            catch
                            {
                                throw;
                            }
                            done = true;
                            break;
                        }
                        i++;
                    }
                    while (!done);
                }
            }
            SetLocationAsFirst(this.tempPath);
        }

        #endregion

        #region Private Methods

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

        private void SetLocationAsFirst(string path)
        {
            LoadPathsFromEnvirontment();
            this.paths.Insert(0, path);
            LoadPathsToEnvirontmen();
        }

        private void CreateTempDirectory(string path, string catalogName)
        {
            try
            {
                string finalPath = Path.Combine(path, catalogName);
                DirectoryInfo info =  Directory.CreateDirectory(finalPath);
                info.Attributes = FileAttributes.Hidden;
                this.tempPath = finalPath;
                this.tempWasSet = true;
                // TODO set this path in app config (if it exists)
                
                Configuration conf =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (ConfigurationManager.AppSettings[pathParamName] != null)
                {
                    conf.AppSettings.Settings[pathParamName].Value = this.tempPath;
                }
                else
                {
                    conf.AppSettings.Settings.Add(pathParamName, this.tempPath);
                }
                conf.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                throw;
            }
        }

        private void RemoveTempDirectory()
        {
            try
            {
                if(this.tempWasSet && Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                    this.tempWasSet = false;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            RemoveTempDirectory();
        }

        #endregion
    }
}
