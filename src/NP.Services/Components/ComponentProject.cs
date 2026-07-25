using System.Collections.Generic;

namespace NP.Services.Components
{
    public class ComponentProject
    {
        public string Name
        {
            get;
            set;
        }

        public string RootFolder
        {
            get;
            set;
        }

        public string OutputFolder
        {
            get;
            set;
        }

        public IList<string> SourceFiles
        {
            get;
            private set;
        }

        public ComponentProject()
        {
            SourceFiles =
                new List<string>();
        }
    }
}