using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using NP.Core.AI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NP.AI.Mobile
{
    [Activity(Label = "Chat")]
    public class ChatActivity : Activity
    {
        ListView list;
        EditText input;
        Button send;

        List<ChatMessage> messages = new List<ChatMessage>();
        ChatAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Chat);

            list = FindViewById<ListView>(Resource.Id.listChat);
            input = FindViewById<EditText>(Resource.Id.txtMessage);
            send = FindViewById<Button>(Resource.Id.btnSend);

            adapter = new ChatAdapter(this, messages);
            list.Adapter = adapter;

            send.Click += async (s, e) =>
            {
                string text = input.Text;
                if (string.IsNullOrEmpty(text)) return;

                AddMessage("user", text);
                input.Text = "";

                await SendToAI(text);
            };
        }

        void AddMessage(string role, string text)
        {
            messages.Add(new ChatMessage
            {
                Role = role,
                Content = text
            });

            RunOnUiThread(() =>
            {
                adapter.NotifyDataSetChanged();
                list.SetSelection(messages.Count - 1);
            });
        }

        async Task SendToAI(string prompt)
        {
            await Task.Run(() =>
            {
                try
                {
                    string url =SettingsService.GetString(this, "url");
                    string key =SettingsService.GetString(this, "key");
                    string model =SettingsService.GetString(this, "model");

                    AiClient client = new AiClient(url, key, model);

                    string response =client.Send(prompt);
                    string text =                    client.ExtractText(response);
                    SimulateStreaming(text);

                    //string url = SettingsService.GetString(this, "url");
                    //string key = SettingsService.GetString(this, "key");
                    //string model = SettingsService.GetString(this, "model");

                    //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    //req.Method = "POST";
                    //req.ContentType = "application/json";
                    //req.Headers.Add("Authorization", "Bearer " + key);

                    //string json = "{"
                    //    + "\"model\":\"" + model + "\","
                    //    + "\"messages\":["
                    //    + "{\"role\":\"user\",\"content\":\"" + prompt + "\"}"
                    //    + "]"
                    //    + "}";

                    //byte[] data = Encoding.UTF8.GetBytes(json);
                    //req.ContentLength = data.Length;

                    //using (var stream = req.GetRequestStream())
                    //{
                    //    stream.Write(data, 0, data.Length);
                    //}

                    //var resp = (HttpWebResponse)req.GetResponse();

                    //string result;
                    //using (var reader = new StreamReader(resp.GetResponseStream()))
                    //{
                    //    result = reader.ReadToEnd();
                    //}

                    //string aiText = ExtractText(result);

                    //SimulateStreaming(aiText);
                }
                catch (System.Exception ex)
                {
                    AddMessage("assistant", "Error: " + ex.Message);
                }
            });
        }
        string ExtractText(string json)
        {
            try
            {
                JObject obj = JObject.Parse(json);
                return obj["choices"][0]["message"]["content"].ToString();
            }
            catch
            {
                return json;
            }
        }
        void SimulateStreaming(string text)
        {
            AddMessage("assistant", "");

            int index = messages.Count - 1;

            Task.Run(() =>
            {
                string current = "";

                foreach (char c in text)
                {
                    current += c;

                    messages[index].Content = current;

                    RunOnUiThread(() =>
                    {
                        adapter.NotifyDataSetChanged();
                        list.SetSelection(messages.Count - 1);
                    });

                    Thread.Sleep(20); // سرعت تایپ
                }
            });
        }
    }

    //public class ChatAdapter : BaseAdapter<ChatMessage>
    //{
    //    List<ChatMessage> items;
    //    Activity context;

    //    public ChatAdapter(Activity ctx, List<ChatMessage> list)
    //    {
    //        context = ctx;
    //        items = list;
    //    }

    //    public override ChatMessage this[int position]
    //    {
    //        get { return items[position]; }
    //    }

    //    public override int Count
    //    {
    //        get { return items.Count; }
    //    }

    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }

    //    public override View GetView(int position, View convertView, ViewGroup parent)
    //    {
    //        var item = items[position];

    //        var view = convertView ?? context.LayoutInflater.Inflate(
    //            Android.Resource.Layout.SimpleListItem2, null);

    //        var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
    //        var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);

    //        text1.Text = item.Role.ToUpper();
    //        text2.Text = item.Content;

    //        return view;
    //    }
    //}

    public class ChatAdapter : BaseAdapter<ChatMessage>
    {
        List<ChatMessage> items;
        Activity context;

        public ChatAdapter(Activity ctx, List<ChatMessage> list)
        {
            context = ctx;
            items = list;
        }

        public override ChatMessage this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var view = convertView ?? context.LayoutInflater.Inflate(
                Android.Resource.Layout.SimpleListItem2, null);

            var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            text1.Text = item.Role.ToUpper();
            text2.Text = item.Content;

            return view;
        }
    }

    public class ChatMessage
    {
        public string Role { get; set; } // user / assistant
        public string Content { get; set; }
    }
}