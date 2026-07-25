using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.AI
{
    public class AiSettings
    {
        public string ApiKey { get; set; }

        public string Model { get; set; }

        public string BaseUrl { get; set; }

        public int TimeoutSeconds { get; set; }

    }
}