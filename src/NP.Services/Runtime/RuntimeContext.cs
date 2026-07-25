using NP.Services.AI;
using NP.Services.Bridge;
using NP.Services.Commands;
using NP.Services.Routing;
using NP.Services.RuntimeBridge;
using NP.Services.Server;
using NP.Services.Services;
using NP.Services.Sessions;
using NP.Services.Tools;
using System.Windows.Forms;

namespace NP.Services.Runtime
{
    public class RuntimeContext
    {
        //------------------------------------
        // Core
        //------------------------------------

        public Form MainForm
        {
            get;
            set;
        }

        public CommandBus CommandBus
        {
            get;
            set;
        }

        public SessionRegistry SessionManager
        {
            get;
            set;
        }

        //------------------------------------
        // Routing
        //------------------------------------

        public MessageRouter Router
        {
            get;
            set;
        }

        //------------------------------------
        // Runtime Bridge
        //------------------------------------

        public IRuntimeBridge RuntimeBridge
        {
            get;
            set;
        }

        //------------------------------------
        // Optional Runtime Server
        //------------------------------------

        public IRuntimeServer Server
        {
            get;
            set;
        }

        //------------------------------------
        // Services
        //------------------------------------

        public ChromeBridgeService ChromeBridge
        {
            get;
            set;
        }

        public VSBridgeService VSBridge
        {
            get;
            set;
        }

        public AIService AIService
        {
            get;
            set;
        }

        public ToolManager ToolManager
        {
            get;
            set;
        }

        public PluginManager PluginManager
        {
            get;
            set;
        }

        //------------------------------------
        // Temporary (will be removed)
        //------------------------------------

        public BridgeSessionService BridgeSession
        {
            get;
            set;
        }
    }
}