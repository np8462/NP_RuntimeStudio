using NP.AI;
using NP.Commands.Classification;
using NP.Commands.Engine;
using NP.Commands.IntelliSense;
using NP.Commands.Runtime;
using NP.Commands.Validation;
using NP.Core.Catalogs;
using NP.Core.Models;
using NP.Host.Storage;
using NP.Storage.Repositories;
//using NP.Storage.Database;
//using NP.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using NP.Storage.Repositories;

namespace NP.Host
{
    public partial class ChatStudioForm : Form
    {
        private ChatRepository repo =new ChatRepository();
        private List<ChatMessage> messages =  new List<ChatMessage>();

        //private JsonChatStorage storage =new JsonChatStorage();
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

        public ChatStudioForm()
        {
            InitializeComponent();

            _engine =    new IntelliSenseEngine();

            _controller =                new IntelliSenseController();

            LoadMessages();

        }
        //public ChatStudioForm()
        //{
        //    InitializeComponent();

        //    //DbManager.Initialize();

        //    LoadHistory();
        //}

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
        //private void AppendMessage(ChatMessage msg)
        //{
        //    Color color = Color.Gray;

        //    switch (msg.Type)
        //    {
        //        case MessageType.Command:
        //            color = Color.Orange;
        //            break;

        //        case MessageType.Meta:
        //            color = Color.LightGray;
        //            break;

        //        case MessageType.System:
        //            color = Color.LightBlue;
        //            break;

        //        case MessageType.Error:
        //            color = Color.Red;
        //            break;
        //    }

        //    rtbChat.SelectionStart =
        //        rtbChat.TextLength;

        //    rtbChat.SelectionColor = color;

        //    rtbChat.AppendText(
        //        "[" + msg.Type + "] " +
        //        msg.Content +
        //        Environment.NewLine);

        //    rtbChat.SelectionColor =
        //        rtbChat.ForeColor;

        //    rtbChat.ScrollToCaret();
        //}
        //private void AppendMessage(ChatMessage msg)
        //{
        //    Color color = Color.White;

        //    switch (msg.Type)
        //    {
        //        case MessageType.Comment:
        //            color = Color.LightGray;
        //            break;

        //        case MessageType.Command:
        //            color = Color.Orange;
        //            break;

        //        case MessageType.Meta:
        //            color = Color.DarkGray;
        //            break;

        //        case MessageType.Planning:
        //            color = Color.DeepSkyBlue;
        //            break;

        //        case MessageType.System:
        //            color = Color.LimeGreen;
        //            break;

        //        case MessageType.Error:
        //            color = Color.Red;
        //            break;

        //        case MessageType.Generation:
        //            color = Color.Gold;
        //            break;

        //        case MessageType.RuntimeEvent:
        //            color = Color.Violet;
        //            break;
        //    }

        //    rtbChat.SelectionStart =
        //        rtbChat.TextLength;

        //    rtbChat.SelectionColor =
        //        color;

        //    rtbChat.AppendText(
        //        "[" + msg.Type + "] " +
        //        msg.Content +
        //        Environment.NewLine);

        //    rtbChat.SelectionColor =
        //        rtbChat.ForeColor;
        //}
        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string txt =
                    txtInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(txt))
                    return;

                //MessageType type =
                //    classifier.Classify(txt);
                MessageType type = (MessageType)Enum.Parse(typeof(MessageType), cmbMsgType.SelectedItem.ToString());


                string validationError;

                if (!validator.Validate(
                    type,
                    txt,
                    out validationError))
                {
                    MessageBox.Show(validationError);

                    return;
                }

                ChatMessage msg =
                    new ChatMessage();

                msg.Id = Guid.NewGuid();

                msg.SessionId = "MAIN";

                msg.Role = "User";

                msg.Content = txt;

                msg.Type = type;

                msg.IsExecutable =                    type == MessageType.Command;

                msg.CreatedAt =                    DateTime.Now;

                msg.ColorTag =type.ToString();

                msg.Content =    txt;

                msg.RawContent =                    txt;

                messages.Add(msg);

                storage.Save(messages);

                AppendMessage(msg);

                //}
                //catch (Exception)
                //{

                //    throw;
                //}


                //try
                //{
                if (type == MessageType.Command)
                {
                    string cmdName;
                    string[] cmdArgs;

                    bool ok =
                        parser.TryParse(
                            txt,
                            out cmdName,
                            out cmdArgs);

                    if (ok)
                    {
                        ChatMessage result =
                            executor.Execute(
                                cmdName,
                                cmdArgs);

                        messages.Add(result);

                        storage.Save(messages);

                        AppendMessage(result);
                    }
                }
                if (type == MessageType.AIRequest)
                {
                    await AskAiAsync(txt);
                }

                txtInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //private async void btnSend_Click(object sender,  EventArgs e)
        //{
        //    try
        //    {
        //        AiSettings settings =
        //            new AiSettings
        //            {
        //                ApiKey =
        //                    txtApiKey.Text,

        //                Model =
        //                    "gpt-5",

        //                BaseUrl =
        //                    "https://api.openai.com/v1/responses"
        //            };

        //        IAiProvider ai =
        //            new OpenAiProvider(
        //                settings);

        //        string answer =
        //            await ai.SendPromptAsync(
        //                txtInput.Text);

        //        txtOutput.Text =
        //            answer;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            ex.Message);
        //    }
        //}

        private async Task AskAiAsync(string prompt)
        {
            try
            {
                btnSend.Enabled = false;

                txtInput.Enabled = false;

                Cursor = Cursors.WaitCursor;

                // TODO:
                // toolStripStatusLabel.Text =
                // "Waiting for AI response...";

                // TODO:
                // progressBar.Visible = true;


                IAiProvider ai = CreateProvider();
                //AiSettings settings =
                //    new AiSettings
                //    {
                //        //ApiKey = txtApiKey.Text,
                //        ApiKey = "",
                //        Model = "gpt-5",
                //        BaseUrl =
                //            "https://api.openai.com/v1/responses"
                //    };

                //IAiProvider ai =
                //    new OpenAiProvider(
                //        settings);

                //string answer =
                //    await ai.SendPromptAsync(
                //        prompt);
                string rawJson =
                    await ai.SendPromptAsync(prompt);

                string parsedText =
                    AiResponseParser
                        .ExtractText(
                            rawJson);
                ChatMessage msg =
                    new ChatMessage();

                msg.Id =
                    Guid.NewGuid();

                msg.SessionId =
                    "MAIN";

                msg.Role =
                    "Assistant";

                msg.RawContent = rawJson;

                msg.Content = parsedText;

                //msg.Type =
                //    MessageType.AIResponse;
                if (rawJson.Contains("\"success\":\"false\"") || rawJson.Contains("\"error\""))
                {
                    msg.Type =
                    MessageType.Error;
                }
                else
                {
                    msg.Type =
                    MessageType.AIResponse;
                }

                msg.CreatedAt =
                    DateTime.Now;



                //string response = await ai.SendPromptAsync(prompt);

                //if (response.Contains("\"error\""))
                //{
                //    msg.Type =
                //        MessageType.Error;
                //}
                //else
                //{
                //    msg.Type =
                //        MessageType.AIResponse;
                //}



                messages.Add(msg);

                storage.Save(messages);

                AppendMessage(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString());
            }
            finally
            {
                btnSend.Enabled = true;

                txtInput.Enabled = true;

                Cursor = Cursors.Default;

                // TODO:
                // toolStripStatusLabel.Text =
                // "Ready";

                // TODO:
                // progressBar.Visible = false;
            }

        }

        private IAiProvider CreateProvider()
        {
            AiSettings settings = new AiSettings();

            settings.ApiKey = "apf_g6ej4jq56pe49p2n885otj8n";
           
            settings.Model = "";

            settings.BaseUrl = "https://apifreellm.com/api/v1/chat";

            settings.TimeoutSeconds = 300;

            return new OpenAiProvider(settings);
        }


        //private IAiProvider CreateProvider()
        //{
        //    AiSettings settings =
        //        new AiSettings();

        //    settings.ApiKey = @"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";
        //        //@"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";
        //        //@"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";

        //    settings.Model = "gpt2"; 
        //        //"gpt-4o-mini";
        //        //"gpt-5";

        //    settings.BaseUrl = "https://api-inference.huggingface.co/models/" + settings.Model;
        //        //"https ://api.openai.com/v1/responses";

        //    return new OpenAiProvider(
        //        settings);
        //}

        private void ChatStudioForm_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectRepository repo =new ProjectRepository();
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void txtInput_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string text =
        //            txtInput.Text.Trim();

        //        if (!text.StartsWith("/"))
        //        {
        //            lstSuggestions.Visible = false;
        //            return;
        //        }

        //        lstSuggestions.Items.Clear();


        //        if (text.StartsWith("/createtype "))
        //        {
        //            string filter =
        //                text.Replace(
        //                    "/createtype ",
        //                    "");

        //            foreach (string type in
        //                ObjectTypeCatalog.GetTypes())
        //            {
        //                if (type.StartsWith(
        //                    filter,
        //                    StringComparison.OrdinalIgnoreCase))
        //                {
        //                    lstSuggestions.Items.Add(type);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (string cmd in
        //                     SuggestionCatalog.Commands)
        //            {
        //                if (cmd.StartsWith(
        //                    text,
        //                    StringComparison.OrdinalIgnoreCase))
        //                {
        //                    lstSuggestions.Items.Add(cmd);
        //                }
        //            }
        //        }


        //        //foreach (string cmd in
        //        //         CommandCatalog.Commands)
        //        //{
        //        //    if (cmd.StartsWith(
        //        //        text,
        //        //        StringComparison.OrdinalIgnoreCase))
        //        //    {
        //        //        lstSuggestions.Items.Add(cmd);
        //        //    }
        //        //}

        //        lstSuggestions.Visible =
        //            lstSuggestions.Items.Count > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
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
        //private void lstSuggestions_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lstSuggestions.SelectedItem == null)
        //            return;

        //        txtInput.Text =
        //            lstSuggestions.SelectedItem
        //                .ToString();

        //        txtInput.SelectionStart =
        //            txtInput.Text.Length;

        //        lstSuggestions.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        //private void AcceptSuggestion()
        //{
        //    try
        //    {
        //        if (lstSuggestions.SelectedItem == null)
        //            return;

        //        string selected =
        //            lstSuggestions.SelectedItem.ToString();

        //        if (txtInput.Text.StartsWith("/createtype "))
        //        {
        //            txtInput.Text =
        //                "/createtype " + selected;
        //        }
        //        else
        //        {
        //            txtInput.Text = selected;
        //        }

        //        txtInput.SelectionStart =
        //            txtInput.Text.Length;

        //        lstSuggestions.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
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
        //private void AcceptSuggestion()
        //{
        //    try
        //    {
        //        if (lstSuggestions.SelectedItem == null)
        //            return;

        //        txtInput.Text =
        //            lstSuggestions.SelectedItem
        //                .ToString();

        //        txtInput.SelectionStart =
        //            txtInput.Text.Length;

        //        lstSuggestions.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

                //foreach (var item in _engine.GetObjectTypes())
                //{
                //    lstSuggestions.Items.Add(item);
                //}


                lstSuggestions.Visible =
                    lstSuggestions.Items.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void UpdateSuggestions()
        //{
        //    try
        //    {
        //        lstSuggestions.Items.Clear();

        //        //string text =
        //        //    txtInput.Text.Trim();
        //        string text =txtInput.Text;

        //        bool endsWithSpace =
        //            text.EndsWith(" ");

        //        string[] parts =
        //            text.Split(
        //                new[] { ' ' },
        //                StringSplitOptions.RemoveEmptyEntries);

        //        if (text.StartsWith("/createtype",StringComparison.OrdinalIgnoreCase))
        //        {
        //            if (endsWithSpace)
        //            {
        //                foreach (string item in
        //                    SuggestionCatalog.ObjectTypes)
        //                {
        //                    lstSuggestions.Items.Add(item);
        //                }

        //                lstSuggestions.Visible =
        //                    lstSuggestions.Items.Count > 0;

        //                return;
        //            }
        //        }

        //        // ---------- مرحله اول ----------
        //        // نمایش Command ها

        //        if (parts.Length == 0)
        //            return;

        //        if (parts.Length == 1)
        //        {
        //            foreach (string cmd in
        //                SuggestionCatalog.Commands)
        //            {
        //                if (cmd.StartsWith(
        //                    parts[0],
        //                    StringComparison.OrdinalIgnoreCase))
        //                {
        //                    lstSuggestions.Items.Add(cmd);
        //                }
        //            }
        //        }

        //        // ---------- مرحله دوم ----------
        //        // /createtype

        //        else if (
        //            parts[0].Equals(
        //                "/createtype",
        //                StringComparison.OrdinalIgnoreCase))
        //        {
        //            if (parts.Length == 1)
        //            {
        //                foreach (string type in
        //                    SuggestionCatalog.ObjectTypes)
        //                {
        //                    lstSuggestions.Items.Add(type);
        //                }
        //            }
        //            else if (parts.Length == 2)
        //            {
        //                foreach (string type in
        //                    SuggestionCatalog.ObjectTypes)
        //                {
        //                    if (type.StartsWith(
        //                        parts[1],
        //                        StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        lstSuggestions.Items.Add(type);
        //                    }
        //                }
        //            }
        //        }

        //        lstSuggestions.Visible =
        //            lstSuggestions.Items.Count > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    string txt =
        //        txtInput.Text.Trim();

        //    if (string.IsNullOrWhiteSpace(txt))
        //        return;

        //    bool isCommand =
        //        txt.StartsWith("/");

        //    //MessageType type =
        //    //    isCommand
        //    //    ? MessageType.Command
        //    //    : MessageType.Meta;
        //    MessageType type =    classifier.Classify(txt);

        //    ChatMessage msg =
        //        new ChatMessage();

        //    msg.Id = Guid.NewGuid();

        //    msg.SessionId = sessionId;

        //    msg.Role = "User";

        //    msg.Content = txt;

        //    msg.Type = type;

        //    msg.IsExecutable = isCommand;

        //    msg.CreatedAt = DateTime.Now;

        //    msg.ColorTag =
        //        isCommand
        //        ? "Orange"
        //        : "Gray";

        //    repo.Insert(msg);

        //    AppendMessage(msg);

        //    if (isCommand)
        //    {
        //        var result =
        //            cmd.Execute(txt);

        //        ChatMessage sys =
        //            new ChatMessage();

        //        sys.Id = Guid.NewGuid();

        //        sys.SessionId = sessionId;

        //        sys.Role = "System";

        //        sys.Content = result.Message;

        //        sys.Type = result.Success
        //            ? MessageType.System
        //            : MessageType.Error;

        //        sys.IsExecutable = false;

        //        sys.CreatedAt = DateTime.Now;

        //        AppendMessage(sys);

        //        repo.Insert(sys);
        //    }

        //    txtInput.Clear();
        //}
    }
}
