using System.Collections.Generic;
using NP.Core.Components;
using System;
using NP.Services.Development;

namespace NP.Services.Components
{
    public class ComponentWorkspace
    {
        public event EventHandler LogsChanged;
        public event EventHandler WorkspaceChanged;
        private readonly DevelopmentWorkspace _development;

        public BuildManager BuildManager
        {
            get;
            private set;
        }

        public DevelopmentWorkspace Development
        {
            get;
            private set;
        }

        public string Folder { get; set; }

        public IList<ComponentInfo> Components { get; private set; }

        public IList<DependencyInfo> Dependencies { get; private set; }

        public IList<RuntimeComponent> RuntimeComponents { get; private set; }

        public IList<RuntimeInstance> RuntimeInstances { get; private set; }

        public IList<RuntimeLogInfo> Logs { get; private set; }

        public ComponentLoader Loader
        {
            get;
            private set;
        }

        public ReflectionScanner Scanner
        {
            get;
            private set;
        }

        public ComponentActivator Activator
        {
            get;
            private set;
        }

        public ComponentRegistry Registry
        {
            get;
            private set;
        }

        public RuntimeHost Host
        {
            get;
            private set;
        }

        public ComponentWorkspace()
        {
            Components = new List<ComponentInfo>();

            Dependencies = new List<DependencyInfo>();

            RuntimeComponents = new List<RuntimeComponent>();

            RuntimeInstances = new List<RuntimeInstance>();

            Logs = new List<RuntimeLogInfo>();

            Registry =
                new ComponentRegistry();

            Scanner =
                new ReflectionScanner();

            Loader =
                new ComponentLoader(
                    Registry,
                    Scanner);

            Activator =
                new ComponentActivator();

            WindowManager = new RuntimeWindowManager();

            Host =
                new RuntimeHost(
                    WindowManager);
            _development =
    new DevelopmentWorkspace();

            BuildManager =
                new BuildManager();

            //Development =
            //    new DevelopmentWorkspace();

            //BuildManager =
            //    Development.BuildManager;

        }
        public RuntimeWindowManager WindowManager
        {
            get;
            private set;
        }

        public void Open(string folder)
        {
            Clear();
            AddLog(
                "Workspace",
                "Workspace Opened",
                "Info");

            AddLog(
                "Workspace",
                folder,
                "Info");

            Folder = folder;

            Components =
                Loader.LoadFolder(folder);

            AddLog(
                "Loader",
                Components.Count + " dll found.",
                "Info");

            foreach (ComponentInfo info in Components)
            {
                if (Loader.Load(info))
                {
                    AddLog(
                        "Loader",
                        info.FileName + " Loaded",
                        "Info");
                }
                else
                {
                    AddLog(
                        "Loader",
                        info.FileName,
                        "Error");
                }
            }
            foreach (RuntimeComponent runtime
                in Registry.Components)
            {
                //RuntimeInstances.AddRange(
                //    Activator.CreateInstances(runtime));
                foreach (RuntimeInstance item in Activator.CreateInstances(runtime))
                {
                    RuntimeInstances.Add(item);
                }
                AddLog(
                    "Reflection",
                    runtime.Types.Count + " Types",
                    "Info");
            }

            AddLog(
                "Activator",
                RuntimeInstances.Count + " Instances",
                "Info");

            //Host.Run(this);
            foreach (RuntimeInstance item
    in RuntimeInstances)
            {
                Host.Run(item);
            }
            AddLog(
                "Runtime",
                "Runtime Started",
                "Success");

            if (WorkspaceChanged != null)
            {
                WorkspaceChanged(
                    this,
                    EventArgs.Empty);
            }
        }

        public void Close()
        {
            Host.Close();

            Clear();

            if (WorkspaceChanged != null)
            {
                WorkspaceChanged(
                    this,
                    EventArgs.Empty);
            }
        }

        public void AddLog(
        string source,
        string message,
        string level)
        {
            RuntimeLogInfo log =
                new RuntimeLogInfo();

            log.Time =
                DateTime.Now;

            log.Source =
                source;

            log.Message =
                message;

            log.Level =
                level;

            Logs.Add(log);

            if (LogsChanged != null)
            {
                LogsChanged(
                    this,
                    EventArgs.Empty);
            }
        }

        public void Clear()
        {
            Host.Close();

            Registry.Clear();

            WindowManager.CloseAll();

            Components.Clear();

            Dependencies.Clear();

            RuntimeComponents.Clear();

            RuntimeInstances.Clear();

            Logs.Clear();

            Folder = null;
        }

        public BuildResult BuildFile()
        {
            BuildResult result =
                BuildManager.BuildFile();

            if (result != null &&
                result.Success)
            {
                AddLog(
                    "Build",
                    "Compiled : " +
                    result.OutputFile,
                    "Success");
            }
            else
                if (result != null)
                {
                    AddLog(
                        "Build",
                        result.ErrorText == null
                            ? "Failed"
                            : result.ErrorText,
                        "Error");
                }

            return result;
        }

        public BuildResult BuildFolder()
        {
            BuildResult result =
                BuildManager.BuildFolder();

            if (result == null)
                return null;

            if (result.Success)
            {
                AddLog(
                    "Build",
                    "Compiled : " +
                    result.OutputFile,
                    "Success");
            }
            else
            {
                AddLog(
                    "Build",
                    result.ErrorText,
                    "Error");
            }

            return result;
        }
    }
}