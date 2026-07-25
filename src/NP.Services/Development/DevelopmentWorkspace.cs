namespace NP.Services.Development
{
    public class DevelopmentWorkspace
    {
        public BuildManager Manager
        {
            get;
            private set;
        }

        public DevelopmentWorkspace()
        {
            Manager =
                new BuildManager();
        }

        public BuildResult BuildFile()
        {
            return Manager.BuildFile();
        }
    }
}