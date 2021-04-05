using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Mr.DPD", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeDeposit(500, DateTime.Now, "1");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(400, DateTime.Now, "2");
            Console.WriteLine(account.Balance);
        }
    }
}
