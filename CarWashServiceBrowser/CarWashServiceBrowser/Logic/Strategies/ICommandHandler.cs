using CarWashServiceBrowser.Models;

namespace CarWashServiceBrowser.Logic
{
    public interface ICommandHandler
    {
        void Handle(Service service);
        void Handle(Service selected, Service service);
    }
}
