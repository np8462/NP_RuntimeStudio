using Newtonsoft.Json.Linq;

namespace NP.AI
{
    public static class AiResponseParser
    {
        public static string ExtractText(
        string rawResponse)
        {
            try
            {
                JObject obj =
                JObject.Parse(
                rawResponse);

                JToken token =
                    obj["response"];

                if (token != null)
                {
                    return token.ToString();
                }

                return rawResponse;
            }
            catch
            {
                return rawResponse;
            }
        }
    }

}