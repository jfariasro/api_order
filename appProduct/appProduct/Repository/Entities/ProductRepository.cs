using appProduct.Data;
using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace appProduct.Repository.Entities
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return "Product Created Succesfully";
        }

        public async Task<bool> Delete(int idproduct)
        {
            var product = await _context.Products.FindAsync(idproduct);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> Read()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Search(int idproduct)
        {
            var product = await _context.Products.FindAsync(idproduct);
            return product;
        }

        public async Task<bool> Update(int idproduct, Product product)
        {
            var model = await _context.Products.FindAsync(idproduct);

            if (model == null)
            {
                return false;
            }

            _context.Entry(model).CurrentValues.SetValues(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
