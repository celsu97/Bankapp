<<<<<<< Updated upstream
=======
using Bankapp.Domain;
>>>>>>> Stashed changes

namespace Bankapp.Interfaces
{
    public interface IAccountService
    {
<<<<<<< Updated upstream
        Task<IBankAccount> CreateAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance);
        Task<List<IBankAccount>> GetAccountsAsync();

        Task DeleteAccount(Guid Id);
        Task UpdateAccount(IBankAccount updatedAccount);

        Task Transfer(Guid fromAccountId, Guid toAccountId, decimal amount);

=======
        Task<BankAccount> CreateAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance);
        List<BankAccount> GetAccounts();
        Task DeleteAccount(Guid Id);
        Task UpdateAccount(BankAccount updatedAccount);
        Task Transfer(Guid fromAccountId, Guid toAccountId, decimal amount);
        Task EnsureLoadedAsync();
        Task DepositAsync(Guid accountId, decimal amount);
        Task WithdrawAsync(Guid accountId, decimal amount);
>>>>>>> Stashed changes
    }
}