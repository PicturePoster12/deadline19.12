using System;
namespace DZ
{
    public class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Initiator { get; set; }
        public Person TeamLeader { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public ProjectStatus Status { get; set; }
        public Project(string description, DateTime deadline, Person initiator, Person teamLeader)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            TeamLeader = teamLeader;
            Status = ProjectStatus.Project;
        }
        public void AssignTasks(List<Task> tasks)
        {
            Tasks.AddRange(tasks);
        }
        public void ExecutionStatus()
        {
            Status = ProjectStatus.Execution;
        }
        public void ClosedStatus()
        {
            Status = ProjectStatus.Closed;
        }
    }
}
