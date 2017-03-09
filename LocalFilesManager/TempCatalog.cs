using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace WfdbToZedGraph.LocalFilesManager
{
    public class TempCatalog
    {
        #region Fields

        private string tempDirectoryPath;
        private string defaultTempName = "wfdbtemp";
        private WfdbLocalFilesManager wfdbLocalFilesManager;
        private string pathParameterName = "tempDirecory";

        #endregion

        #region Properties

        public bool SingleDirectoryForEveryRecord { get; set; }
        public bool UseAppSettings { get; set; }
        public bool ClearOnClose { get; set; }
        public bool DisposeAfterOneUse { get; set; }
        public bool UseIt { get; set; }
        public bool IsSet { get; set; }
        public string TempDirecotryPath { get { return this.tempDirectoryPath; } }

        #endregion

        #region Constructors

        public TempCatalog(WfdbLocalFilesManager wfdbLocalFilesManager)
            : this(wfdbLocalFilesManager, false, false)
        {
        }

        public TempCatalog(WfdbLocalFilesManager wfdbLocalFilesManager, bool autoCreate, bool useAppSettings)
        {
            this.wfdbLocalFilesManager = wfdbLocalFilesManager;
            this.UseAppSettings = useAppSettings;
            if(autoCreate) 
                AutomaticSetTempLocation();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Do not implemented
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetTempLocation(string path)
        {
            if (Directory.Exists(path))
            {
                this.tempDirectoryPath = path;
                this.IsSet = true; 
                
                // TODO set this path in app config (if it exists) 
                
                if (this.UseAppSettings)
                {
                    Configuration conf =
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (ConfigurationManager.AppSettings[pathParameterName] != null)
                    {
                        conf.AppSettings.Settings[pathParameterName].Value = this.tempDirectoryPath;
                    }
                    else
                    {
                        conf.AppSettings.Settings.Add(pathParameterName, this.tempDirectoryPath);
                    }
                    conf.Save(ConfigurationSaveMode.Modified);
                }
                return true;
            }
            return false;
        }

        public void AutomaticSetTempLocation()
        {
            // TODO Check if creation of dir is allowed
            // Exception if it is not
            
            // TODO check if this path is set in app configuration
            // if it is - get it from app configuration and check if it is OK
            // if it is - set it for this object and return

            bool needToCreate = true; 
            if(UseAppSettings)
            {
                // Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if(ConfigurationManager.AppSettings[pathParameterName] != null)
                {
                    if (Directory.Exists(ConfigurationManager.AppSettings[pathParameterName]))
                    {
                        this.SetTempLocation(ConfigurationManager.AppSettings[pathParameterName]);
                        needToCreate = false;
                    }
                    else
                    {
                        CreateTempDirectory(ConfigurationManager.AppSettings[pathParameterName], "");
                        needToCreate = false;
                    }
                }
            }
            if (needToCreate)
            {
                string userTempPath = Path.GetTempPath();
                string baseForTemp = "";
                if (WfdbLocalFilesManager.IsWfdbPathCorrect(userTempPath))
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
                            if (!dirs.Contains<string>(p))
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
            }
            this.wfdbLocalFilesManager.SetLocationAsFirst(this.tempDirectoryPath);
        }

        #endregion

        #region Private Methods

        private void CreateTempDirectory(string path, string catalogName)
        {
            try
            {
                string finalPath;
                if (string.IsNullOrEmpty(catalogName))
                    finalPath = path;
                else
                    finalPath = Path.Combine(path, catalogName);
                if (!Directory.Exists(finalPath))
                {
                    DirectoryInfo info = Directory.CreateDirectory(finalPath);
                    info.Attributes = FileAttributes.Hidden;
                }
                this.SetTempLocation(finalPath);
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
                if(this.IsSet && Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                    this.IsSet = false;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
