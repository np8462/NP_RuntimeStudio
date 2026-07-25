using System;
using System.Diagnostics;
using System.IO;

namespace NP.Storage.Runtime
{
    public static class StoragePaths
    {
        public static string TempFolder
        {
            get
            {
                return Path.Combine(
                    RuntimeFolder,
                    "Temp");
            }
        }
        public enum HostType
        {
            WinForms,
            VisualStudioAddIn
        }

        private static HostType? _forcedHost;

        /// <summary>
        /// Call this once from host (VS AddIn / WinForms / etc)
        /// </summary>
        public static void Initialize(HostType host)
        {
            _forcedHost = host;
        }

        /// <summary>
        /// Detect current runtime host
        /// </summary>
        public static HostType CurrentHost
        {
            get
            {
                if (_forcedHost.HasValue)
                    return _forcedHost.Value;

                string processName =
                    Process.GetCurrentProcess()
                        .ProcessName
                        .ToLower();

                if (processName.Contains("devenv"))
                    return HostType.VisualStudioAddIn;

                return HostType.WinForms;
            }
        }

        /// <summary>
        /// Root storage folder (SAFE for AddIn + WinForms)
        /// </summary>
        public static string RootFolder
        {
            get
            {
                // AddIn or Visual Studio host
                if (CurrentHost == HostType.VisualStudioAddIn)
                {
                    return Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "NP_RuntimeStudio");
                }

                // Normal desktop app
                return Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ApplicationData),
                    "NP_RuntimeStudio");
            }
        }

        /// <summary>
        /// Runtime base folder
        /// </summary>
        public static string RuntimeFolder
        {
            get
            {
                return Path.Combine(RootFolder, "Runtime");
            }
        }

        /// <summary>
        /// Projects folder
        /// </summary>
        public static string ProjectsFolder
        {
            get
            {
                return Path.Combine(RuntimeFolder, "Projects");
            }
        }

        /// <summary>
        /// Get project folder
        /// </summary>
        public static string GetProjectFolder(string projectName)
        {
            return Path.Combine(ProjectsFolder, projectName);
        }

        /// <summary>
        /// Get chats folder for a project
        /// </summary>
        public static string GetChatsFolder(string projectName)
        {
            return Path.Combine(GetProjectFolder(projectName), "Chats");
        }

        /// <summary>
        /// Ensure full directory tree exists safely
        /// </summary>
        public static void EnsureProjectStructure(string projectName)
        {
            Directory.CreateDirectory(GetProjectFolder(projectName));
            Directory.CreateDirectory(GetChatsFolder(projectName));
        }
    }


    public static class PathHelper
    {
        public static string GetConfigFolder()
        {
            string appData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData);

            string folder =
                Path.Combine(
                    appData,
                    "NP_AI_RuntimeStudio");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return folder;
        }
    }
}
/*
using System;
using System.IO;
using System.Windows.Forms;

namespace NP.Storage.Runtime
{
    public static class StoragePaths
    {
        public enum HostType
        {
            WinForms,
            VisualStudioAddIn
        }
        public static HostType CurrentHost
        {
            get
            {
                string exe =
                    AppDomain.CurrentDomain
                        .FriendlyName
                        .ToLower();

                if (exe.Contains("devenv"))
                {
                    return HostType.VisualStudioAddIn;
                }

                return HostType.WinForms;
            }
        }
        public static string RootFolder
        {
            get;
            set;
        }


        public static string RuntimeFolder
        {
            get
            {
                switch (CurrentHost)
                {
                    case HostType.VisualStudioAddIn:

                        return Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.MyDocuments),
                            "NP_RuntimeStudio",
                            "Runtime");

                    default:

                        return Path.Combine(
                            Application.StartupPath,
                            "Runtime");
                }


                //    if (!string.IsNullOrEmpty(RootFolder))
                //    {
                //        return Path.Combine(
                //            RootFolder,
                //            "Runtime");
                //    }

                //    return Path.Combine(
                //        Application.StartupPath,
                //        "Runtime");
                //}
            }
        }
    //    public static string RuntimeFolder
    //    {
    //        get
    //        {
    //            return Path.Combine(
    //                Application.StartupPath,
    //                "Runtime");
    ////            return Path.Combine(
    ////Environment.GetFolderPath(
    ////    Environment.SpecialFolder.MyDocuments),
    ////"NP_RuntimeStudio");
    //        }
    //    }

        public static string ProjectsFolder
        {
            get
            {
                return Path.Combine(
                    RuntimeFolder,
                    "Projects");
            }
        }

        public static string GetProjectFolder(
            string projectName)
        {
            return Path.Combine(
                ProjectsFolder,
                projectName);
        }

        public static string GetChatsFolder(
            string projectName)
        {
            return Path.Combine(
                GetProjectFolder(projectName),
                "Chats");
        }

    }
}
*/