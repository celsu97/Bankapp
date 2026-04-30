using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bankapp.Domain
{
    /// <summary>
    /// Represents a single transaction made on a bank account
    /// </summary>
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public Guid? FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }
    }
}