using System;
using System.IO;

namespace NP.Services.Runtime
{
    public static class RuntimePaths
    {
        public static string Workspace
        {
            get
            {
                string path =
                    Path.Combine(
                        //AppDomain.CurrentDomain.BaseDirectory,
                        RuntimePaths.Workspace,
                        "Workspace");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }
    }
}