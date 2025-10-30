using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;
using Bankapp.Interfaces;
using System.Threading.Tasks;

namespace Bankapp.Services;

public class StorageService : IStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() },
        IncludeFields = true,
        PropertyNameCaseInsensitive = true
    };

    public StorageService(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    public async Task<T?> GetItemAsync<T>(string key)
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
        if (string.IsNullOrEmpty(json))
            return default;
        return JsonSerializer.Deserialize<T>(json, _jsonOptions);
    }

    public async Task SetItemAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value, _jsonOptions);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}