using System;
namespace DZ
{
    public class Report
    {
        public string Text { get; set; }
        public DateTime CompletionDate { get; set; }
        public Person Executor { get; set; }
        public Report(string text, DateTime completionDate, Person executor)
        {
            Text = text;
            CompletionDate = completionDate;
            Executor = executor;
        }
    }
}
