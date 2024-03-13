using appProduct.Data;
using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace appProduct.Repository.Entities
{
    public class OrderDetailRepository : IGenericRepository<OrderDetail>
    {
        private readonly DataContext _context;
        
        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> Create(OrderDetail model)
        {
            try
            {
                var product = await _context.Products.FindAsync(model.product.idproduct);
                var order = await _context.Orders.FindAsync(model.order.IdOrder);

                if(product == null || order == null)
                {
                    return null;
                }

                model.product = product;
                model.order = order;

                await _context.OrderDetails.AddAsync(model);
                await _context.SaveChangesAsync();
                return "OrderDetail Created Successfully";
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
                var orderDetail = await _context.OrderDetails.FindAsync(id);
                if (orderDetail == null)
                {
                    return false;
                }

                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<OrderDetail>> Read()
        {
            try
            {
                return await _context.OrderDetails.Include(d => d.product).Include(d => d.order).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OrderDetail> Search(int id)
        {
            try
            {
                return await _context.OrderDetails.Include(d => d.order).Include(d => d.product).FirstOrDefaultAsync(d => d.IdOrderDetail == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Update(int id, OrderDetail model)
        {
            try
            {
                var orderDetail = await _context.OrderDetails.FindAsync(id);
                if (orderDetail == null)
                {
                    return false;
                }

                var product = await _context.Products.FindAsync(model.product.idproduct);
                var order = await _context.Orders.FindAsync(model.order.IdOrder);

                if (product == null || order == null)
                {
                    return false;
                }

                orderDetail.product = product;
                orderDetail.order = order;
                orderDetail.Quantity = model.Quantity;
                orderDetail.priceUnit = model.priceUnit;
                orderDetail.Subtotal = model.Subtotal;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                return false;
            }
        }

    }
}
