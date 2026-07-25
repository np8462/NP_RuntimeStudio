using NP.Services.Commands;
using NP.Services.Common;

namespace NP.Services.Tools
{
    public static class CommandFactory
    {
        public static CommandPacket Create(MessagePacket packet)
        {
            CommandPacket cmd = new CommandPacket();

            cmd.Source = "chrome";
            cmd.Target = "host";
            //cmd.Data = packet.payload;
            cmd.Data = JsonHelper.Serialize(packet.payload);

            switch (packet.type)
            {
                case "test_message":

                    cmd.Command = "chrome_message";

                    break;

                case "tool_request":

                    cmd.Command = "tool_request";

                    break;

                case "ai_prompt":

                    cmd.Command = "ai_prompt";

                    break;

                case "open_document":

                    cmd.Command = "open_document";

                    break;

                case "compile_project":

                    cmd.Command = "compile_project";

                    break;
                     
                default:

                    cmd.Command = "unknown";

                    break;
            }

            return cmd;
        }
    }
}