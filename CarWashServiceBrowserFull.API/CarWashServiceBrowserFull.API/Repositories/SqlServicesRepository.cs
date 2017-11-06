using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserFull.API;
using System.Data.Entity;

namespace CarWashServiceBrowserFull.API.Repositories
{
    public class SqlServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;

        public SqlServicesRepository()
        {
            _context = ContextInstanceProvider.Instance;
        }

        public void Add(Service obj)
        {
            if (_context.Services.Find(obj.ServiceId) != null)
                return;

            _context.Services.Add(obj);
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<Service> GetByNameAsync(string name)
        {
            return await _context.Services.SingleOrDefaultAsync(s => s.Name == name);
        }

        public void Remove(Service obj)
        {
            _context.Services.Remove(obj);
        }

        public void Update(int id, Service updated)
        {
            _context.Entry(updated).State = EntityState.Modified;
        }

        public async Task PersistChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool ServiceExists(int id)
        {
            return _context.Services.Count(e => e.ServiceId == id) > 0;
        }
    }
}
