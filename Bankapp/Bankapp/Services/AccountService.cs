namespace Bankapp.Services;

public interface IAccountService
{
    public IBankAccount CreateAccount(string name, string currency, decimal initialBalance)
    {
        throw new NotImplementedException();
    }
    public List<IBankAccount> GetAccounts()
    {
        throw new NotImplementedException();
    }
}