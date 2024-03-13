using appProduct.Data;
using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace appProduct.Repository.Entities
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Customer model)
        {
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            return "Customer Created Succesfully";
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _context.Customers.FindAsync(id);
            if (model == null)
            {
                return false;
            }
            _context.Customers.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> Read()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> Search(int id)
        {
            var model = await _context.Customers.FindAsync(id);
            return model;
        }

        public async Task<bool> Update(int id, Customer model)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _context.Entry(customer).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
