using System.IO;

namespace NP.Core.Services
{
    public static class FileGenerator
    {
        public static void CreateFile(
            string path,
            string content)
        {
            string folder =
                Path.GetDirectoryName(
                    path);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(
                    folder);
            }

            File.WriteAllText(
                path,
                content);
        }
    }
}