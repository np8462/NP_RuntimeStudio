using NP.Services.Commands;
using NP.UI.Forms;
using NP.Services.Infrastructure;
using NP.Services.Runtime;
using NP.Services.Infrastructure;

namespace NP.Services.AI
{
    public class AIService : ServiceBase
    {
        public AIService(
            HostForm form,
            CommandBus bus)
            : base(form, bus)
        {
            bus.CommandReceived += OnCommandReceived;
        }

        void OnCommandReceived(CommandPacket cmd)
        {
            if (cmd.Command != "ai_prompt")
                return;

            Form.Log("AI Prompt : " + cmd.Data);

            if (cmd.Command != "tool_request")
                return;

            Form.Log("Tool Request : " + cmd.Data);
        }
    }
}