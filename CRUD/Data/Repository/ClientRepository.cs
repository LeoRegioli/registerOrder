using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data.Context;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.Repository
{
    public class ClientRepository : ICrudRepository<Client>
    {
        private readonly CrudContext _context;

        public ClientRepository(CrudContext context) => _context = context;

        public async Task<IList<Client>> GetAll() => await _context.Clients.Include(a => a.Address).Include(t => t.Telephone).Include(o => o.Order).ToListAsync();

        public async Task<Client> GetByIdAsync(int id) => await _context.Clients.Include(a => a.Address).Include(t => t.Telephone).Include(o => o.Order).Where(c => c.ID == id).FirstOrDefaultAsync();

        public Client GetById (int id) => _context.Clients.Include(a => a.Address).Include(t => t.Telephone).Include(o => o.Order).Where(c => c.ID == id).FirstOrDefault();
        
        public async Task<bool> Save(Client client)
        {
            await _context.AddAsync<Client>(client);
            var count = await _context.SaveChangesAsync();
            return (count == 0) ? false : true;
        }

        public bool Update(Client client)
        {
            _context.Update<Client>(client);
            var count = _context.SaveChanges();
            return (count == 0) ? false : true;
        }
        public bool Delete(int id)
        {
            var client = GetById(id);
            if (client == null)
                return false;

            _context.Remove<Client>(client);
            var count = _context.SaveChanges();
            return (count == 0) ? false : true;
        }
    }
}