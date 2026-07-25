using NP.Core.Catalogs;
using NP.Core.IntelliSense;
using System;
using System.Collections.Generic;

namespace NP.Services.IntelliSense
{
    public class IntelliSenseEngine
    {
        public List<string> GetSuggestions(string text)
        {
            try
            {
                List<string> result =
                    new List<string>();

                text = text ?? "";

                //----------------------------------
                // Stage 1
                //----------------------------------

                if (!text.StartsWith("/"))
                {
                    return result;
                }

                string[] parts =
                    text.Split(
                        new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                //----------------------------------
                // /createtype
                //----------------------------------

                if (parts.Length == 1)
                {
                    if (parts[0].Equals(
                        "/createtype",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (var item in
                                 SuggestionCatalog.ObjectTypes)
                        {
                            result.Add(item.Text);
                        }

                        return result;
                    }

                    //----------------------------------
                    // Command Suggestions
                    //----------------------------------

                    foreach (string cmd in
                             SuggestionCatalog.Commands)
                    {
                        if (cmd.StartsWith(
                            text,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(cmd);
                        }
                    }

                    return result;
                }

                //----------------------------------
                // /createtype Class
                //----------------------------------

                if (parts.Length == 2 &&
                    parts[0].Equals(
                        "/createtype",
                        StringComparison.OrdinalIgnoreCase))
                {
                    result.Add("[FileName (*.cs)]");

                    return result;
                }

                //----------------------------------
                // /createtype Class Customer
                //----------------------------------

                if (parts.Length >= 3 &&
                    parts[0].Equals(
                        "/createtype",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return result;
                }

                return result;
            }
            catch
            {
                return new List<string>();
            }
        }

        //public List<string> GetSuggestions(string text)
        //{
        //    try
        //    {
        //        List<string> result =
        //            new List<string>();

        //        text = text ?? "";

        //        bool endsWithSpace =
        //            text.EndsWith(" ");

        //        //----------------------------------
        //        // Stage 1
        //        //----------------------------------

        //        if (!text.StartsWith("/"))
        //        {
        //            return result;
        //        }

        //        //----------------------------------
        //        // Stage 2
        //        //----------------------------------

        //        if (text.StartsWith(
        //            "/createtype",
        //            StringComparison.OrdinalIgnoreCase))
        //        {
        //            if (endsWithSpace)
        //            {
        //                //result.AddRange(
        //                //    SuggestionCatalog.ObjectTypes);

        //                foreach (var item in SuggestionCatalog.ObjectTypes)
        //                {
        //                    result.Add(item.Text);
        //                }


        //                return result;
        //            }
        //        }

        //        //----------------------------------
        //        // Stage 3
        //        //----------------------------------

        //        foreach (string cmd in
        //                SuggestionCatalog.Commands)
        //        {
        //            if (cmd.StartsWith(
        //                text,
        //                StringComparison.OrdinalIgnoreCase))
        //            {
        //                result.Add(cmd);
        //            }
        //        }

        //        return result;
        //    }
        //    catch
        //    {
        //        return new List<string>();
        //    }
        //}
        //public List<string> GetSuggestions(string text)
        //{
        //    try
        //    {
        //        return new List<string>();
        //    }
        //    catch
        //    {
        //        return new List<string>();
        //    }
        //}

        public List<SuggestionItem> GetObjectTypes()
        {
            //return new List<SuggestionItem>();

            try
            {
                return SuggestionCatalog.ObjectTypes;
            }
            catch
            {
                return new List<SuggestionItem>();
            }
        }
    }
}