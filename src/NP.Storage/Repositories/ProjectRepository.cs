using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NP.Core.Models;
using NP.Storage.Runtime;

namespace NP.Storage.Repositories
{
    public class ProjectRepository
    {
        public void CreateProject(
            string projectName)
        {
            string folder =
                StoragePaths.GetProjectFolder(
                    projectName);

            Directory.CreateDirectory(folder);

            Directory.CreateDirectory(
                Path.Combine(folder, "Chats"));

            ProjectInfo project =
                new ProjectInfo();

            project.Id =
                Guid.NewGuid().ToString();

            project.Name =
                projectName;

            project.CreatedAt =
                DateTime.Now;

            string json =
                JsonConvert.SerializeObject(
                    project,
                    Formatting.Indented);

            File.WriteAllText(
                Path.Combine(
                    folder,
                    "Project.json"),
                json);
        }

        public List<string> GetProjects()
        {
            List<string> result =
                new List<string>();

            if (!Directory.Exists(
                StoragePaths.ProjectsFolder))
            {
                return result;
            }

            string[] dirs =
                Directory.GetDirectories(
                    StoragePaths.ProjectsFolder);

            foreach (string dir in dirs)
            {
                result.Add(
                    Path.GetFileName(dir));
            }

            return result;
        }
    }
}