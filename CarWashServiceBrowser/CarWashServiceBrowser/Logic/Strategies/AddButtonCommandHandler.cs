using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CarWashServiceBrowser.Logic
{
    public class AddButtonCommandHandler : ICommandHandler
    {
        private Stack<ICommand> _commands;
        private ServicesRepository _servicesRepository;
        private ListBox _lstServices;

        public AddButtonCommandHandler(Stack<ICommand> commands, ListBox lstServices, ServicesRepository servicesRepository)
        {
            _commands = commands;
            _lstServices = lstServices;
            _servicesRepository = servicesRepository;
        }

        public void Handle(Service service)
        {
        }

        public void Handle(Service selected, Service service)
        {
            if (selected == null)
            {
                var addCommand = new AddServiceCommand(_lstServices, _servicesRepository, service);
                addCommand.Execute();
                _commands.Push(addCommand);
            }
            else
            {
                var modifyCommand = new ModifyServiceCommand(_lstServices, _servicesRepository, selected, service);
                modifyCommand.Execute();
                _commands.Push(modifyCommand);
            }
        }
    }
}
