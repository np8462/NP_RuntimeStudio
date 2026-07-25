using System;
using System.Diagnostics;
using System.IO;

namespace NP.Services.Development
{
    public class BuildCompiler
    {
        public BuildResult CompileFile(
            string file,
            BuildOptions options)
        {
            BuildResult result =
                new BuildResult();

            result.SourceFile = file;

            try
            {
                if (!File.Exists(file))
                {
                    result.Success = false;
                    result.ErrorText = "File not found";
                    return result;
                }

                string outputDir =
                    options.OutputPath ??
                    Path.GetDirectoryName(file);

                //string outputFile =
                //    Path.Combine(
                //        outputDir,
                //        Path.GetFileNameWithoutExtension(file)
                //        + ".dll");

                string extension;

                switch (options.OutputKind)
                {
                    case BuildOutputKind.Library:

                        extension =
                            ".dll";

                        break;

                    default:

                        extension =
                            ".exe";

                        break;
                }

                string outputFile =
                    Path.Combine(
                        outputDir,
                        Path.GetFileNameWithoutExtension(file)
                        + extension);

                // مسیر csc.exe (net48)
                string cscPath =
                    Path.Combine(
                        System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(),
                        "csc.exe");

                ProcessStartInfo psi =
                    new ProcessStartInfo();

                psi.FileName = cscPath;

                //string arguments =

                //    " /target:library " +

                //    " /out:\"" +

                //    outputFile +

                //    "\" " +

                //    "\"" +

                //    file +

                //    "\"";

                string target;

                switch (options.OutputKind)
                {
                    case BuildOutputKind.Library:

                        target =
                            "library";

                        break;

                    case BuildOutputKind.ConsoleExe:

                        target =
                            "exe";

                        break;

                    default:

                        target =
                            "winexe";

                        break;
                }

                string arguments =

                    " /target:" +

                    target +

                    " /out:\"" +

                    outputFile +

                    "\" " +

                    "\"" +

                    file +

                    "\"";

                psi.Arguments =
                    arguments;

                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process process =
                    Process.Start(psi);

                string output =
                    process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    result.Success = false;
                    result.ErrorText = output;
                    return result;
                }

                result.Success = true;
                result.OutputFile = outputFile;

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorText = ex.Message;
                return result;
            }
        }

        public BuildResult CompileProject(
            BuildProject project)
        {
            if (project.HasProjectFile)
            {
                return CompileMSBuild(project);
            }

            return CompileSmart(project);
        }
        
        private BuildResult CompileMSBuild(
            BuildProject project)
        {
            BuildResult result =
                new BuildResult();

            try
            {
                string msbuild =
                    FindMSBuild();

                if (String.IsNullOrEmpty(msbuild))
                {
                    result.Success = false;
                    result.ErrorText =
                        "MSBuild not found.";

                    return result;
                }

                ProcessStartInfo psi =
                    new ProcessStartInfo();

                psi.FileName =
                    msbuild;

                psi.Arguments =

                    "\"" +

                    project.ProjectFile +

                    "\" /t:Build";

                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process process =
                    Process.Start(psi);

                string output =
                    process.StandardOutput.ReadToEnd();

                output +=
                    process.StandardError.ReadToEnd();

                process.WaitForExit();

                result.ExitCode = process.ExitCode;

                result.Success =
                    process.ExitCode == 0;

                result.OutputText =
                    output;

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.ErrorText =
                    ex.Message;

                return result;
            }
        }
        
        private string FindMSBuild()
        {
            string[] paths =
            {
                Environment.ExpandEnvironmentVariables(
                    @"%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"),

                Environment.ExpandEnvironmentVariables(
                    @"%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"),

                Environment.ExpandEnvironmentVariables(
                    @"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"),

                Environment.ExpandEnvironmentVariables(
                    @"%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe")
            };

            foreach (string file in paths)
            {
                if (File.Exists(file))
                    return file;
            }

            return null;
        }
        private string FindMSBuild(
    string targetFramework)
        {
            return FindMSBuild();
        }


        private BuildResult CompileSmart(
    BuildProject project)
        {
            BuildResult result =
                new BuildResult();

            foreach (string file
                in project.SourceFiles)
            {
                //
                // فعلاً فقط برای بررسی
                // بعداً CommandLine ساخته می‌شود.
                //
            }

            result.Success = false;

            result.ErrorText =
                "Smart Build هنوز پیاده سازی نشده است.";

            return result;
        }
    }

    public class MSBuildLocator
    {
        public string Find(
            BuildProject project)
        {
            return
                Environment.ExpandEnvironmentVariables(
                    @"%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe");
        }

    }
}