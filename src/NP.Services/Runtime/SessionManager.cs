using System.Collections.Generic;

namespace NP.Services.Runtime
{
    public class SessionManager
    {
        private readonly List<RuntimeSession> _sessions =
            new List<RuntimeSession>();

        public void Add(RuntimeSession session)
        {
            _sessions.Add(session);
        }

        public IEnumerable<RuntimeSession> GetAll()
        {
            return _sessions;
        }
    }
}