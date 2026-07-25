using EnvDTE;
using NP.AI;
using NP.AI.Builders;
using NP.AI.Parsers;
using NP.Services.Classification;
using NP.Services.Engine;
using NP.Services.IntelliSense;
using NP.Services.Runtime;
using NP.Services.Validation;
using NP.Core.Catalogs;
using NP.Core.Models;
using NP.Storage.Repositories;
using NP.Storage.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Controls
{
    public partial class RuntimeStudioControl : UserControl
    {
        private ChatRepository repo =new ChatRepository();
        private List<ChatMessage> messages =  new List<ChatMessage>();

        private string sessionId =Guid.NewGuid().ToString();
        private CommandEngine cmd =    new CommandEngine();
        private MessageClassifier classifier =    new MessageClassifier();
        private MessageValidator validator =    new MessageValidator();
        private CommandParser parser =new CommandParser();
        private CommandExecutor executor =new CommandExecutor();
        private SuggestionProvider suggestionProvider = new SuggestionProvider();
       
        private IntelliSenseEngine _engine;
        private IntelliSenseController _controller;

        private ProjectInfo currentProject;
        private ChatInfo currentChat;

        private ChatRepository storage = new ChatRepository();

        private string _attachmentFile;
        private bool _attachmentLocked;
        private ToolTip toolTip1 = new ToolTip();
        private AiContext _context;
        private DTE _dte;
        
        private AiSettingsControl _settingsControl;

        public void SetDTE(EnvDTE.DTE dte)
        {
            _dte = dte;
        }

        public void SetContext(AiContext context)
        {
            _context = context;

            if (_context == null)
                return;

            txtInputFilling(
                _context.SelectedCode);

            btnAttach.Enabled = true;

            _attachmentLocked = false;
        }
        private void ShowUserAttachment(string filePath)
        {
            _attachmentFile =
                filePath;

            lnklblAttach.Text =
                Path.GetFileName(
                    filePath);

            toolTip1.SetToolTip(
                lnklblAttach,
                filePath);
        }
        public void SetAttachment(string filePath)
        {
            _attachmentFile =
                filePath;

            _attachmentLocked = true;

            btnAttach.Enabled = true;

            lnklblAttach.Text =
                Path.GetFileName(
                    filePath);

            toolTip1.SetToolTip(
                lnklblAttach,
                filePath);
        }
        private void btnAttach_Click(object sender,EventArgs e)
        {
            if (_attachmentLocked)
            {
                return;
            }

            OpenFileDialog dlg =
                new OpenFileDialog();

            dlg.Filter =
                "Text Files|*.txt;*.cs;*.json|All Files|*.*";

            if (dlg.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }
            AttachmentService service =
    new AttachmentService();

            AttachmentInfo info =
                service.CreateUserAttachment(
                    dlg.FileName);

            if (_context == null)
                _context = new AiContext();
            _context.UserAttachment =
                info;

            _attachmentFile =
                dlg.FileName;

            lnklblAttach.Text =
                Path.GetFileName(
                    dlg.FileName);

            toolTip1.SetToolTip(
                lnklblAttach,
                dlg.FileName);
        }
        private void InitializeAttachmentPanel()
        {
            pnlAttach.Visible = true;

            _attachmentFile = null;

            _attachmentLocked = false;

            lnklblAttach.Text = "(No Attachment)";

            btnAttach.Enabled = true;
        }
        public string AttachmentFile
        {
            get
            {
                return _attachmentFile;
            }
        }
        private void lnkLblAttach_LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(
                _attachmentFile))
            {
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Open attachment file?",
                    "Attachment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            System.Diagnostics.Process.Start(
                _attachmentFile);
        }
        public void txtInputFilling(string _str_input)
        {
            txtInput.Text = _str_input;
        }

        public RuntimeStudioControl()
        {
            try
            {
                InitializeComponent();
                InitializeAttachmentPanel();
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return;
                _engine = new IntelliSenseEngine();

                _controller = new IntelliSenseController();

                LoadMessages();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void LoadMessages()
        {
            messages = storage.Load();

            rtbChat.Clear();

            foreach (var msg in messages)
            {
                AppendMessage(msg);
            }
        }

        private void LoadHistory()
        {
            rtbChat.Clear();

            var list = repo.GetAll();

            foreach (var msg in list)
            {
                AppendMessage(msg);
            }
        }

        private void AppendMessage(ChatMessage msg)
        {
            Color color =
                Color.White;

            switch (msg.Type)
            {
                case MessageType.Comment:
                    color = Color.LightGray;
                    break;

                case MessageType.Command:
                    color = Color.Orange;
                    break;

                case MessageType.Meta:
                    color = Color.DarkGray;
                    break;

                case MessageType.Planning:
                    color = Color.DeepSkyBlue;
                    break;

                case MessageType.Memory:
                    color = Color.MediumPurple;
                    break;

                case MessageType.System:
                    color = Color.LimeGreen;
                    break;

                case MessageType.Error:
                    color = Color.Red;
                    break;

                case MessageType.Generation:
                    color = Color.Gold;
                    break;

                case MessageType.Execution:
                    color = Color.Cyan;
                    break;

                case MessageType.Debug:
                    color = Color.Yellow;
                    break;

                case MessageType.RuntimeEvent:
                    color = Color.Violet;
                    break;
                default:
                    color = Color.DarkBlue;
                    break;
            }

            rtbChat.SelectionStart =
                rtbChat.TextLength;

            rtbChat.SelectionColor =
                color;

            string textToShow =msg.Content;

            if (msg.Type == MessageType.AIResponse)
            {
                textToShow =
                AiResponseParser
                .ExtractText(
                msg.Content);
            }

            rtbChat.AppendText(
                "[" + msg.Type + "] " +
                textToShow +
                Environment.NewLine);

            rtbChat.SelectionColor =
                rtbChat.ForeColor;

            rtbChat.ScrollToCaret();
        }
        
        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string txt = txtInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(txt))
                    return;

                MessageType type =
                    (MessageType)Enum.Parse(
                        typeof(MessageType),
                        cmbMsgType.SelectedItem.ToString());

                string validationError;

                if (!validator.Validate(type, txt, out validationError))
                {
                    MessageBox.Show(validationError);
                    return;
                }

                ChatMessage msg = new ChatMessage
                {
                    Id = Guid.NewGuid(),
                    SessionId = "MAIN",
                    Role = "User",
                    Content = txt,
                    RawContent = txt,
                    Type = type,
                    IsExecutable = (type == MessageType.Command),
                    CreatedAt = DateTime.Now,
                    ColorTag = type.ToString()
                };

                messages.Add(msg);
                storage.Save(messages);
                AppendMessage(msg);

                // =========================
                // COMMAND FLOW
                // =========================
                if (type == MessageType.Command)
                {
                    string cmdName;
                    string[] cmdArgs;

                    if (parser.TryParse(txt, out cmdName, out cmdArgs))
                    {
                        ChatMessage result =
                            executor.Execute(cmdName, cmdArgs);

                        messages.Add(result);
                        storage.Save(messages);
                        AppendMessage(result);
                    }
                }
                if (type == MessageType.AIRequest)
                {
                    AiContext context = _context; // ممکنه null باشه

                    string prompt;

                    if (context != null)
                    {
                        context.UserPrompt = txt;
                        prompt = PromptBuilder.Build(context);
                    }
                    else
                    {
                        // حالت ساده بدون VS context
                        prompt = txt;
                            //"TASK:\n" + txt;
                    }

                    await AskAiAsync(prompt);
                }
                txtInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
        private async Task AskAiAsync(string prompt)
        {
            try
            {
                btnSend.Enabled = false;
                txtInput.Enabled = false;
                Cursor = Cursors.WaitCursor;

                IAiProvider ai = CreateProvider();

                string rawJson = await ai.SendAsync(prompt);

                string parsedText =
                    AiResponseParser.ExtractText(rawJson);

                ChatMessage msg = new ChatMessage
                {
                    Id = Guid.NewGuid(),
                    SessionId = "MAIN",
                    Role = "Assistant",
                    RawContent = rawJson,
                    Content = parsedText,
                    Type = MessageType.AIResponse,
                    CreatedAt = DateTime.Now
                };

                messages.Add(msg);
                storage.Save(messages);
                AppendMessage(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btnSend.Enabled = true;
                txtInput.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
        
        private async Task AskAiAsync(AiContext context)
        {
            if (context == null)
            {
                await AskAiAsync(
                    txtInput.Text);

                return;
            }

            string prompt =
                PromptBuilder.Build(
                    context);

            await AskAiAsync(
                prompt);
        }

        private IAiProvider CreateProvider()
        {
            var settingsService = new SettingsService();

            var config = settingsService.Load();

            var settings = new AiSettings
            {
                ApiKey = config.ApiKey,
                Model = config.Model,
                BaseUrl = config.Url,
                TimeoutSeconds = config.TimeoutSeconds
            };

            return new OpenAiProvider(settings);
        }

        //private IAiProvider CreateProvider()
        //{
        //    AiSettings settings = new AiSettings();

        //    settings.ApiKey = "";
           
        //    settings.Model = "";

        //    settings.BaseUrl = "";

        //    settings.TimeoutSeconds = 300;

        //    return new OpenAiProvider(settings);
        //}

        private void ChatStudioForm_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectRepository repo = new ProjectRepository();
                //storage.CreateChat("NP_AI_RuntimeStudio", "MAIN");
                if (repo.GetProjects().Count == 0)
                {
                    repo.CreateProject(
                        "NP_AI_RuntimeStudio");
                }

                cmbMsgType.DataSource =
                    Enum.GetValues(
                        typeof(MessageType));
                cmbMsgType.SelectedIndex = 0;

                _settingsControl = new AiSettingsControl();
                _settingsControl.Dock = DockStyle.Fill;
                //_settingsControl.Visible = false;
                grpSettings.Controls.Add(_settingsControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInput_TextChanged(object sender,EventArgs e)
        {
            try
            {
                UpdateSuggestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstSuggestions_DoubleClick(object sender, EventArgs e)
        {
            //AcceptSuggestion();
            SelectSuggestion();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ctrl+Space

                if (e.Control &&
                    e.KeyCode == Keys.Space)
                {
                    ShowSuggestions();

                    e.SuppressKeyPress = true;
                    return;
                }

                if (!lstSuggestions.Visible)
                    return;

                // Escape

                if (e.KeyCode == Keys.Escape)
                {
                    lstSuggestions.Visible = false;

                    e.SuppressKeyPress = true;

                    return;
                }

                // Down

                if (e.KeyCode == Keys.Down)
                {
                    if (lstSuggestions.Items.Count > 0)
                    {
                        int next =
                            lstSuggestions.SelectedIndex + 1;

                        if (next >=
                            lstSuggestions.Items.Count)
                        {
                            next =
                                lstSuggestions.Items.Count - 1;
                        }

                        lstSuggestions.SelectedIndex =
                            next;
                    }

                    e.SuppressKeyPress = true;

                    return;
                }

                // Up

                if (e.KeyCode == Keys.Up)
                {
                    int prev =
                        lstSuggestions.SelectedIndex - 1;

                    if (prev < 0)
                        prev = 0;

                    lstSuggestions.SelectedIndex =
                        prev;

                    e.SuppressKeyPress = true;

                    return;
                }

                // Enter
                if (e.KeyCode == Keys.Enter)
                {
                    SelectSuggestion();

                    e.SuppressKeyPress = true;

                    return;
                }

                // Space
                if ((e.KeyCode == Keys.Enter ||
                     e.KeyCode == Keys.Space) &&
                     lstSuggestions.Visible &&
                     lstSuggestions.SelectedItem != null)
                {
                    SelectSuggestion();

                    e.SuppressKeyPress = true;

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AcceptSuggestion()
        {
            try
            {
                if (lstSuggestions.SelectedItem == null)
                    return;

                string selected =
                    lstSuggestions.SelectedItem
                        .ToString();

                string text =txtInput.Text;
                //string text =
                //    txtInput.Text.Trim();

                string[] parts =
                    text.Split(
                        new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                // مرحله اول

                if (parts.Length <= 1)
                {
                    txtInput.Text =
                        selected + " ";
                }

                // مرحله دوم

                else if (
                    parts[0].Equals(
                        "/createtype",
                        StringComparison.OrdinalIgnoreCase))
                {
                    txtInput.Text =
                        "/createtype " +
                        selected + " ";
                }

                txtInput.SelectionStart =
                    txtInput.Text.Length;

                lstSuggestions.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectSuggestion()
        {
            try
            {
                if (lstSuggestions.SelectedItem == null)
                    return;

                string selected =
                    lstSuggestions.SelectedItem.ToString();

                ApplySuggestion(selected);

                UpdateSuggestions();

                txtInput.Focus();

                txtInput.SelectionStart =
                    txtInput.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplySuggestion(string selected)
        {
            try
            {
                string text =
                    txtInput.Text;

                // Command Stage

                if (text.Length == 0 ||
                   !text.Contains(" "))
                {
                    txtInput.Text =
                        selected + " ";

                    return;
                }

                string[] parts =
                    text.Split(
                        new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                // /createtype Stage

                if (parts.Length >= 1 &&
                   parts[0].Equals(
                       "/createtype",
                       StringComparison.OrdinalIgnoreCase))
                {
                    txtInput.Text =
                        "/createtype " +
                        selected + " ";

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSuggestions()
        {
            try
            {
                lstSuggestions.Items.Clear();

                List<string> suggestions =
                    _engine.GetSuggestions(
                        txtInput.Text);

                foreach (string item in
                        suggestions)
                {
                    lstSuggestions.Items.Add(item);
                }

                lstSuggestions.Visible =
                    lstSuggestions.Items.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowSuggestions()
        {
            try
            {
                lstSuggestions.Visible =
                    lstSuggestions.Items.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstSuggestions.Items.Clear();

                MessageType type =
                    (MessageType)
                    Enum.Parse(
                        typeof(MessageType),
                        cmbMsgType.SelectedItem.ToString());

                var list =
                    suggestionProvider
                        .GetSuggestions(type);

                foreach (string item in list)
                {
                    lstSuggestions.Items.Add(item);
                }

                lstSuggestions.Visible =
                    list.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAiSettings_Click(object sender, EventArgs e)
        {

            grpSettings.Visible =
                !grpSettings.Visible;

        }
        
    }
}