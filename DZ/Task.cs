using System;
namespace DZ
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public Person Initiator { get; set; }
        public Person Executor { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
        public Task(string description, DateTime deadline, Person initiator)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Assigned;
        }
        public void AssignExecutor(Person executor)
        {
            Executor = executor;
        }
        public void InProgressStatus()
        {
            Status = TaskStatus.InProgress;
        }
        public void DelegateTask(Person newExecutor)
        {
            Executor = newExecutor;
        }
        public void RejectTask()
        {
            Executor = null;
        }
        public void CompleteTask()
        {
            Status = TaskStatus.Completed;
        }
    }
}
