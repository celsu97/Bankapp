<<<<<<< Updated upstream


=======
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes
using System.Text.Json.Serialization;
using Bankapp.Interfaces;

namespace Bankapp.Domain
{
    public class BankAccount : IBankAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
<<<<<<< Updated upstream

        public string Name { get; private set; }

        public AccountType AccountType { get; private set; }

        public CurrencyType Currency { get; set; }

        public decimal Balance { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public readonly List<Transaction> _transaction = new List<Transaction>();
        

=======
        public string Name { get; private set; }
        public AccountType AccountType { get; private set; }
        public CurrencyType Currency { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime LastUpdated { get; private set; }

        // Internal storage for transactions
        [JsonInclude]
        public List<Transaction> TransactionsInternal { get; private set; } = new();

        // Expose as IReadOnlyList for the interface
        [JsonIgnore]
        public IReadOnlyList<Transaction> Transactions => TransactionsInternal.AsReadOnly();

        // Constructor for creating new accounts
>>>>>>> Stashed changes
        public BankAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance)
        {
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = initialBalance;
<<<<<<< Updated upstream
            LastUpdated = DateTime.Now;
        }

        [JsonConstructor]
        public BankAccount(Guid id, string name, AccountType accountType, CurrencyType currency, decimal balance, DateTime lastUpdated)
=======
            LastUpdated = DateTime.UtcNow;
        }

        // JsonConstructor for deserialization
        [JsonConstructor]
        public BankAccount(
            Guid id,
            string name,
            AccountType accountType,
            CurrencyType currency,
            decimal balance,
            DateTime lastUpdated,
            List<Transaction>? transactionsInternal = null)
>>>>>>> Stashed changes
        {
            Id = id;
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = balance;
            LastUpdated = lastUpdated;
<<<<<<< Updated upstream
        }

        public void TransferTo(BankAccount toAccount, decimal amount)
        {
            // från vilket konto
            Balance -= amount;
            LastUpdated = DateTime.Now;
            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.TransferOut,
=======
            TransactionsInternal = transactionsInternal ?? new List<Transaction>();
        }

        // IBankAccount.TransferTo implementation
        public void TransferTo(IBankAccount toAccountInterface, decimal amount)
        {
            if (toAccountInterface is not BankAccount toAccount)
                throw new ArgumentException("toAccount must be a BankAccount", nameof(toAccountInterface));

            TransferTo(toAccount, amount);
        }

        // Concrete internal transfer logic
        private void TransferTo(BankAccount toAccount, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive", nameof(amount));
            if (Balance < amount) throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
            LastUpdated = DateTime.UtcNow;
            TransactionsInternal.Add(new Transaction
            {
                TransactionType = TransactionType.TransferOut,
>>>>>>> Stashed changes
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,
<<<<<<< Updated upstream
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

=======
                TimeStamp = DateTime.UtcNow
            });

            toAccount.Balance += amount;
            toAccount.LastUpdated = DateTime.UtcNow;
            toAccount.TransactionsInternal.Add(new Transaction
            {
                TransactionType = TransactionType.TransferIn,
                Amount = amount,
                BalanceAfterTransaction = toAccount.Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,
                TimeStamp = DateTime.UtcNow
>>>>>>> Stashed changes
            });
        }

        public void Deposit(decimal amount)
        {
<<<<<<< Updated upstream
            if (amount < 0) throw new ArgumentException("Beloppet måste vara större än 0!");
            Balance += amount;
            LastUpdated = DateTime.UtcNow;
            
            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.Deposit,
                Amount = amount,
                BalanceAfterTransaction = Balance
=======
            if (amount <= 0) throw new ArgumentException("Amount must be greater than 0.");
            Balance += amount;
            LastUpdated = DateTime.UtcNow;
            TransactionsInternal.Add(new Transaction
            {
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                TimeStamp = DateTime.UtcNow
>>>>>>> Stashed changes
            });
        }

        public void Withdraw(decimal amount)
        {
<<<<<<< Updated upstream
            if (amount < 0) throw new ArgumentException("Beloppet måste vara större än 0!");

            if (Balance < amount) throw new InvalidOperationException("Inte tillräckligt saldo!");
            Balance -= amount;
            LastUpdated = DateTime.UtcNow;

            _transaction.Add(new Transaction
            {
                transactionType = TransactionType.Withdrawal,
                Amount = amount,
                BalanceAfterTransaction = Balance
=======
            if (amount <= 0) throw new ValidationException("Amount must be greater than 0.");
            if (Balance < amount) throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
            LastUpdated = DateTime.UtcNow;
            TransactionsInternal.Add(new Transaction
            {
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                TimeStamp = DateTime.UtcNow
>>>>>>> Stashed changes
            });
        }
    }
}
