using CRUDApp.Core;
using CRUDApp.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CRUDApp.Infra.Implementation
{
    public class ProductRepository : IProductRepository
    {

        private readonly MyAppDbContext _context;

        public ProductRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Getall()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

       public async Task add(Product model)
        {
            await _context.Products.AddAsync(model);
            await Save();
        }
        public async Task update(Product model)
        {
            var product = await _context.Products.FindAsync(model.Id);
            if(product != null)
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;    
                product.Qty = model.Qty;
                _context.Update(product);
                await Save();
            }
        }

        public async Task delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await Save();   
            }
        }   
        private async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
