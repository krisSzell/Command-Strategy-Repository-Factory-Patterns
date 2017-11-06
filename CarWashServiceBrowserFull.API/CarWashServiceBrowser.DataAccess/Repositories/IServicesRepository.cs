using CarWashServiceBrowserFull.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashServiceBrowser.DataAccess.Repositories
{
    public interface IServicesRepository
    {
        IEnumerable<Service> GetAll();
        Service GetById(int id);
        Service GetByName(string name);
        void Add(Service obj);
        void Remove(Service obj);
        void Update(int id, Service updated);

        void PersistChanges();
    }
}
