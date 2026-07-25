namespace NP.Services.Development
{
    public class BuildOptions
    {
        public BuildOutputKind OutputKind
        {
            get;
            set;
        }

        public string OutputPath
        {
            get;
            set;
        }

        public string TargetFramework
        {
            get;
            set;
        }

        public bool Optimize
        {
            get;
            set;
        }

        public bool IncludeDebugInformation
        {
            get;
            set;
        }

        public BuildOptions()
        {
            OutputKind =
                BuildOutputKind.Library;

            TargetFramework =
                "net48";

            Optimize =
                false;

            IncludeDebugInformation =
                true;
        }
    }
}