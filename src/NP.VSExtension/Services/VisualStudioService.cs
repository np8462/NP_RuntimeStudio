using EnvDTE;

namespace NP.VSExtension.Services
{
    public class VisualStudioService
    {
        private DTE _application;

        public VisualStudioService(
            DTE application)
        {
            _application =
                application;
        }

        public string GetSolutionName()
        {
            if (_application.Solution == null)
            {
                return "";
            }

            return
                _application
                .Solution
                .FullName;
        }
    }
}