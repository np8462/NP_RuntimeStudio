using System.Collections.Generic;

namespace NP.Services.Development
{
    public class BuildResult
    {
        public bool Success { get; set; }

        public string OutputFile { get; set; }

        public string ErrorText { get; set; }

        public IList<string> Warnings { get; set; }

        public string SourceFile { get; set; }

        public BuildResult()
        {
            Warnings = new List<string>();
        }
        public string OutputText
        {
            get;
            set;
        }

        public int ExitCode
        {
            get;
            set;
        }
    }
}