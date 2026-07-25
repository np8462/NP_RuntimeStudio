using System.IO;
using System.Xml;

namespace NP.Services.Development
{
    public class BuildAnalyzer
    {
        public BuildOutputKind Analyze(
            string file)
        {
            if (!File.Exists(file))
            {
                return
                    BuildOutputKind.Library;
            }

            string code =
                File.ReadAllText(file);

            //--------------------------------

            if (code.Contains(
                "static void Main"))
            {
                if (code.Contains(
                    "Application.Run"))
                {
                    return
                        BuildOutputKind.WindowsExe;
                }

                return
                    BuildOutputKind.ConsoleExe;
            }

            //--------------------------------

            return
                BuildOutputKind.Library;
        }
    //    public BuildProject Analyze(
    //BuildProject project)
    //    {
    //        if (project == null)
    //            return project;

    //        if (!project.HasProjectFile)
    //            return project;

    //        XmlDocument xml =
    //            new XmlDocument();

    //        xml.Load(
    //            project.ProjectFile);

    //        //-------------------------------------------------
    //        // OutputType
    //        //-------------------------------------------------

    //        XmlNode node =
    //            xml.SelectSingleNode(
    //                "//OutputType");

    //        if (node != null)
    //        {
    //            project.OutputType =
    //                node.InnerText;
    //        }

    //        //-------------------------------------------------
    //        // Framework
    //        //-------------------------------------------------

    //        node =
    //            xml.SelectSingleNode(
    //                "//TargetFrameworkVersion");

    //        if (node != null)
    //        {
    //            project.TargetFramework =
    //                node.InnerText;
    //        }
    //        return project;
    //    }

        public BuildProject Analyze(
        BuildProject project)
        {
            if (project == null)
                return null;

            if (!project.HasProjectFile)
            {
                AnalyzeSmartProject(
                    project);

                return project;
            }

            AnalyzeProjectFile(
                project);

            return project;
        }

        private void AnalyzeProjectFile(
    BuildProject project)
        {
            if (!File.Exists(
                project.ProjectFile))
            {
                return;
            }

            XmlDocument xml =
                new XmlDocument();

            xml.Load(
                project.ProjectFile);

            ReadOutputType(
                xml,
                project);

            ReadTargetFramework(
                xml,
                project);

            ReadReferences(
                xml,
                project);
        }
        private void ReadOutputType(
    XmlDocument xml,
    BuildProject project)
        {
            XmlNode node =
                xml.SelectSingleNode(
                    "//OutputType");

            if (node == null)
                return;

            project.OutputType =
                node.InnerText;
        }
        private void ReadTargetFramework(
    XmlDocument xml,
    BuildProject project)
        {
            XmlNode node =
                xml.SelectSingleNode(
                    "//TargetFrameworkVersion");

            if (node == null)
                return;

            project.TargetFramework =
                node.InnerText;
        }
        private void ReadReferences(
    XmlDocument xml,
    BuildProject project)
        {
            XmlNodeList nodes =
                xml.SelectNodes(
                    "//Reference");

            foreach (XmlNode item
                in nodes)
            {
                XmlAttribute attr =
                    item.Attributes["Include"];

                if (attr == null)
                    continue;

                project.References.Add(
                    attr.Value);
            }
        }
        private void AnalyzeSmartProject(
    BuildProject project)
        {
            project.OutputType =
                "Smart";

            project.TargetFramework =
                "Unknown";
        }
    }
}