using NP.AI;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
public class OpenAiProvider
    : IAiProvider
{
    private readonly AiSettings _settings;

    public OpenAiProvider(
        AiSettings settings)
    {
        _settings = settings;
    }

    public Task<string> SendAsync(
        string prompt)
    {
        return SendPromptAsync(
            prompt);
    }

    public async Task<string> SendPromptAsync(
        string prompt)
    {
        return await Task.Run(() =>
        {
            string json =
                @"{""message"":""" +
                prompt.Replace(@"""", @"'") +
                @"""}";

            HttpWebRequest request =
                (HttpWebRequest)
                WebRequest.Create(
                    _settings.BaseUrl);

            request.Method =
                "POST";

            request.ContentType =
                "application/json";

            request.Headers.Add(
                "Authorization",
                "Bearer " +
                _settings.ApiKey);

            byte[] data =
                Encoding.UTF8.GetBytes(
                    json);

            using (Stream stream =
                request.GetRequestStream())
            {
                stream.Write(
                    data,
                    0,
                    data.Length);
            }

            HttpWebResponse response =
                (HttpWebResponse)
                request.GetResponse();

            using (StreamReader reader =
                new StreamReader(
                    response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        });
    }
}