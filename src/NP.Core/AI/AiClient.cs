using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace NP.Core.AI
{
    public class AiClient
    {
        private string url;
        private string apiKey;
        private string model;

        public AiClient(string url, string apiKey, string model)
        {
            this.url = url;
            this.apiKey = apiKey;
            this.model = model;
        }

        public string Send(string prompt)
        {
            HttpClient client =
                new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    apiKey);

            string json =
                "{"
                + "\"model\":\"" + model + "\","
                + "\"messages\":["
                + "{\"role\":\"user\",\"content\":\""
                + prompt.Replace("\"", "\\\"")
                + "\"}"
                + "]"
                + "}";
            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            HttpResponseMessage response =
                client.PostAsync(
                    url,
                    content).Result;

            return response.Content
                           .ReadAsStringAsync()
                           .Result;
        }
    //    public string Send(string prompt)
    //    {


    ////        ServicePointManager.SecurityProtocol =
    ////(SecurityProtocolType)3072;
    ////        ServicePointManager.SecurityProtocol =
    ////SecurityProtocolType.Tls12;
    //        HttpWebRequest req =
    //            (HttpWebRequest)WebRequest.Create(url);

    //        req.Method = "POST";
    //        req.ContentType = "application/json";

    //        req.Headers.Add(
    //            "Authorization",
    //            "Bearer " + apiKey);

    //        string json =
    //            "{"
    //            + "\"model\":\"" + model + "\","
    //            + "\"messages\":["
    //            + "{\"role\":\"user\",\"content\":\""
    //            + prompt.Replace("\"", "\\\"")
    //            + "\"}"
    //            + "]"
    //            + "}";

    //        byte[] data =
    //            Encoding.UTF8.GetBytes(json);

    //        req.ContentLength = data.Length;

    //        using (Stream stream =
    //            req.GetRequestStream())
    //        {
    //            stream.Write(data, 0, data.Length);
    //        }

    //        using (HttpWebResponse resp =
    //            (HttpWebResponse)req.GetResponse())
    //        {
    //            using (StreamReader reader =
    //                new StreamReader(resp.GetResponseStream()))
    //            {
    //                return reader.ReadToEnd();
    //            }
    //        }
    //    }

        public string ExtractText(string json)
        {
            try
            {
                var obj =
                    Newtonsoft.Json.Linq.JObject.Parse(json);

                return obj["choices"][0]
                          ["message"]
                          ["content"]
                          .ToString();
            }
            catch
            {
                return json;
            }
        }
    }
}