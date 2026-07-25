using System;

namespace NP.Services.Utilities
{
    public static class StringUtility
    {
        public static bool IsNullOrWhiteSpace(string value)
        {
            return String.IsNullOrEmpty(value)
                   || value.Trim().Length == 0;
        }
    }
}