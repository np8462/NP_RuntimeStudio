using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NP.AI.Mobile
{
    [Activity(Label = "Settings")]
    public class SettingsActivity : Activity
    {
        EditText url, key, model, timeout;
        Button saveBtn, testBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Settings);

            url = FindViewById<EditText>(Resource.Id.txtApiUrl);
            key = FindViewById<EditText>(Resource.Id.txtApiKey);
            model = FindViewById<EditText>(Resource.Id.txtModel);
            timeout = FindViewById<EditText>(Resource.Id.txtTimeout);

            saveBtn = FindViewById<Button>(Resource.Id.btnSave);
            testBtn = FindViewById<Button>(Resource.Id.btnTest);

            LoadSettings();

            saveBtn.Click += (s, e) =>
            {
                SettingsService.Save(
                    this,
                    url.Text,
                    key.Text,
                    model.Text,
                    int.Parse(timeout.Text)
                );

                Toast.MakeText(this, "Saved!", ToastLength.Short).Show();
                Toast.MakeText(this, key.Text, ToastLength.Short).Show();

            };

            testBtn.Click += (s, e) =>
            {
                TestApi();
            };
        }

        void LoadSettings()
        {
            url.Text = SettingsService.GetString(this, "url");
            key.Text = SettingsService.GetString(this, "key");
            model.Text = SettingsService.GetString(this, "model");
            timeout.Text = SettingsService.GetInt(this, "timeout").ToString();
        }

        void TestApi()
        {
            try
            {
                string apiUrl = SettingsService.GetString(this, "url");
                string apiKey = SettingsService.GetString(this, "key");
                string model = SettingsService.GetString(this, "model");

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(apiUrl);
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers.Add("Authorization", "Bearer " + apiKey);

                string json = "{"
                    + "\"model\":\"" + model + "\","
                    + "\"messages\":[{\"role\":\"user\",\"content\":\"Hello\"}]"
                    + "}";

                byte[] data = Encoding.UTF8.GetBytes(json);
                req.ContentLength = data.Length;

                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var resp = (HttpWebResponse)req.GetResponse();

                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();

                    RunOnUiThread(() =>
                    {
                        Toast.MakeText(this, result, ToastLength.Long).Show();
                    });
                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}


        //using Android.Content;

public class SettingsService
{
    private const string PREF = "ai_settings";

    public static void Save(Context ctx, string url, string key, string model, int timeout)
    {
        var sp = ctx.GetSharedPreferences(PREF, FileCreationMode.Private);
        var edit = sp.Edit();

        edit.PutString("url", url);
        edit.PutString("key", key);
        edit.PutString("model", model);
        edit.PutInt("timeout", timeout);

        edit.Commit();
    }

    public static string GetString(Context ctx, string name, string def = "")
    {
        var sp = ctx.GetSharedPreferences(PREF, FileCreationMode.Private);
        return sp.GetString(name, def);
    }

    public static int GetInt(Context ctx, string name, int def = 30000)
    {
        var sp = ctx.GetSharedPreferences(PREF, FileCreationMode.Private);
        return sp.GetInt(name, def);
    }
}

