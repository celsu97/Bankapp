
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Bankapp.Domain;

namespace Bankapp.Domain 
{
    /// <summary>
    /// Bank account Domain, handles transactions and saves properties tied to the account.
    /// </summary>
    public class BankAccount : IBankAccount
    {
        // Properties
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public AccountType AccountType { get; private set; }
        public Currency Currency { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime LastUpdated { get; private set; }

        // List of all transactions for this account
        public readonly List<Transaction> _transaction = new();
        public List<Transaction> Transactions => _transaction;

        /// <summary>
        /// Creates a new bank account with the specified information
        /// </summary>
        public BankAccount(string name, AccountType accountType, Currency currency, decimal initialBalance)
        {
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = initialBalance;
            LastUpdated = DateTime.UtcNow;
        }

        /// <summary>
        /// JSON constructor used for deserialization of account data.
        /// </summary>
        [JsonConstructor]
        public BankAccount(Guid id, string name, AccountType accountType, Currency currency, decimal balance, DateTime lastUpdated, List<Transaction>? transactions = null)
        {
            Id = id;
            Name = name;
            AccountType = accountType;
            Currency = currency;
            Balance = balance;
            LastUpdated = lastUpdated;

            if (transactions != null)
            {
                _transaction = transactions;
            }
        }

        /// <summary>
        /// Transfers a specific amount from one account to another
        /// </summary>
        /// <param name="toAccount">Which account to transfer to</param>
        /// <param name="amount">The amount to transfer</param>
        public void TransferTo(BankAccount toAccount, decimal amount)
        {
            // Withdraw from this account
            Balance -= amount;
            LastUpdated = DateTime.UtcNow;
            _transaction.Add(new Transaction
            {
                TransactionType = TransactionType.TransferOut,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,
                TimeStamp = DateTime.UtcNow
            });

            // Deposit to this account
            toAccount.Balance += amount;
            toAccount.LastUpdated = DateTime.UtcNow;
            toAccount._transaction.Add(new Transaction
            {
                TransactionType = TransactionType.TransferIn,
                Amount = amount,
                BalanceAfterTransaction = toAccount.Balance,
                FromAccountId = Id,
                ToAccountId = toAccount.Id,
                TimeStamp = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Deposits a specific amount into the account
        /// </summary>
        /// <param name="amount">The amount to deposit</param>
        /// <exception cref="ArgumentException">Thrown if the amount is less than zero</exception>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("The amount must be greater than 0!");
            }

            Balance += amount;
            LastUpdated = DateTime.UtcNow;
            
            _transaction.Add(new Transaction
            {
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id
            });
        }

        /// <summary>
        /// Withdraws a specific amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentException">Thrown if the amount is less than zero.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the balance is insufficient.</exception>
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ValidationException("The amount must be greater than 0!");
            }

            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }

            Balance -= amount;
            LastUpdated = DateTime.UtcNow;

            _transaction.Add(new Transaction
            {
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                BalanceAfterTransaction = Balance,
                FromAccountId = Id
            });
        }
    }
}