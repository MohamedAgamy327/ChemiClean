using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product contract);
        Product Edit(Product contract);
        void Remove(Product contract);
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> GetAsync();
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsExist(int id, string name);
    }
}
