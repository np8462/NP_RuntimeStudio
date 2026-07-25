using NP.Services.Commands;
using NP.Services.Common;
using NP.UI.Forms;
using NP.Services.Infrastructure;
using NP.Services.Runtime;
using System.Windows.Forms;

namespace NP.Services.Tools
{
    public class ToolManager : ServiceBase
    {
        private ToolRegistry _registry = new ToolRegistry();

        public ToolManager(HostForm form, CommandBus bus)
            : base(form, bus)
        {
            bus.CommandReceived += OnCommandReceived;

            RegisterDefaultTools();
        }

        private void RegisterDefaultTools()
        {
            _registry.Register(new OpenFileTool(Form));
        }
        private void OnCommandReceived(CommandPacket cmd)
        {
            if (cmd.Command != "tool_request")
                return;

            Form.Log("ToolManager executing...");

            ToolRequest request =
                JsonHelper.Deserialize<ToolRequest>(cmd.Data);

            var tool = _registry.Get(request.ToolName);

            if (tool != null)
            {
                var result = tool.Execute(request);
                Form.Log("Tool Result: " + result.Result);
            }
            else
            {
                Form.Log("Tool not found: " + request.ToolName);
            }
        }
        //private void OnCommandReceived(CommandPacket cmd)
        //{
        //    if (cmd.Command != "tool_request")
        //        return;

        //    RuntimeBuilder.Log("ToolManager executing...");

        //    //ToolRequest request = new ToolRequest();
        //    //request.ToolName = "open_file";
        //    //request.Data = cmd.Data;

        //    ToolRequest request =
        //        JsonHelper.Deserialize<ToolRequest>(cmd.Data);            
            
        //    //var tool = _registry.Get(request.ToolName);

        //    //if (tool != null)
        //    //{
        //    //    ToolResponse response =
        //    //        tool.Execute(request);
        //    //}

        //    var tool = _registry.Get(request.ToolName);
        //    if (tool != null)
        //    {
        //        var result = tool.Execute(request);

        //        RuntimeBuilder.Log("Tool Result: " + result.Result);
        //    }
        //    else
        //    {
        //        RuntimeBuilder.Log("Tool not found: " + request.ToolName);
        //    }
        //}
    }
}