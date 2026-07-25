using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;

namespace NP.AI.Mobile
{
    [Activity(Label = "NP.AI.Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            Toast.MakeText(this, "changed 1...", ToastLength.Short).Show();
            //try
            //{
            //    WebRequest req =
            //        //WebRequest.Create("https://www.google.com");
            //    WebRequest.Create("https://apifreellm.com");
            

            //    WebResponse resp =
            //        req.GetResponse();
            //    Toast.MakeText(this, "Internet OK", ToastLength.Short).Show();
            //}
            //catch (Exception ex)
            //{
            //    Toast.MakeText(this, "try1:" + ex.Message, ToastLength.Short).Show();
            //}
            try
            {
                HttpWebRequest req =
                    (HttpWebRequest)WebRequest.Create(
                        "apifreellm.com");

                req.Method = "GET";

                req.Timeout = 10000;

                using (HttpWebResponse resp =
                    (HttpWebResponse)req.GetResponse())
                {
                    Toast.MakeText(
                        this,
                        "Status=" + ((int)resp.StatusCode),
                        ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(
                    this,"ex1: "+
                    ex.ToString(),
                    ToastLength.Long).Show();
            }
            try
            {
                string ip =
                    //System.Net.Dns.GetHostEntry("https://httpbin.org/get")
                    System.Net.Dns.GetHostEntry("httpbin.org")
                                  .AddressList[0]
                                  .ToString();

                                Toast.MakeText(this, "Try2: "+ip, ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this,"ex2:"+ ex.Message, ToastLength.Short).Show();
            }
            base.OnCreate(bundle);

            new AlertDialog.Builder(this)
                .SetTitle("Debug")
                .SetMessage("OnCreate Started")
                .SetPositiveButton("OK", delegate { })
                .Show();

            SetContentView(Resource.Layout.Main);

            Button btnChat = FindViewById<Button>(Resource.Id.btnChat);
            Button btnTest = FindViewById<Button>(Resource.Id.btnTestApi);
            Button btnSettings = FindViewById<Button>(Resource.Id.btnSettings);
            Button btnTools = FindViewById<Button>(Resource.Id.btnTools);
            Button btnNetworkTest = FindViewById<Button>(Resource.Id.btnNetworkTest);
            Button btnNetworkTest2 = FindViewById<Button>(Resource.Id.btnNetworkTest2);

            btnSettings.Click += (s, e) =>
            {
                StartActivity(typeof(SettingsActivity));
            };

            btnTest.Click += (s, e) =>
            {
                StartActivity(typeof(TestApiActivity));
            };

            btnChat.Click += (s, e) =>
            {
                StartActivity(typeof(ChatActivity));
            };

            btnTools.Click += (s, e) =>
            {
                //StartActivity(typeof(NetworkTestActivity));
            };
            btnNetworkTest.Click += (s, e) =>
            {
                StartActivity(typeof(NetworkTestActivity));
            };
            btnNetworkTest2.Click += (s, e) =>
            {
                StartActivity(typeof(NetworkTest2Activity));
            };
        }

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    // Set our view from the "main" layout resource
        //    SetContentView(Resource.Layout.Main);

        //    // Get our button from the layout resource,
        //    // and attach an event to it
        //    Button button = FindViewById<Button>(Resource.Id.MyButton);

        //    button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        //}
    }
}

