using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Data.Context;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.Repository
{
    public class ProductRepository : ICrudRepository<Product>
    {
        private readonly CrudContext _context;

        public ProductRepository(CrudContext context) => _context = context;

        public async Task<IList<Product>> GetAll() => await _context.Product.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _context.Product.FindAsync(id);

        public Product GetById(int id) => _context.Product.Find(id);

        public async Task<bool> Save(Product t)
        {
            await _context.AddAsync<Product>(t);
            var count = await _context.SaveChangesAsync();
            return (count == 0) ? false : true;
        }

        public bool Update(Product t)
        {
            _context.Update<Product>(t);
            var count = _context.SaveChanges();
            return (count == 0) ? false : true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null)
                return false;

            _context.Remove<Product>(product);
            var count = _context.SaveChanges();
            return (count == 0) ? true : false;
        }
    }
}