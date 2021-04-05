using System;
using System.Collections.Generic;


namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        //hàm xử lý phần tiền gửi
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {   
            //xét điều kiện, nếu số tiền <=0 thì huỷ giao dịch, đưa ra thông báo
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            //nếu tiền gửi >0, tạo 1 giao dịch gửi tiền, số tiền gửi (amount) sẽ được thêm vào số dư (balance)
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        //hàm xử lý với tiền rút
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            //tương tự với hàm xử lý tiền gửi, phần giá trị tiền rút phải lớn hơn 0
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            //ngoài ra phần tiền rút phải < số dư (Balance)
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            //tạo 1 giao dịch rút tiền, số dư (Balance) sẽ bị trừ tương ứng với số tiền rút (amount)
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
    }
}
