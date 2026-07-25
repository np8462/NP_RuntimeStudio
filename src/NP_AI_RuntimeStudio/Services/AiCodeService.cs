using NP.AI.Parsers;

namespace NP.AI.Services
{
    public class AiCodeService
    {
        public string GetCodeOnly(
            string aiResponse)
        {
            return
                CodeBlockParser
                .ExtractCode(
                    aiResponse);
        }
    }
}