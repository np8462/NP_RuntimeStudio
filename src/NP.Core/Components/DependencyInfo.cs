using System.Collections.Generic;

namespace NP.Core.Components
{
    public class DependencyInfo
    {
        public string AssemblyName
        {
            get;
            set;
        }

        public IList<string> References
        {
            get;
            private set;
        }

        public DependencyInfo()
        {
            References =
                new List<string>();
        }
    }
}