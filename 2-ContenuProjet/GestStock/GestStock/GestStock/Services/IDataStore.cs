using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestStock.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetBorrowedItemsAsync(bool forceRefresh = false);
        Task<bool> GetDbBorrowedItems();
        Task<bool> GetDbItems();

    }
}
