using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.OS;
using Android.Widget;

namespace NP.AI.Mobile
{
    [Activity(Label = "Network Test")]
    public class NetworkTestActivity : Activity
    {
        TextView txtResult;

        Button btnDns;
        Button btnHttp;
        Button btnHttpsGoogle;
        Button btnHttpsApi;
        Button btnHttpClient;
        Button btnClear;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NetworkTest);

            txtResult =
                FindViewById<TextView>(
                    Resource.Id.txtResult);

            btnDns =
                FindViewById<Button>(
                    Resource.Id.btnDns);

            btnHttp =
                FindViewById<Button>(
                    Resource.Id.btnHttp);

            btnHttpsGoogle =
                FindViewById<Button>(
                    Resource.Id.btnHttpsGoogle);

            btnHttpsApi =
                FindViewById<Button>(
                    Resource.Id.btnHttpsApi);

            btnHttpClient =
                FindViewById<Button>(
                    Resource.Id.btnHttpClient);

            btnClear =
                FindViewById<Button>(
                    Resource.Id.btnClear);

            btnDns.Click += BtnDns_Click;
            btnHttp.Click += BtnHttp_Click;
            btnHttpsGoogle.Click += BtnHttpsGoogle_Click;
            btnHttpsApi.Click += BtnHttpsApi_Click;
            btnHttpClient.Click += BtnHttpClient_Click;
            btnClear.Click += BtnClear_Click;
        }

        void BtnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        void BtnDns_Click(object sender, EventArgs e)
        {
            try
            {
                string ip =
                    Dns.GetHostEntry(
                        "apifreellm.com")
                    .AddressList[0]
                    .ToString();

                txtResult.Text =
                    "DNS OK\r\nIP = " + ip;
            }
            catch (Exception ex)
            {
                txtResult.Text =
                    ex.ToString();
            }
        }

        void BtnHttp_Click(object sender, EventArgs e)
        {
            Task.Run(delegate
            {
                try
                {
                    HttpWebRequest req =
                        (HttpWebRequest)
                        WebRequest.Create(
                            "http://example.com");

                    req.Method = "GET";

                    HttpWebResponse resp =
                        (HttpWebResponse)
                        req.GetResponse();

                    string result =
                        "HTTP OK\r\nStatus = "
                        + (int)resp.StatusCode;

                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            result;
                    });
                }
                catch (Exception ex)
                {
                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            ex.ToString();
                    });
                }
            });
        }

        void BtnHttpsGoogle_Click(object sender, EventArgs e)
        {
            Task.Run(delegate
            {
                try
                {
                    HttpWebRequest req =
                        (HttpWebRequest)
                        WebRequest.Create(
                            "https://www.google.com");

                    req.Method = "GET";
                    req.Timeout = 10000;

                    HttpWebResponse resp =
                        (HttpWebResponse)
                        req.GetResponse();

                    string result =
                        "GOOGLE HTTPS OK\r\nStatus = "
                        + (int)resp.StatusCode;

                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            result;
                    });
                }
                catch (Exception ex)
                {
                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            ex.ToString();
                    });
                }
            });
        }

        void BtnHttpsApi_Click(object sender, EventArgs e)
        {
            Task.Run(delegate
            {
                try
                {
                    //HttpWebRequest req =
                    //    (HttpWebRequest)
                    //    WebRequest.Create(
                    //        "https://apifreellm.com");
                    //req.Method = "GET";
                    //req.Timeout = 10000;
                    
                    //HttpWebRequest req =
                    //    (HttpWebRequest)
                    //    WebRequest.Create(
                    //        "https://apifreellm.com");
                    //req.Method = "GET";
                    //req.Timeout = 10000;
                    //req.UserAgent =
                    //    "Mozilla/5.0";
                    //req.Accept = "*/*";
                    //req.KeepAlive = false;

                    HttpWebRequest req =
    (HttpWebRequest)WebRequest.Create(
        "https://apifreellm.com/api/v1/chat");
        //"https://apifreellm.com");

                    req.Method = "GET";
                    req.Timeout = 10000;

                    req.UserAgent = "Mozilla/5.0 (Linux; Android 7.1)";
                    req.Accept = "application/json";
                    req.KeepAlive = false;
                    req.Headers.Add("Accept-Language", "en-US");

                    HttpWebResponse resp =
                        (HttpWebResponse)
                        req.GetResponse();

                    string result =
                        "API HTTPS OK\r\nStatus = "
                        + (int)resp.StatusCode;

                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            result;
                    });
                }
                catch (Exception ex)
                {
                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            ex.ToString();
                    });
                }
            });
        }

        void BtnHttpClient_Click(object sender, EventArgs e)
        {
            Task.Run(delegate
            {
                try
                {
                    //HttpClient client =
                    //    new HttpClient();

                    //string result =
                    //    client.GetStringAsync(                  
                    //        "https://apifreellm.com")
                    //    .Result;
                    HttpClient client = new HttpClient();
                    string result =
                        client.GetStringAsync(
                            "https://apifreellm.com/api/v1/chat")
                         //   "https://httpbin.org/get")
                        .Result;

                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            "HttpClient OK\r\n\r\n"
                            + result;
                    });
                }
                catch (Exception ex)
                {
                    RunOnUiThread(delegate
                    {
                        txtResult.Text =
                            ex.ToString();
                    });
                }
            });
        }
    }
}