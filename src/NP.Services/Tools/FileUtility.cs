using System.IO;

namespace NP.Services.Tools
{
    public static class FileUtility
    {
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public static void WriteAllText(string path,
                                        string text)
        {
            File.WriteAllText(path, text);
        }
    }
}