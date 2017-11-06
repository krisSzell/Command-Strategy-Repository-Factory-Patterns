using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserFull.API;

namespace CarWashServiceBrowser.DataAccess.Repositories
{
    public class SqlServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;

        public SqlServicesRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Service obj)
        {
            if (_context.Services.Find(obj.ServiceId) != null)
                return;

            _context.Services.Add(obj);
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service GetById(int id)
        {
            return _context.Services.Find(id);
        }

        public Service GetByName(string name)
        {
            return _context.Services.SingleOrDefault(s => s.Name == name);
        }

        public void Remove(Service obj)
        {
            _context.Services.Remove(obj);
        }

        public void Update(int id, Service updated)
        {
            var current = _context.Services.Find(id);

            current = updated;
        }

        public void PersistChanges()
        {
            _context.SaveChanges();
        }
    }
}
