using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserUI.Data;

namespace CarWashServiceBrowserUI.Commands
{
    public class RemoveServiceCommand : IServiceOperationCommand
    {
        private Service _removed;
        private JSONServicesRepository _repo;

        public RemoveServiceCommand(JSONServicesRepository repo, Service service)
        {
            _removed = service;
            _repo = repo;
        }

        public void Execute()
        {
            _repo.Remove(_removed);
        }

        public Service Undo()
        {
            _repo.Add(_removed);
            return _removed;
        }
    }
}
