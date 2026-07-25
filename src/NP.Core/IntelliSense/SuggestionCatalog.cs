using NP.Core.IntelliSense;
using System.Collections.Generic;

namespace NP.Core.Catalogs
{
    public static class SuggestionCatalog
    {
        public static readonly List<string> Commands =
            new List<string>
        {
            "/createfolder",
            "/createtype",
            "/createfile",
            "/writefile",
            "/readfile",
            "/listfiles",
            "/help",
            "/clear"
        };

        public static readonly List<SuggestionItem> ObjectTypes =new List<SuggestionItem>
        {
            new SuggestionItem
            {
                Text = "Class",
                Description =
                    "C# Class",

                Extension = "*.cs"
            },

            new SuggestionItem
            {
                Text = "Form",
                Description =
                    "WinForms Form",

                Extension = "*.cs"
            },

            new SuggestionItem
            {
                Text = "Json",
                Description =
                    "JSON File",

                Extension = "*.json"
            },

            new SuggestionItem
            {
                Text = "Html",
                Description =
                    "HTML File",

                Extension = "*.html"
            },

            new SuggestionItem
            {
                Text = "Custom",
                Description =
                    "User Defined Type",

                Extension = ""
            }
        };
        //public static readonly List<string> ObjectTypes =
        //    new List<string>
        //{
        //    "Class",
        //    "Form",
        //    "Interface",
        //    "Enum",
        //    "Struct",
        //    "Repository",
        //    "Service",
        //    "Module",
        //    "Library",
        //    "Project",
        //    "Custom"
        //};

        public static readonly List<string> Planning =
            new List<string>
        {
            "Design Module",
            "Create Architecture",
            "Add Workflow",
            "Create Entity"
        };

        public static readonly List<string> Meta =
            new List<string>
        {
            "Developer Note",
            "Internal Note",
            "Future Task"
        };

        public static readonly List<string> Memory =
            new List<string>
        {
            "Remember Project Goal",
            "Remember Entity",
            "Remember Runtime State"
        };

        public static readonly List<string> Debug =
            new List<string>
        {
            "Runtime Error",
            "Compile Error",
            "Trace Event"
        };
        
        public static readonly List<string>
        AIRequests =
            new List<string>
        {
            "Explain Code",
            "Refactor Code",
            "Generate Class",
            "Generate Interface",
            "Generate Repository",
            "Create Documentation"
        };
    }
}
    //public static class SuggestionCatalog
    //{
    //    public static readonly List<string> Commands =
    //        new List<string>
    //        {
    //            "/createfolder",
    //            "/createtype",
    //            "/createfile",
    //            "/writefile",
    //            "/readfile",
    //            "/listfiles",
    //            "/help",
    //            "/clear"
    //        };

    //    public static readonly List<string> Planning =
    //        new List<string>
    //        {
    //            "Design Module",
    //            "Create Architecture",
    //            "Add Workflow",
    //            "Create Entity"
    //        };

    //    public static readonly List<string> Meta =
    //        new List<string>
    //        {
    //            "Developer Note",
    //            "Internal Note",
    //            "Future Task"
    //        };

    //    public static readonly List<string> Memory =
    //        new List<string>
    //        {
    //            "Remember Project Goal",
    //            "Remember Entity",
    //            "Remember Runtime State"
    //        };

    //    public static readonly List<string> Debug =
    //        new List<string>
    //        {
    //            "Runtime Error",
    //            "Compile Error",
    //            "Trace Event"
    //        };
    //}
//}

    //public static class CommandCatalog
    //{
    //    public static List<string> Commands =
    //        new List<string>
    //        {
    //            "/createfolder",
    //            "/createtype",
    //            "/createfile",
    //            "/writefile",
    //            "/readfile",
    //            "/listfiles",
    //            "/help",
    //            "/clear"
    //        };

        //public static List<string> Commands =
        //    new List<string>
        //    {
        //        "/createfolder",
        //        "/createfile",
        //        "/writefile",
        //        "/readfile",
        //        "/listfiles",
        //        "/createclass",
        //        "/createform",
        //        "/help"
        //    };
//    }
//}