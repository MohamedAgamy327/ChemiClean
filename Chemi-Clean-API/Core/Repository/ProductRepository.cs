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
        public async Task<Product> AddAsync(Product contract)
        {
            await _context.Products.AddAsync(contract);
            return contract;
        }
        public Product Edit(Product contract)
        {
            _context.Entry(contract).State = EntityState.Modified;
            return contract;
        }
        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.OrderByDescending(o => o.Id).ToListAsync();
        }
        public void Remove(Product contract)
        {
            _context.Remove(contract);
        }
        public async Task<bool> IsExist(int id)
        {
            return await _context.Products.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(string name)
        {
            return await _context.Products.AnyAsync(s => s.Name.ToLower() == name.ToLower()).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(int id, string name)
        {
            return await _context.Products.AnyAsync(s => s.Id != id && s.Name.ToLower() == name.ToLower()).ConfigureAwait(true);
        }
    }
}
