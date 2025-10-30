using System;
using System.Collections.Generic;

namespace Bankapp.Interfaces
{
<<<<<<< Updated upstream
    Guid Id { get; }
    string Name { get; }
    AccountType AccountType { get; }
    CurrencyType Currency { get; set; }
    decimal Balance { get; }
    DateTime LastUpdated { get; }

    void Withdraw(decimal amount);
    void Deposit(decimal amount);

    void TransferTo(BankAccount toAccount, decimal amount);
=======
    public interface IBankAccount
    {
        Guid Id { get; }
        string Name { get; }
        decimal Balance { get; }
        IReadOnlyList<Transaction> Transactions { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void TransferTo(IBankAccount toAccount, decimal amount);
    }
>>>>>>> Stashed changes
}