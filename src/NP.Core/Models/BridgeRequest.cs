using System;

namespace NP.Core.Models
{
    public class BridgeRequest
    {
        public string ProjectName
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

        public string SelectedCode
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }
    }
}