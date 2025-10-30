<<<<<<< Updated upstream
namespace Bankapp.Interfaces
{
    public interface IStorageService
    {
        //spara
        Task SetItemAsync<T>(string key, T value);
        //hämta
        Task<T> GetItemAsync<T>(string key);
    }
=======
using System.Threading.Tasks;

namespace Bankapp.Interfaces;

public interface IStorageService
{
    Task SetItemAsync<T>(string key, T value);
    Task<T?> GetItemAsync<T>(string key);
    Task RemoveItemAsync(string key);
    
>>>>>>> Stashed changes
}