namespace NP.Core.Components
{
    public class TypeInfo
    {
        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public string BaseType
        {
            get;
            set;
        }

        public bool IsForm
        {
            get;
            set;
        }

        public bool IsUserControl
        {
            get;
            set;
        }

        public bool IsControl
        {
            get;
            set;
        }

        public bool IsComponent
        {
            get;
            set;
        }

        public bool IsService
        {
            get;
            set;
        }
    }
}