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

        public static readonly List<string> ObjectTypes =
            new List<string>
        {
            "Class",
            "Form",
            "Interface",
            "Enum",
            "Struct",
            "Repository",
            "Service",
            "Module",
            "Library",
            "Project",
            "Custom"
        };

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