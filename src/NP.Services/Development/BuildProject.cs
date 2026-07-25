using System.Collections.Generic;
using System.IO;

namespace NP.Services.Development
{
    public class BuildProject
    {
        public string Folder
        {
            get;
            set;
        }

        public string ProjectFile
        {
            get;
            set;
        }

        public bool HasProjectFile
        {
            get;
            set;
        }

        public bool IsSmartProject
        {
            get;
            set;
        }
        
        public bool IsLoaded
        {
            get;
            set;
        }

        public string OutputType
        {
            get;
            set;
        }

        public string TargetFramework
        {
            get;
            set;
        }

        public IList<string> SourceFiles
        {
            get;
            private set;
        }

        public IList<string> References
        {
            get;
            private set;
        }

        public BuildOptions Options
        {
            get;
            private set;
        }

        public BuildProject()
        {
            SourceFiles =
                new List<string>();

            References =
                new List<string>();

            Options =
                new BuildOptions();
        }

        public static BuildProject Load(string folder)
        {
            BuildProject project =
                new BuildProject();

            project.Folder =
                folder;

            //---------------------------------------
            // Find Project File
            //---------------------------------------

            string[] projects =
                Directory.GetFiles(
                    folder,
                    "*.csproj",
                    SearchOption.TopDirectoryOnly);

            if (projects.Length > 0)
            {
                project.ProjectFile =
                    projects[0];

                project.HasProjectFile =
                    true;
            }

            //---------------------------------------
            // Find Source Files
            //---------------------------------------

            foreach (string file
                in Directory.GetFiles(
                    folder,
                    "*.cs",
                    SearchOption.AllDirectories))
            {
                project.SourceFiles.Add(file);
            }

            return project;
        }
        
        public string MSBuildPath
        {
            get;
            set;
        }

    }
}