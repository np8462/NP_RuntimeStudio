using System.Text.RegularExpressions;

namespace NP.AI.Parsers
{
    public static class CodeBlockParser
    {
        public static string ExtractCode(
            string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            Match match =
                Regex.Match(
                    text,
                    @"```(?:csharp|cs|json)?\s*(.*?)```",
                    RegexOptions.Singleline |
                    RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return
                    match.Groups[1]
                    .Value
                    .Trim();
            }

            return null;
        }
    }
}