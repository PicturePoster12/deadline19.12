using System;
using System.Collections;
namespace Tumakov
{
	public class Bank
	{
		private static int nextAccountNumber = 100000;
		private int accountNumber;
		private decimal balance;
		private BankAccountType accountType;
		private Queue<BankTransaction> queue = new Queue<BankTransaction>();
        private bool disposed = false;
        public Bank()
        {
            accountNumber = AccNumbGenerator();
            balance = 0;
            accountType = BankAccountType.current;
        }
		public Bank(decimal initialBalance)
		{
            accountNumber = AccNumbGenerator();
            balance = initialBalance;
            accountType = BankAccountType.current;
		}
        public Bank(BankAccountType type)
		{
            accountNumber = AccNumbGenerator();
            balance = 0;
            accountType = type;
        }
        public Bank(decimal initialBalance, BankAccountType type)
        {
            accountNumber = AccNumbGenerator();
            balance = initialBalance;
            accountType = type;
        }
        private static int AccNumbGenerator()
		{
			return nextAccountNumber++;
		}
		public int AccountNumber => accountNumber;
        public decimal Balance
        {
			get { return balance; }
            set
            {
				if (value < 0)
				{
					ArgumentOutOfRangeException.ThrowIfNegative(value);
				}
                balance = value;
            }
        }
        public BankAccountType AccountType
        {
			get { return accountType; }
			set { accountType = value; }
        }
        public Queue<BankTransaction> BankTransactions
		{
			get { return queue; }
		}
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    string filePath = "transactions.txt";
                    if (File.Exists(filePath))
                    {
                        throw new IOException();
                    }
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (var transaction in queue)
                            {
                                writer.WriteLine($"Amount: {transaction.Amount}, DateTime: {transaction.Datetime}");
                            }
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine($"Ошибка записи в файл");
                    }
                }
                disposed = true;
            }
        }
        public decimal Withdraw(decimal withdraw)
		{
			if (withdraw >= 0)
			{
				if (balance >= withdraw)
				{
					balance -= withdraw;
                    var transaction = new BankTransaction(withdraw);
                    queue.Enqueue(transaction);
                }
				return balance;
			}
			else
			{
				throw new FormatException();
			}
		}
		public decimal Deposit(decimal deposit)
		{
			if (deposit >= 0)
			{
				balance += deposit;
                var transaction = new BankTransaction(deposit);
                queue.Enqueue(transaction);
                return balance;
			}
			else
			{
				throw new FormatException();
			}
		}
        public void Print()
		{
			Console.WriteLine($"Номер счета: {accountNumber}");
			Console.WriteLine($"Баланс: {balance:F2}");
			Console.WriteLine($"Тип счета: {accountType}");
		}
    }
}