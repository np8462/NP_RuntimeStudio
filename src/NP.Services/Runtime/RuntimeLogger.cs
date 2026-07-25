using System;
using System.Collections.Generic;
using NP.Core.Models;

namespace NP.Services.Runtime
{
    public class RuntimeLogger
    {
        private readonly List<RuntimeLogEntry> _logs;

        public RuntimeLogger()
        {
            _logs =
                new List<RuntimeLogEntry>();
        }

        public event Action<RuntimeLogEntry> LogAdded;

        public IList<RuntimeLogEntry> Logs
        {
            get
            {
                return _logs;
            }
        }

        public void Write(string message)
        {
            Write(
                "Runtime",
                message);
        }

        public void Write(
            string source,
            string message)
        {
            try
            {
                RuntimeLogEntry entry =
                    new RuntimeLogEntry
                    {
                        Time = DateTime.Now,
                        Source = source,
                        Message = message
                    };

                _logs.Add(entry);

                if (LogAdded != null)
                {
                    LogAdded(entry);
                }
            }
            catch
            {
            }
        }

        public void Clear()
        {
            try
            {
                _logs.Clear();
            }
            catch
            {
            }
        }
    }
}