using Newtonsoft.Json.Linq;

namespace NP.AI.Parsers
{
    public static class AiResponseParser
    {
        public static string ExtractText(string rawResponse)
        {
            try
            {
                JObject obj = JObject.Parse(rawResponse);

                if (obj["response"] != null)
                    return obj["response"].ToString();

                return rawResponse;
            }
            catch
            {
                return rawResponse;
            }
        }
    }
}