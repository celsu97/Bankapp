
namespace Bankapp.Domain;

public class BankAccount : IBankAccount
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }

    public AccountType AccountType { get; private set; }

    public string Currency { get; private set; }

    public decimal Balance { get; private set; }

    public DateTime LastUppdated { get; private set; }
    public List<Transaction> Transactions { get; private set; } = new();


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
        if (amount <= 0) throw new ArgumentException("Beloppet måste vara större än 0.");
        Balance += amount;
        LastUppdated = DateTime.Now;

        Transactions.Add(new Transaction
        {
            Type = TransactionType.Deposit,
            Amount = amount,
            BalanceAfterTransaction = Balance
        });
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Beloppet måste vara större än 0.");
        if (Balance < amount) throw new InvalidOperationException("Otillräckligt saldo");
        Balance -= amount;
        LastUppdated = DateTime.Now;

        Transactions.Add(new Transaction
        {
            Type = TransactionType.Withdrawal,
            Amount = amount,
            BalanceAfterTransaction = Balance
        });
        throw new NotImplementedException();
    }
}