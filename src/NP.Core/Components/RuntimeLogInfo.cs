using System;

namespace NP.Core.Components
{
    public class RuntimeLogInfo
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

        public string Level
        {
            get;
            set;
        }
    }
}