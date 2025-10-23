

using System.Text.Json.Serialization;

namespace Bankapp.Domain
{
    public class BankAccount : IBankAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }

        public AccountType AccountType { get; private set; }

        public CurrencyType Currency { get; set; }

        public decimal Balance { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public readonly List<Transaction> _transaction = new List<Transaction>();
        

        public BankAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance)
        {
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = initialBalance;
            LastUpdated = DateTime.Now;
        }

        [JsonConstructor]
        public BankAccount(Guid id, string name, AccountType accountType, CurrencyType currency, decimal balance, DateTime lastUpdated)
        {
            Id = id;
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = balance;
            LastUpdated = lastUpdated;
        }

        public void TransferTo(BankAccount toAccount, decimal amount)
        {
            // från vilket konto
            Balance -= amount;
            LastUpdated = DateTime.Now;
            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.TransferOut,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,
            });

            // till vilket konto
            toAccount.Balance += amount;
            toAccount.LastUpdated = DateTime.Now;
            toAccount._transaction.Add(new Transaction
            {
                transactionType = TransactionType.TransferIn,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,

            });
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Beloppet måste vara större än 0!");
            Balance += amount;
            LastUpdated = DateTime.UtcNow;
            
            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.Deposit,
                Amount = amount,
                BalanceAfterTransaction = Balance
            });
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Beloppet måste vara större än 0!");

            if (Balance < amount) throw new InvalidOperationException("Inte tillräckligt saldo!");
            Balance -= amount;
            LastUpdated = DateTime.UtcNow;

            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.Withdrawal,
                Amount = amount,
                BalanceAfterTransaction = Balance
            });
        }
    }
}
