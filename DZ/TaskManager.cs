using System;
using System.Collections.Generic;
namespace DZ
{
    public class TaskManager
    {
        public readonly List<Person> people = new List<Person>(); 
        public readonly List<Project> projects = new List<Project>();
        public TaskManager()
        {
            InitializePeople();
        }
        private void InitializePeople()
        {
            for (int i = 1; i <= 10; i++)
            {
                people.Add(new Person($"Person{i}"));
            }
        }
        public void CreateProject(Project project)
        {
            projects.Add(project);
        }
        public void AssignTasksToProject(string projectDescription, List<Task> tasks)
        {
            var project = GetProjectByDescription(projectDescription);
            project.AssignTasks(tasks);
        }
        public void ProjectExecutionStatus(string projectDescription)
        {
            var project = GetProjectByDescription(projectDescription);
            project.ExecutionStatus();
        }
        public void CloseProject(string projectDescription)
        {
            var project = GetProjectByDescription(projectDescription);
            project.ClosedStatus();
        }
        public void AssignExecutorToTask(string description, Person executor)
        {
            var task = GetTaskByDescription(description);
            task.AssignExecutor(executor);
        }
        public void StartWorking(string description)
        {
            var task = GetTaskByDescription(description);
            task.InProgressStatus();
        }
        public void DelegateTask(string description, Person newExecutor)
        {
            var task = GetTaskByDescription(description);
            task.DelegateTask(newExecutor);
        }
        public void RejectTask(string description)
        {
            var tasks = GetTaskByDescription(description);
            tasks.RejectTask();
        }
        public void CompleteTask(string description)
        {
            var tasks = GetTaskByDescription(description);
            tasks.CompleteTask();
        }
        public void SubmitReport(string description, Report report)
        {
            var tasks = GetTaskByDescription(description);
            tasks.Reports.Add(report);
        }
        public Project GetProjectByDescription(string description)
        {
            return projects.FirstOrDefault(p => p.Description == description);
        }
        private Task GetTaskByDescription(string description)
        {
            return projects.SelectMany(p => p.Tasks).FirstOrDefault(t => t.Description == description);
        }
    }
}
