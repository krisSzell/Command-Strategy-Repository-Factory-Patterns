using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashServiceBrowserUI.Commands
{
    public class AddServiceCommand : IServiceOperationCommand
    {
        private Service _service;
        private JSONServicesRepository _repo;

        public AddServiceCommand(JSONServicesRepository repo, Service service)
        {
            _service = service;
            _repo = repo;
        }

        public void Execute()
        {
            _repo.Add(_service);
        }

        public Service Undo()
        {
            _repo.Remove(_service);
            return _service;
        }
    }
}
