using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IProductRepository
    {
        Product Edit(Product contract);
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetRemoteAsync();
        Task<IEnumerable<Product>> GetAsync(int page, int size, string term);
        Task<int> GetCountAsync(string term);
    }
}
