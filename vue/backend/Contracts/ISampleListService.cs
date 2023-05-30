using System.Collections.Generic;
using System.Threading.Tasks;
using Vue.WebApi.Models;

namespace Vue.WebApi.Contracts
{
    public interface ISampleListService
    {
        Task<ListItem> AddItemAsync(ListItem item);
        Task<long> DeleteItemAsync(string id);
        Task<IEnumerable<ListItem>> GetItemsAsync();
    }
}