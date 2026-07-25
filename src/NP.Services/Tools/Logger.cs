using System;

namespace NP.Services.Tools
{
    public static class Logger
    {
        public static void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine(
                DateTime.Now.ToString("HH:mm:ss")
                + " "
                + message);
        }
    }
}