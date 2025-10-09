namespace Bankapp.Interfaces;
public interface IAccountService
{
    IBankAccount CreateAccount(string name, AccountType accountType, string currency, decimal initialBalance);
    List<IBankAccount> GetAccounts();
}