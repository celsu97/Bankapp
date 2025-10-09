namespace Bankapp.Interfaces;

/// <summary>
/// Interface containing the BankAccount methods
/// </summary>
public interface IBankAccount
{
    Guid Id { get; }
    string Name { get; }
    public AccountType AccountType { get; }
    string Currency { get; }
    decimal Balance { get; }
    DateTime LastUppdated { get; }

    void Withdraw(decimal amount);
    void Deposit(decimal amount);

}