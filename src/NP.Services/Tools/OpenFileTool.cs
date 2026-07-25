using System.Diagnostics;
using NP.Services.Commands;
using System.Windows.Forms;
using NP.Services.Runtime;
using NP.UI.Forms;

namespace NP.Services.Tools
{
    public class OpenFileTool : ITool
    {
        private HostForm _form;

        public OpenFileTool(HostForm form)
        {
            _form = form;
        }

        public string Name
        {
            get { return "open_file"; }
        }

        public ToolResponse Execute(ToolRequest request)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = request.Data,
                    UseShellExecute = true
                });

                _form.Log("Opening file: " + request.Data);

                return new ToolResponse
                {
                    Success = true,
                    Result = "File opened"
                };
            }
            catch (System.Exception ex)
            {
                return new ToolResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}

/*
using System.Diagnostics;
using NP.Services.Commands;

namespace NP.Host.Core.Tools
{
    public class OpenFileTool : ITool
    {
        private MainForm _form;

        public OpenFileTool(MainForm form)
        {
            _form = form;
        }

        public string Name
        {
            get { return "open_file"; }
        }

        public ToolResponse Execute(ToolRequest request)
        {
            try
            {
                Process.Start("notepad.exe", request.Data);

                RuntimeBuilder.Log("Opening file: " + request.Data);

                return new ToolResponse
                {
                    Success = true,
                    Result = "File opened"
                };
            }
            catch (System.Exception ex)
            {
                return new ToolResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}


using System.Diagnostics;
using NP.Services.Commands;
using System.Windows.Forms;

namespace NP.Host.Core.Tools
{
    public class OpenFileTool : ITool
    {
        private MainForm _form;

        public OpenFileTool(MainForm form)
        {
            _form = form;
        }

        public string Name = "open_file";

        public ToolResponse Execute(ToolRequest request)
        {
            try
            {
                Process.Start("notepad.exe", request.Data);

                RuntimeBuilder.Log("Opening file: " + request.Data);

                return new ToolResponse
                {
                    Success = true,
                    Result = "File opened"
                };
            }
            catch (System.Exception ex)
            {
                return new ToolResponse
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}
*/