
namespace Bankapp.Domain;

public class BankAccount : IBankAccount
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }

    public AccountType AccountType { get; private set; }

    public string Currency { get; private set; }

    public decimal Balance { get; private set; }

    public DateTime LastUppdated { get; private set; }


    public BankAccount(string name, AccountType accountType, string currency, decimal initialBalance)
    {
        Name = name;
        AccountType = accountType;
        Currency = currency;
        Balance = initialBalance;
        LastUppdated = DateTime.Now;
    }
    public void Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public void Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }
}