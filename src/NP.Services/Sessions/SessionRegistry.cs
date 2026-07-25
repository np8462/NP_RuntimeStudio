using NP.Services.Commands;
using NP.Services.Runtime;
using System.Collections.Generic;

namespace NP.Services.Sessions
{
    public class SessionRegistry
    {
        private Dictionary<string, SessionInfo> _sessions =
            new Dictionary<string, SessionInfo>();

        public void Add(SessionInfo session)
        {
            if (!_sessions.ContainsKey(session.SessionId))
                _sessions.Add(session.SessionId, session);
        }

        public SessionInfo Get(string sessionId)
        {
            if (_sessions.ContainsKey(sessionId))
                return _sessions[sessionId];

            return null;
        }

        public bool Exists(string sessionId)
        {
            return _sessions.ContainsKey(sessionId);
        }
    }
}