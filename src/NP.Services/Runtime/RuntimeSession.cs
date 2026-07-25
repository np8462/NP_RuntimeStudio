using System;

namespace NP.Services.Runtime
{
    public class RuntimeSession
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public RuntimeSession()
        {
            Id = Guid.NewGuid().ToString();

            CreatedAt = DateTime.Now;
        }
    }
}