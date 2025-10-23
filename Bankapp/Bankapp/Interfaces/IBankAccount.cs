namespace Bankapp.Interfaces;

/// <summary>
/// Interface containing the BankAccount methods
/// </summary>
public interface IBankAccount
{
    Guid Id { get; }
    string Name { get; }
    AccountType AccountType { get; }
    CurrencyType Currency { get; set; }
    decimal Balance { get; }
    DateTime LastUpdated { get; }

    void Withdraw(decimal amount);
    void Deposit(decimal amount);

    void TransferTo(BankAccount toAccount, decimal amount);
}