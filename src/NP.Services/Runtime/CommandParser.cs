using System;

namespace NP.Services.Runtime
{
    public class CommandParser
    {
        public bool TryParse(
            string text,
            out string commandName,
            out string[] arguments)
        {
            commandName = "";
            arguments = null;

            try
            {
                if (string.IsNullOrWhiteSpace(text))
                    return false;

                if (!text.StartsWith("/"))
                    return false;

                string cmd =
                    text.Substring(1);

                string[] parts =
                    cmd.Split(' ');

                if (parts.Length == 0)
                    return false;

                commandName =
                    parts[0].ToLower();

                if (parts.Length > 1)
                {
                    arguments =
                        new string[parts.Length - 1];

                    Array.Copy(
                        parts,
                        1,
                        arguments,
                        0,
                        arguments.Length);
                }
                else
                {
                    arguments =
                        new string[0];
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}