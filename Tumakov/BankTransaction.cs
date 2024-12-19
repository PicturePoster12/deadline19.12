using System;
namespace Tumakov
{
    public class BankTransaction
    {
        private readonly DateTime dateTime;
        private readonly decimal amount;
        public BankTransaction(decimal amount)
        {
            this.amount = amount;
            this.dateTime = DateTime.Now;
        }
        public decimal Amount
        {
            get { return amount; }
        }
        public DateTime Datetime
        {
            get { return dateTime; }
        }
    }
}
