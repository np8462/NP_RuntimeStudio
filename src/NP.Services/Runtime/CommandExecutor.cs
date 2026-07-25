using NP.Core.Models;
using System;
using System.IO;

namespace NP.Services.Runtime
{
    public class CommandExecutor
    {
        public ChatMessage Execute(
            string commandName,
            string[] args)
        {
            try
            {
                switch (commandName)
                {
                    case "createfolder":

                        return CreateFolder(args);

                    default:

                        return new ChatMessage
                        {
                            Id = Guid.NewGuid(),
                            SessionId = "MAIN",
                            Role = "System",
                            Content =
                                "Unknown command.",
                            Type = MessageType.Error,
                            IsExecutable = false,
                            CreatedAt = DateTime.Now,
                            ColorTag = "Red"
                        };
                }
            }
            catch (Exception ex)
            {
                return new ChatMessage
                {
                    Id = Guid.NewGuid(),
                    SessionId = "MAIN",
                    Role = "System",
                    Content = ex.Message,
                    Type = MessageType.Error,
                    IsExecutable = false,
                    CreatedAt = DateTime.Now,
                    ColorTag = "Red"
                };
            }
        }

        private ChatMessage CreateFolder(
            string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    return new ChatMessage
                    {
                        Id = Guid.NewGuid(),
                        SessionId = "MAIN",
                        Role = "System",
                        Content =
                            "Folder name missing.",
                        Type = MessageType.Error,
                        IsExecutable = false,
                        CreatedAt = DateTime.Now,
                        ColorTag = "Red"
                    };
                }

                string folderName =
                    args[0];

                string path =
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        folderName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return new ChatMessage
                {
                    Id = Guid.NewGuid(),
                    SessionId = "MAIN",
                    Role = "System",
                    Content =
                        "Folder created: " +
                        folderName,
                    Type = MessageType.Execution,
                    IsExecutable = false,
                    CreatedAt = DateTime.Now,
                    ColorTag = "Cyan"
                };
            }
            catch (Exception ex)
            {
                return new ChatMessage
                {
                    Id = Guid.NewGuid(),
                    SessionId = "MAIN",
                    Role = "System",
                    Content = ex.Message,
                    Type = MessageType.Error,
                    IsExecutable = false,
                    CreatedAt = DateTime.Now,
                    ColorTag = "Red"
                };
            }
        }
    }
}