using NP.Services.AI;
using NP.Services.Bridge;
using NP.Services.Commands;
using NP.UI.Forms;
using NP.Services.Routing;
using NP.Services.Server;
using NP.Services.Services;
using NP.Services.Sessions;
using NP.Services.Tools;
using System.Windows.Forms;
using NP.Services.RuntimeBridge;

namespace NP.Services.Runtime
{
    public class RuntimeBuilder
    {
        public static RuntimeContext Build(HostForm form)
        {
            var context = new RuntimeContext();

            // Core
            context.MainForm = form;
            context.CommandBus = new CommandBus();
            context.SessionManager = new SessionRegistry();

            // Router
            context.Router = new MessageRouter(form, context.CommandBus);

            // Services
            context.ChromeBridge = new ChromeBridgeService(form, context.CommandBus);
            //context.VSBridge = new VSBridgeService(form, context.CommandBus);
            context.VSBridge = new VSBridgeService();
            context.AIService = new AIService(form, context.CommandBus);
            context.ToolManager = new ToolManager(form, context.CommandBus);
            context.PluginManager = new PluginManager(form, context.CommandBus);

            context.BridgeSession = new BridgeSessionService();
            BridgeRuntime.Instance.Runtime = context;
            BridgeRuntime.Instance.BridgeSession = context.BridgeSession;

            // Server (آخر ساخته شود چون Router لازم دارد)
            //context.Server = new HttpServer(context.Router);
            
            //context.Server = new HttpServer(context.Router, context.BridgeSession);
            //context.Server.Start();
    //        context.Server =
    //            RuntimeServerService.Instance.Server;
    //        context.RuntimeBridge =
    //RuntimeBridgeProvider.Current;

    //        RuntimeServerService.Instance.Start(
    //            context.Router,
    //            context.BridgeSession);

            RuntimeBridgeLauncher.RuntimeBridgePath = Application.StartupPath + "\\NP.Host.RuntimeBridge.exe";
            context.RuntimeBridge =
                RuntimeBridgeProvider.Current;

            context.RuntimeBridge.EnsureRunning();


            //just for test =>
            //RuntimeBridgeProvider.Current.EnsureRunning();

            //RuntimeBridgeProvider.Current.SetContext(
            //    new AiContext()
            //    {
            //        ProjectName = "HOST",
            //        FileName = "Main.cs",
            //        SelectedCode = "Hello From Host"
            //    });
            // <=just for test

            form.Log("Runtime initialized");

            return context;
        }
    }
}