using CarWashServiceBrowserFull.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashServiceBrowserFull.API.Repositories
{
    public interface IServicesRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task<Service> GetByNameAsync(string name);
        void Add(Service obj);
        void Remove(Service obj);
        void Update(int id, Service updated);

        Task PersistChangesAsync();
        bool ServiceExists(int id);
    }
}
