using NP.Core.Models;
using System.IO;

namespace NP.Services.Builders
{
    public class FolderBuilder
    {
        public CommandResult CreateFolder(
            string path)
        {
            CommandResult result =
                new CommandResult();

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                    result.Success = true;

                    result.Message =
                        "Folder created: " + path;
                }
                else
                {
                    result.Success = false;

                    result.Message =
                        "Folder already exists.";
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;

                result.Message = ex.Message;
            }

            return result;
        }
    }
}