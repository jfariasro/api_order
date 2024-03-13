using appProduct.Data;
using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace appProduct.Repository.Entities
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> Create(Order model)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(model.customer.idcustomer);

                if(customer == null)
                {
                    return null;
                }

                model.customer = customer;

                await _context.Orders.AddAsync(model);
                await _context.SaveChangesAsync();

                return "Order created successfully";
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return false;
                }

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<IEnumerable<Order>> Read()
        {
            try
            {
                var orders = await _context.Orders.Include(o => o.customer).ToListAsync();

                return orders;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<Order> Search(int id)
        {
            try
            {
                var order = await _context.Orders.Include(o => o.customer).FirstOrDefaultAsync(o => o.IdOrder == id);
                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(int id, Order model)
        {
            try
            {
                if(id != model.IdOrder)
                {
                    return false;
                }
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return false;
                }

                var customer = await _context.Customers.FindAsync(model.customer.idcustomer);

                if (customer == null)
                {
                    return false;
                }

                order.customer = customer;
                order.date = model.date;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
