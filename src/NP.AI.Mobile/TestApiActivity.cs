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
using System.Threading.Tasks;

namespace NP.AI.Mobile
{
    [Activity(Label = "Test API")]
    public class TestApiActivity : Activity
    {
        EditText prompt;
        Button btnText, btnJson;
        TextView result;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TestApi);

            prompt = FindViewById<EditText>(Resource.Id.txtPrompt);
            btnText = FindViewById<Button>(Resource.Id.btnSendNormal);
            btnJson = FindViewById<Button>(Resource.Id.btnSendJson);
            result = FindViewById<TextView>(Resource.Id.txtResult);

            btnText.Click += delegate { SendRequest(false); };
            btnJson.Click += delegate { SendRequest(true); };
        }
        void SendRequest(bool showJson)
        {
            Task.Run(() =>
            {
                try
                {
                    string url =SettingsService.GetString(this, "url");
                    string key =                    SettingsService.GetString(this, "key");
                    string model =                    SettingsService.GetString(this, "model");
                    AiClient client =new AiClient(url, key, model);
                    string responseText =client.Send(prompt.Text);

                    //string apiUrl = SettingsService.GetString(this, "url");
                    //string apiKey = SettingsService.GetString(this, "key");
                    //string model = SettingsService.GetString(this, "model");
                    // HttpWebRequest ...
                    //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(apiUrl);
                    //req.Method = "POST";
                    //req.ContentType = "application/json";
                    //req.Headers.Add("Authorization", "Bearer " + apiKey);

                    //string json = "{"
                    //    + "\"model\":\"" + model + "\","
                    //    + "\"messages\":["
                    //    + "{\"role\":\"user\",\"content\":\"" + prompt.Text + "\"}"
                    //    + "]"
                    //    + "}";

                    //byte[] data = Encoding.UTF8.GetBytes(json);
                    //req.ContentLength = data.Length;

                    //using (Stream s = req.GetRequestStream())
                    //{
                    //    s.Write(data, 0, data.Length);
                    //}

                    //var resp = (HttpWebResponse)req.GetResponse();

                    //string responseText;
                    //using (StreamReader r = new StreamReader(resp.GetResponseStream()))
                    //{
                    //    responseText = r.ReadToEnd();
                    //}

                    string output;

                    if (showJson)
                    {
                        output = responseText;
                    }
                    else
                    {
                        output = ExtractText(responseText);
                    }

                    RunOnUiThread(() =>
                    {
                        result.Text = output;
                    });

                    result.Text =
                        "KEY=" + key;
                }
                catch (System.Exception ex)
                {
                    RunOnUiThread(() =>
                    {
                        result.Text = "ERROR: " + ex.Message;
                    });
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


    }
}