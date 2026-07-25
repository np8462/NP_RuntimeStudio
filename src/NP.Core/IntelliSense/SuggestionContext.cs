using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Core.IntelliSense
{
    public class SuggestionContext
    {
        public string Command
        {
            get;
            set;
        }

        public string ObjectType
        {
            get;
            set;
        }

        public string ObjectName
        {
            get;
            set;
        }

        public int Stage
        {
            get;
            set;
        }
    }
}
