namespace Bankapp.Domain;

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer
}
public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public Guid FromAccountId { get; set; }
    public Guid? ToAccountId { get; set; } //Null om inte överföring
    public decimal BalanceAfterTransaction { get; set; }
}