using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Android.App;
using Android.OS;
using Android.Widget;

namespace NP.AI.Mobile
{
    [Activity(Label = "Network Test 2")]
    public class NetworkTest2Activity : Activity
    {
        Spinner spMethod;

        EditText txtUrl;
        EditText txtHeader;
        EditText txtBody;
        EditText txtResult;

        Button btnSend;
        Button btnClear;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NetworkTest2);

            spMethod =
                FindViewById<Spinner>(
                Resource.Id.spMethod);

            txtUrl =
                FindViewById<EditText>(
                Resource.Id.txtUrl);

            txtHeader =
                FindViewById<EditText>(
                Resource.Id.txtHeader);

            txtBody =
                FindViewById<EditText>(
                Resource.Id.txtBody);

            txtResult =
                FindViewById<EditText>(
                Resource.Id.txtResult);

            btnSend =
                FindViewById<Button>(
                Resource.Id.btnSend);

            btnClear =
                FindViewById<Button>(
                Resource.Id.btnClear);

            string[] items =
            {
                "DNS Lookup",
                "HttpWebRequest GET",
                "HttpWebRequest POST",
                "HttpClient GET",
                "HttpClient POST"
            };

            ArrayAdapter adapter =
                new ArrayAdapter(
                    this,
                    Android.Resource.Layout.SimpleSpinnerItem,
                    items);

            adapter.SetDropDownViewResource(
                Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spMethod.Adapter = adapter;

            btnSend.Click += BtnSend_Click;
            btnClear.Click += BtnClear_Click;
        }

        void BtnClear_Click(
            object sender,
            EventArgs e)
        {
            txtResult.Text = "";
        }

        void BtnSend_Click(
            object sender,
            EventArgs e)
        {
            string method =
                spMethod.SelectedItem.ToString();

            if (method == "DNS Lookup")
            {
                TestDns();
            }
            else
            {
                Task.Run(delegate
                {
                    ExecuteMethod(method);
                });
            }
        }

        void TestDns()
        {
            try
            {
                Uri uri =
                    new Uri(txtUrl.Text);

                string host =
                    uri.Host;

                string ip =
                    Dns.GetHostEntry(host)
                       .AddressList[0]
                       .ToString();

                txtResult.Text =
                    "HOST = " + host +
                    "\r\nIP = " + ip;
            }
            catch (Exception ex)
            {
                txtResult.Text =
                    ex.ToString();
            }
        }

        void ExecuteMethod(
            string method)
        {
            try
            {
                string result = "";

                if (method ==
                    "HttpWebRequest GET")
                {
                    result =
                        HttpWebGet();
                }
                else if (method ==
                    "HttpWebRequest POST")
                {
                    result =
                        HttpWebPost();
                }
                else if (method ==
                    "HttpClient GET")
                {
                    result =
                        HttpClientGet();
                }
                else if (method ==
                    "HttpClient POST")
                {
                    result =
                        HttpClientPost();
                }

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
        }

        string HttpWebGet()
        {
            HttpWebRequest req =
                (HttpWebRequest)
                WebRequest.Create(
                    txtUrl.Text);

            req.Method = "GET";

            HttpWebResponse resp =
                (HttpWebResponse)
                req.GetResponse();

            using (StreamReader reader =
                new StreamReader(
                    resp.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        string HttpWebPost()
        {
            HttpWebRequest req =
                (HttpWebRequest)
                WebRequest.Create(
                    txtUrl.Text);

            req.Method = "POST";

            req.ContentType =
                "application/json";

            byte[] data =
                Encoding.UTF8.GetBytes(
                    txtBody.Text);

            using (Stream stream =
                req.GetRequestStream())
            {
                stream.Write(
                    data,
                    0,
                    data.Length);
            }

            HttpWebResponse resp =
                (HttpWebResponse)
                req.GetResponse();

            using (StreamReader reader =
                new StreamReader(
                    resp.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        string HttpClientGet()
        {
            HttpClient client =
                new HttpClient();

            return client
                .GetStringAsync(
                    txtUrl.Text)
                .Result;
        }

        string HttpClientPost()
        {
            HttpClient client =
                new HttpClient();

            StringContent content =
                new StringContent(
                    txtBody.Text,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage resp =
                client.PostAsync(
                    txtUrl.Text,
                    content)
                .Result;

            return resp.Content
                .ReadAsStringAsync()
                .Result;
        }
    }
}