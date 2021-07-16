using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data.Context;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.Repository
{
    public class OrderRepository : ICrudRepository<Order>
    {
        private readonly CrudContext _context;
        public OrderRepository(CrudContext context) => _context = context;
        public async Task<IList<Order>> GetAll() => await _context.Order.Include(c => c.Client).Include(o => o.OrderItens).ToListAsync();
        public async Task<Order> GetByIdAsync(int id) => await _context.Order.Include(c => c.Client).Include(o => o.OrderItens).Where(o => o.ID == id).FirstOrDefaultAsync();
        public Order GetById(int id) => _context.Order.Include(c => c.Client).Include(o => o.OrderItens).Where(o => o.ID == id).FirstOrDefault();
        public async Task<bool> Save(Order order)
        {
            try
            {
                await _context.AddAsync(order);
                var count = await _context.SaveChangesAsync();
                return (count == 0) ? false : true;
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }

        public bool Update(Order order)
        {
            _context.Update<Order>(order);
            var count = _context.SaveChanges();
            return (count == 0) ? false : true;
        }

        public bool Delete(int id)
        {
            var order = GetById(id);
            if (order == null)
                return false;

            _context.Remove<Order>(order);
            var count = _context.SaveChanges();
            return (count == 0) ? false : true;
        }
    }
}