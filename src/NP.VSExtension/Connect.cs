using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.VisualStudio.CommandBars;
using NP.Core.Models;
using NP.Extension.Services;
using NP.Services.Bridge;
using NP.Services.Commands;
using NP.Services.Routing;
using NP.Services.Server;
using NP.Storage.Runtime;
using NP.Storage.Services;
using NP.UI.Controls;
using NP.VSExtension.Forms;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace NP.VSExtension
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2
	{
        private DTE _dte;
        private HttpServer _bridgeServer;
        private BridgeSessionService _bridgeSession;

        private CommandBarButton _btnAskAI;
        private CommandBarButton _btnChromeBridge;
        private CommandBarPopup _popup;

        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
        {
		}

        public void InsertText(string text)
        {
            //EnvDTE.Document doc = _application.ActiveDocument;
            EnvDTE.Document doc = _dte.ActiveDocument;

            if (doc == null)
                return;

            var selection = (EnvDTE.TextSelection)doc.Selection;
            selection.Insert(text);
        }
        public void OnHostMessage(string text)
        {
            InsertText(text);
        }
		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
        //public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        //{
        //    _applicationObject = (DTE2)application;
        //    //_addInInstance = (AddIn)addInInst;
        //    MessageBox.Show(_applicationObject.Name);
        //}

        public void OnConnection(object application,ext_ConnectMode connectMode,object addInInst,ref Array custom)
        {
            try
            {
                _dte = (DTE)application;

                CommandBars bars = (CommandBars)_dte.CommandBars;
                CommandBar codeWindow = bars["Code Window"];

                _btnAskAI = FindButton(codeWindow, "NP.ASKAI");
                if (_btnAskAI == null)
                {
                    _btnAskAI =
                        (CommandBarButton)
                        codeWindow.Controls.Add(
                            MsoControlType.msoControlButton,
                            Temporary: true);
                    _btnAskAI.Caption = "Ask AI...";
                    _btnAskAI.Tag = "NP.ASKAI";
                    _btnAskAI.Click += OnAskAiClick;
                }

                _btnChromeBridge = FindButton(codeWindow, "NP.CHROMEBRIDGE");
                if (_btnChromeBridge == null)
                {
                    _btnChromeBridge =
                        (CommandBarButton)
                        codeWindow.Controls.Add(
                            MsoControlType.msoControlButton,
                            Temporary: true);
                    _btnChromeBridge.Caption = "Send To Chrome Bridge...";
                    _btnChromeBridge.Tag = "NP.CHROMEBRIDGE";
                    _btnChromeBridge.Click += OnSendToBridgeClick;
                }

                //CommandBarButton btn = (CommandBarButton)codeWindow.Controls.Add(MsoControlType.msoControlButton, Temporary: true);
                //btn.Caption = "Ask AI...";
                //btn.Click += OnAskAiClick;

                //CommandBarButton btnBridge = (CommandBarButton)codeWindow.Controls.Add(MsoControlType.msoControlButton, Temporary: true);
                //btnBridge.Caption = "Send To Chrome Bridge...";
                //btnBridge.Click += OnSendToBridgeClick;

                //StoragePaths.RootFolder =
                //    Path.Combine(
                //        Environment.GetFolderPath(
                //            Environment.SpecialFolder.MyDocuments),
                //        "NP_RuntimeStudio");

                //Directory.CreateDirectory(
                //    StoragePaths.RootFolder);

                MessageBox.Show("AddIn Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private CommandBarButton FindButton(
    CommandBar controls,
    string tag)
        {
            foreach (CommandBarControl c in controls.Controls)
            {
                if (c.Tag == tag)
                    return c as CommandBarButton;
            }

            return null;
        }
        private void DeleteIfExists(
    CommandBar bar,
    string tag)
        {
            foreach (CommandBarControl c in bar.Controls)
            {
                if (c.Tag == tag)
                {
                    c.Delete();
                    break;
                }
            }
        }

        private void OnSendToBridgeClick(
    CommandBarButton Ctrl,
    ref bool CancelDefault)
        {
            try
            {
                Document doc =
                    _dte.ActiveDocument;

                if (doc == null)
                    return;

                TextSelection selection =
                    (TextSelection)doc.Selection;

                string code =
                    selection.Text;

                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show(
                        "No code selected.");

                    return;
                }

                AiContext context =
                    new AiContext();

                context.ProjectName =
                    "NP_AI_RuntimeStudio";

                context.FileName =
                    doc.Name;

                context.FilePath =
                    doc.FullName;

                context.SelectedCode =
                    code;

                context.SourceAttachment =
                    new AttachmentInfo()
                    {
                        FileName = doc.Name,
                        OriginalFilePath = doc.FullName,
                        TempFilePath = null,
                        CreatedAt = DateTime.Now
                    };

                EnsureBridgeServer();

                //_bridgeSession.SetContext(context);
                RuntimeBridgeProvider
                    .Current
                    .SetContext(context);

                MessageBox.Show(
                    "Chrome Bridge is ready.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void EnsureBridgeServer()
        {
            RuntimeBridgeEnvironment.Initialize();

            RuntimeBridgeProvider
                .Current
                .EnsureRunning();
        }
    //    private void EnsureBridgeServer()
    //    {
    //        //if (_bridgeSession == null)
    //        //{
    //        //    _bridgeSession =
    //        //        new BridgeSessionService();
    //        //}
    //        MessageRouter router =
    //new MessageRouter(
    //    null,
    //    new CommandBus());

    //        if (RuntimeServerService.Instance.BridgeSession == null)
    //        {
    //            RuntimeServerService.Instance.Start(
    //                router,
    //                new BridgeSessionService());
    //        }

    //        _bridgeSession =
    //            RuntimeServerService.Instance.BridgeSession;



            //RuntimeServerService.Instance.Start(
            //    router,
            //    _bridgeSession);
        //}

        private void OnAskAiClick(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            try
            {
                Document doc = _dte.ActiveDocument;
                if (doc == null) return;

                TextSelection selection = (TextSelection)doc.Selection;
                string code = selection.Text;

                if (string.IsNullOrWhiteSpace(code))
                    return;

                AttachmentService attachService = new AttachmentService();

                AttachmentInfo attachment =
                    attachService.CreateTempAttachment(doc.FullName, code);

                AiContext context = new AiContext
                {
                    ProjectName = "NP_AI_RuntimeStudio",
                    FileName = doc.Name,
                    FilePath = doc.FullName,
                    SelectedCode = code,
                    SourceAttachment = attachment
                };

                // 🚀 فرم فقط host است
                RuntimeStudioForm form = new RuntimeStudioForm();

                // ✅ ساخت کنترل دستی (مهم‌ترین بخش)
                RuntimeStudioControl control = new RuntimeStudioControl();
                control.Dock = DockStyle.Fill;

                // ✅ پاس دادن context کامل (نه فقط code)
                control.SetContext(context);
                control.SetDTE(_dte);
                
                form.Controls.Clear();
                form.Controls.Add(control);

                // مهم برای VS AddIn stability
                form.StartPosition = FormStartPosition.CenterScreen;

                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
            RemoveButtons();
		}
        private void RemoveButtons()
        {
            try
            {
                if (_btnAskAI != null)
                {
                    _btnAskAI.Delete();
                    _btnAskAI = null;
                }

                if (_btnChromeBridge != null)
                {
                    _btnChromeBridge.Delete();
                    _btnChromeBridge = null;
                }

                if (_popup != null)
                {
                    _popup.Delete();
                    _popup = null;
                }
            }
            catch
            {
            }
        }
        
		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}