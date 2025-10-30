<<<<<<< Updated upstream
=======
using Bankapp.Domain;
using Bankapp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> Stashed changes

namespace Bankapp.Services
{
    public class AccountService : IAccountService
    {
<<<<<<< Updated upstream
        private const string StorageKey = "BlazorApp4.accounts";
        private readonly List<IBankAccount> _accounts = new();
        private readonly IStorageService _storageService;

        private bool isLoaded;

        public AccountService(IStorageService storageService) => _storageService = storageService;

        private async Task IsInitialized()
        {
            if (isLoaded)
            {
                return;
            }
            var fromStorage = await _storageService.GetItemAsync<List<BankAccount>>(StorageKey);
            _accounts.Clear();
            if (fromStorage is { Count: > 0 })
                _accounts.AddRange(fromStorage);
            isLoaded = true;
        }

        private Task SaveAsync() => _storageService.SetItemAsync(StorageKey, _accounts);
        

        public async Task <IBankAccount> CreateAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance)
        {
            await IsInitialized();
            var account = new BankAccount(name, accountType, currency, initialBalance);
            _accounts.Add(account);
            await SaveAsync();
            return account;
        }

        public async Task<List<IBankAccount>> GetAccountsAsync()
        {
            await IsInitialized();
            return _accounts.Cast<IBankAccount>().ToList();
        }

        public async Task DeleteAccount(Guid Id)
        {
            await IsInitialized();

            var accountToRemove = _accounts.FirstOrDefault(account => account.Id == Id);

            if (accountToRemove is not null)
            {
                _accounts.Remove(accountToRemove);
                await SaveAsync();
                
            }
        }

        public async Task UpdateAccount(IBankAccount updatedAccount)
        {
            await IsInitialized();

            var existing = _accounts.FirstOrDefault(account => account.Id == updatedAccount.Id);
            if (existing != null)
           {
                _accounts.Remove(existing);
                _accounts.Add(updatedAccount);
                await SaveAsync();
            }
        }

        public async Task Transfer(Guid fromAccountId,  Guid toAccountId, decimal amount)
        {
            await IsInitialized();
            var fromAccount = _accounts.OfType<BankAccount>().FirstOrDefault(x => x.Id == fromAccountId)
                ?? throw new KeyNotFoundException($"Account with ID {fromAccountId} not found.");

            var toAccount = _accounts.OfType<BankAccount>().FirstOrDefault(x => x.Id == toAccountId)
                ?? throw new KeyNotFoundException($"Account with ID {fromAccountId} not found.");

            fromAccount.TransferTo(toAccount, amount);

            await SaveAsync();
        }

    }
}
=======
        private const string StorageKey = "bankAccounts";
        private readonly IStorageService _storageService;
        private readonly List<BankAccount> _accounts = new();
        private bool isLoaded = false;

        public AccountService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        // Load accounts
        public async Task EnsureLoadedAsync()
        {
            if (isLoaded) return;

            var fromStorage = await _storageService.GetItemAsync<List<BankAccount>>(StorageKey);
            if (fromStorage != null && fromStorage.Count > 0)
                _accounts.AddRange(fromStorage);

            isLoaded = true;
        }

        // Create
        public async Task<BankAccount> CreateAccount(string name, AccountType accountType, CurrencyType currency, decimal initialBalance)
        {
            var account = new BankAccount(name, accountType, currency, initialBalance);
            _accounts.Add(account);
            await SaveChangesAsync();
            return account;
        }

        // Get
        public List<BankAccount> GetAccounts() => _accounts.ToList();

        // Delete
        public async Task DeleteAccount(Guid id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                _accounts.Remove(account);
                await SaveChangesAsync();
            }
        }

        // Update
        public async Task UpdateAccount(BankAccount updatedAccount)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == updatedAccount.Id);
            if (existing != null)
            {
                _accounts.Remove(existing);
                _accounts.Add(updatedAccount);
                await SaveChangesAsync();
            }
        }

        // Transfer
        public async Task Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var from = _accounts.FirstOrDefault(a => a.Id == fromAccountId);
            var to = _accounts.FirstOrDefault(a => a.Id == toAccountId);

            if (from == null || to == null)
                throw new InvalidOperationException("Ogiltigt konto för överföring.");

            from.TransferTo(to, amount);
            await SaveChangesAsync();
        }

        // Deposit
        public async Task DepositAsync(Guid accountId, decimal amount)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null) throw new InvalidOperationException("Kontot hittades inte.");

            account.Deposit(amount);
            await SaveChangesAsync();
        }

        // Withdraw
        public async Task WithdrawAsync(Guid accountId, decimal amount)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null) throw new InvalidOperationException("Kontot hittades inte.");

            account.Withdraw(amount);
            await SaveChangesAsync();
        }

        // Save
        private async Task SaveChangesAsync()
        {
            await _storageService.SetItemAsync(StorageKey, _accounts);
        }
    }
}
>>>>>>> Stashed changes
