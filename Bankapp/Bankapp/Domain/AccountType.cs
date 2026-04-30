namespace Bankapp.Domain
{
    /// <summary>
    /// Types of transactions
    /// </summary>
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        TransferIn,
        TransferOut
    }

    /// <summary>
    /// Types of currency
    /// </summary>
    public enum Currency
    {
        SEK
    }

    /// <summary>
    /// Types of bank accounts
    /// </summary>
    public enum AccountType
    {
        Savings,
        Deposit
    }
}