using System.Collections.Generic;

namespace NP.Services.Services
{
    public class RecentFileService
    {
        private readonly List<string> _files =
            new List<string>();

        public void Add(string fileName)
        {
            if (!_files.Contains(fileName))
                _files.Add(fileName);
        }

        public IEnumerable<string> GetFiles()
        {
            return _files;
        }
    }
}