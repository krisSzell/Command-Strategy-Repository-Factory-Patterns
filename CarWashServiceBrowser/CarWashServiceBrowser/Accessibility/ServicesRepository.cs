using CarWashServiceBrowser.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarWashServiceBrowser.Accessibility
{
    public class ServicesRepository
    {
        private FakeDb _data;
        private ServicesSerializer _serializer;

        public ServicesRepository(FakeDb db, ServicesSerializer serializer)
        {
            _data = db;
            _serializer = serializer;
        }

        public List<Service> GetAll()
        {
            var services = _data.Read();

            return _serializer.Deserialize(services);
        }

        public void Delete(Service service)
        {
            var services = GetAll();
            var serviceToDelete = services.SingleOrDefault(s => s.Name == service.Name);
            if (serviceToDelete != null)
            {
                services.Remove(serviceToDelete);
            }

            _data.Write(_serializer.Serialize(services));
        }

        public void Add(Service service)
        {
            var services = GetAll();
            var toModify = services.SingleOrDefault(s => s.Name == service.Name);
            if (toModify == null)
            {
                services.Add(service);
            }

            _data.Write(_serializer.Serialize(services));
        }

        public void Modify(Service current, Service modified)
        {
            var services = GetAll();
            var toModify = services.SingleOrDefault(s => s.Name == current.Name);
            var index = services.IndexOf(toModify);
            if (toModify != null)
            {
                toModify = modified;
                services.Insert(index, toModify);
                services.RemoveAt(index + 1);
            }

            _data.Write(_serializer.Serialize(services));
        }
    }
}
