using System;

namespace NP.Core.Models
{
    public class CommandModel
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

        public string Command
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public override string ToString()
        {
            return
                Time.ToString("HH:mm:ss")
                + " | "
                + Source
                + " | "
                + Command;
        }
    }
}