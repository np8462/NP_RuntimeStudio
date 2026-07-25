using System;

namespace NP.Core.Models
{
    public class RuntimeLogEntry
    {
        public DateTime Time
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}