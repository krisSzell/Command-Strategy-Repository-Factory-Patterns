using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Models;
using System.Windows.Controls;

namespace CarWashServiceBrowser.Logic
{
    public class DeleteServiceCommand : ICommand
    {
        private Service _service;
        private ServicesRepository _repo;
        private ListBox _listBox;
        private int _selectedIndex;

        public DeleteServiceCommand(ListBox listBox, ServicesRepository repo, Service service)
        {
            _service = service;
            _repo = repo;
            _listBox = listBox;
            _selectedIndex = _listBox.SelectedIndex;
        }

        public void Execute()
        {
            _repo.Delete(_service);
            _listBox.Items.RemoveAt(_selectedIndex);
        }

        public void Undo()
        {
            _repo.Add(_service);
            _listBox.Items.Add(_service);
        }
    }
}