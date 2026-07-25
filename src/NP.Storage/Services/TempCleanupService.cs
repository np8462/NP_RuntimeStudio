using NP.Storage.Runtime;
using System;
using System.IO;

namespace NP.Storage.Services
{
    public class TempCleanupService
    {
        public void DeleteOldFiles(
            int days)
        {
            string root =
                Path.Combine(
                    StoragePaths.RuntimeFolder,
                    "Temp");

            if (!Directory.Exists(root))
            {
                return;
            }

            foreach (string file in
                Directory.GetFiles(
                    root,
                    "*.*",
                    SearchOption.AllDirectories))
            {
                if (File.GetCreationTime(file)
                    < DateTime.Now.AddDays(-days))
                {
                    File.Delete(file);
                }
            }
        }
    }
}