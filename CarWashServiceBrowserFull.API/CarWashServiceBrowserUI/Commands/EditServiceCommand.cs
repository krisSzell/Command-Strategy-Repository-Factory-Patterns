using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserUI.Data;

namespace CarWashServiceBrowserUI.Commands
{
    public class EditServiceCommand : IServiceOperationCommand
    {
        private Service _modified;
        private Service _current;
        private JSONServicesRepository _repo;

        public EditServiceCommand(JSONServicesRepository repo, Service modified, Service current)
        {
            _modified = modified;
            _current = current;
            _repo = repo;
        }

        public void Execute()
        {
            _repo.Update(_current.ServiceId ,_modified);
        }

        public Service Undo()
        {
            _repo.Update(_modified.ServiceId, _current);
            return _current;
        }
    }
}
