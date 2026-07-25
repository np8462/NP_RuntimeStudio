using EnvDTE;

namespace NP.VSExtension.Services
{
    public class SolutionScanner
    {
        public static string
            GetCurrentSolutionName(
            DTE dte)
        {
            if (dte.Solution == null)
            {
                return "";
            }

            return
                dte.Solution.FullName;
        }
    }
}