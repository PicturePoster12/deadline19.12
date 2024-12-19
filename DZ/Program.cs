using System;
namespace DZ
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
            Person initiator = manager.people[0];
            Person teamLead = manager.people[1];
            Person executor1 = manager.people[2];
            Person executor2 = manager.people[3];
            Project project = new Project("Разработка нового приложения", DateTime.Today.AddMonths(3), initiator, teamLead);
            manager.CreateProject(project);
            List<Task> tasks = new List<Task>
            {
                new Task("Анализ требований", DateTime.Today.AddDays(7), initiator),
                new Task("Разработка дизайна", DateTime.Today.AddDays(14), initiator),
                new Task("Кодирование", DateTime.Today.AddDays(21), initiator),
                new Task("Тестирование", DateTime.Today.AddDays(28), initiator)
            };
            manager.AssignTasksToProject("Разработка нового приложения", tasks);
            manager.ProjectExecutionStatus("Разработка нового приложения");
            manager.AssignExecutorToTask(tasks[0].Description, executor1);
            manager.AssignExecutorToTask(tasks[1].Description, executor2);
            manager.StartWorking(tasks[0].Description);
            manager.CompleteTask(tasks[0].Description);
            var projectStatus = manager.GetProjectByDescription("Разработка нового приложения").Status;
            Console.WriteLine($"Статус проекта: {projectStatus}");
        }
    }
}