using System;
namespace Tumakov
{
    class Laba
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
        static void Task1()
        {
            Console.WriteLine("9.1");
            var bank1 = new Bank();
            var bank2 = new Bank(500);
            var bank3 = new Bank(BankAccountType.savings);
            var bank4 = new Bank(1500, BankAccountType.savings);
            Console.WriteLine(bank1.AccountNumber);
            Console.WriteLine(bank2.Balance);
            Console.WriteLine(bank3.AccountType);
            Console.WriteLine(bank4.Balance);
        }
        static void Task2()
        {
            Console.WriteLine("9.2");
            var bank1 = new Bank(2000);
            bank1.Withdraw(1000);
            bank1.Deposit(1000001);
            Console.WriteLine(bank1.BankTransactions);
        }
        static void Task3()
        {
            try
            {
                Console.WriteLine("9.3");
                var bank1 = new Bank(2000);
                bank1.Withdraw(1000);
                bank1.Deposit(1000001);
                bank1.Dispose();
            }
            catch (IOException)
            {
                Console.WriteLine("Файл уже существует");
            }
        }
        static void Task4()
        {
            Console.WriteLine("dz9.1");
            var mySong = new Song();
            var Song1 = new Song("Euphoria", "Miyagi & Эндшпиль, Mav-d");
            var Song2 = new Song("Skittles", "Miyagi & Эндшпиль, Mav-d", Song1);
            Console.WriteLine(mySong.Name);
            Console.WriteLine(Song1.Prev);
            Console.WriteLine(Song2.Prev);
        }
    }
}