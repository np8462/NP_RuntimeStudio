using NP.Services.RuntimeBridge;
using System;
using System.IO;
using System.Windows.Forms;

namespace NP.VSExtension
{
    internal static class RuntimeBridgeEnvironment
    {
        private const string ConfigFileName =
            "NP.VSExtension.Runtime.config";

        //-------------------------------------------------

        public static void Initialize()
        {
            RuntimeBridgeLauncher.RuntimeBridgePath =
                GetRuntimeBridgePath();
        }

        //-------------------------------------------------

        public static string GetRuntimeBridgePath()
        {
            string path =
                Load();

            if (!String.IsNullOrWhiteSpace(path))
            {
                if (File.Exists(path))
                    return path;
            }

            path =
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "NP.Host.RuntimeBridge.exe");

            if (File.Exists(path))
            {
                Save(path);

                return path;
            }
            path =
    BrowseForRuntimeBridge();

            if (!String.IsNullOrWhiteSpace(path))
            {
                Save(path);

                return path;
            }

            return null;
        }

        //-------------------------------------------------

        private static string Load()
        {
            if (!File.Exists(ConfigFile))
                return null;

            foreach (string line in File.ReadAllLines(ConfigFile))
            {
                if (line.StartsWith("RuntimeBridgePath="))
                {
                    return line.Substring(
                        "RuntimeBridgePath=".Length);
                }
            }

            return null;
        }

        //-------------------------------------------------

        private static void Save(string path)
        {
            File.WriteAllText(
                ConfigFile,
                "RuntimeBridgePath=" + path);
        }

        private static string BrowseForRuntimeBridge()
        {
            OpenFileDialog dlg =
                new OpenFileDialog();

            dlg.Title =
                "Locate NP.Host.RuntimeBridge.exe";

            dlg.Filter =
                "Runtime Bridge|NP.Host.RuntimeBridge.exe";

            dlg.CheckFileExists = true;

            dlg.Multiselect = false;

            if (dlg.ShowDialog() != DialogResult.OK)
                return null;

            return dlg.FileName;
        }

        private static string ConfigFile
        {
            get
            {
                string folder =
                    Path.GetDirectoryName(
                        typeof(RuntimeBridgeEnvironment)
                            .Assembly.Location);

                return Path.Combine(
                    folder,
                    "NP.VSExtension.Runtime.config");
            }
        }
    }
}