using CarWashServiceBrowserFull.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashServiceBrowserUI.Commands
{
    public interface IServiceOperationCommand
    {
        void Execute();
        Service Undo();
    }
}
