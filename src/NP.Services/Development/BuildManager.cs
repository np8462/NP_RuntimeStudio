using System.Collections.Generic;
using NP.Services.Development;

namespace NP.Services.Development
{
    public class BuildManager
    {
        public BuildAnalyzer Analyzer
        {
            get;
            private set;
        }

        public BuildExplorer Explorer
        {
            get;
            private set;
        }

        public BuildCompiler Compiler
        {
            get;
            private set;
        }

        public BuildLogger Logger
        {
            get;
            private set;
        }

        public BuildManager()
        {
            Explorer =
                new BuildExplorer();

            Compiler =
                new BuildCompiler();

            Logger =
                new BuildLogger();

            Analyzer =
    new BuildAnalyzer();
        }

        public BuildResult BuildFile()
        {
            string file =

                Explorer.SelectFile();

            if (file == null)
                return null;

            Logger.Add(
                "Selected : "
                + file);

            //BuildOptions options =
            //    new BuildOptions();

            //options.GenerateLibrary =
            //    true;

            BuildOptions options =
    new BuildOptions();

            options.OutputKind =
                Analyzer.Analyze(file);

            return Compiler.CompileFile(
                file,
                options);
        }

        public BuildResult BuildFolder()
        {
            string folder =
                Explorer.SelectFolder();

            if (folder == null)
                return null;

            Logger.Add(
                "Folder : " +
                folder);

            BuildProject buildProject =
                BuildProject.Load(folder);

            buildProject =
                Analyzer.Analyze(buildProject);

            return
                Compiler.CompileProject(buildProject);
        }

        //public IList<BuildResult> BuildLoadedProject(
        //    BuildProject project)
        //{
        //    List<BuildResult> results =
        //        new List<BuildResult>();

        //    if (project == null)
        //        return results;

        //    foreach (string file
        //        in project.SourceFiles)
        //    {
        //        BuildOptions options =
        //            new BuildOptions();

        //        options.OutputKind =
        //            Analyzer.Analyze(file);

        //        BuildResult result =
        //            Compiler.CompileFile(
        //                file,
        //                options);

        //        results.Add(result);
        //    }

        //    return results;
        //}

        //public BuildResult BuildProject()
        //{
        //    string folder =
        //        Explorer.SelectFolder();

        //    if (folder == null)
        //        return null;

        //    BuildProject project =
        //        BuildProject.Load(folder);

        //    project =
        //        Analyzer.Analyze(project);

        //    return Compiler.CompileProject(project);
        //}
    }
}