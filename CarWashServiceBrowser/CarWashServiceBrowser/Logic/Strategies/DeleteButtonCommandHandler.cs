using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CarWashServiceBrowser.Logic.Strategies
{
    public class DeleteButtonCommandHandler : ICommandHandler
    {
        private Stack<ICommand> _commands;
        private ServicesRepository _servicesRepository;
        private ListBox _lstServices;

        public DeleteButtonCommandHandler(Stack<ICommand> commands, ListBox lstServices, ServicesRepository servicesRepository)
        {
            _commands = commands;
            _lstServices = lstServices;
            _servicesRepository = servicesRepository;
        }

        public void Handle(Service service)
        {
            var delCommand = new DeleteServiceCommand(_lstServices, _servicesRepository, service);
            delCommand.Execute();
            _commands.Push(delCommand);
        }

        public void Handle(Service selected, Service service)
        {

        }
    }
}
