using NP.Services.Builders;
using NP.Core.Models;
using System;

namespace NP.Services.Engine
{
    public class CommandEngine
    {
        public CommandResult Execute(string commandText)
        {
            CommandResult result =
                new CommandResult();

            try
            {
                string[] parts =
                    commandText.Split(' ');

                string cmd =
                    parts[0].ToLower();

                if (cmd == "/createfolder")
                {
                    if (parts.Length < 2)
                    {
                        result.Success = false;

                        result.Message =
                            "Folder name missing.";

                        return result;
                    }

                    string folderName =
                        parts[1];

                    FolderBuilder builder =
                        new FolderBuilder();

                    return builder.CreateFolder(
                        folderName);
                }

                result.Success = false;

                result.Message =
                    "Unknown command.";
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message = ex.Message;
            }

            return result;
        }
    }
}