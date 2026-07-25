namespace NP.Core.Components
{
    public class ComponentInfo
    {
        public string Name
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public string AssemblyPath
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }

        public bool Loaded
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }
    }
}