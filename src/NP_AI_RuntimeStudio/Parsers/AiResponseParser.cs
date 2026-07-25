using Newtonsoft.Json.Linq;

namespace NP.AI.Parsers
{
    public static class AiResponseParser
    {
        public static string ExtractText(string rawResponse)
        {
            if (string.IsNullOrWhiteSpace(rawResponse))
                return string.Empty;

            try
            {
                JObject obj = JObject.Parse(rawResponse);

                JToken token = obj["response"];

                if (token != null && token.Type != JTokenType.Null)
                    return token.ToString();

                return rawResponse;
            }
            catch
            {
                return rawResponse;
            }
        }
    }
}