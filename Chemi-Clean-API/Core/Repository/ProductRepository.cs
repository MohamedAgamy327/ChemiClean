using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Product Edit(Product contract)
        {
            _context.Entry(contract).State = EntityState.Modified;
            return contract;
        }
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetRemoteAsync()
        {
            return await _context.Products.Where(w => string.IsNullOrEmpty(w.LocalUrl)).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAsync(int page, int size, string term)
        {
            return await _context.Products
           .Where(w => string.IsNullOrEmpty(term)
           || w.ProductName.Contains(term)
           || w.SupplierName.Contains(term))
           .OrderByDescending(d => d.Id)
           .Skip((page - 1) * size).ToListAsync();
        }
        public async Task<int> GetCountAsync(string term)
        {
            return await _context.Products
            .Where(w => string.IsNullOrEmpty(term)
            || w.ProductName.Contains(term)
            || w.SupplierName.Contains(term)).CountAsync();
        }
    }
}
