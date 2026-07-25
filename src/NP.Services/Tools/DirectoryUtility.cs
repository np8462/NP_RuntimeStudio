using System.IO;

namespace NP.Services.Tools
{
    public static class DirectoryUtility
    {
        public static bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public static void Create(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}