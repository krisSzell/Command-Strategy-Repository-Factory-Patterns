using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Models;
using System.Windows.Controls;

namespace CarWashServiceBrowser.Logic
{
    public class AddServiceCommand : ICommand
    {
        private Service _service;
        private ServicesRepository _repo;
        private ListBox _listBox;
        private int _selectedIndex;

        public AddServiceCommand(ListBox listBox, ServicesRepository repo, Service service)
        {
            _service = service;
            _repo = repo;
            _listBox = listBox;
            _selectedIndex = _listBox.SelectedIndex;
        }

        public void Execute()
        {
            _repo.Add(_service);
            _listBox.Items.Add(_service);
            _selectedIndex = _listBox.Items.Count - 1;
        }

        public void Undo()
        {
            _repo.Delete(_service);
            _listBox.Items.RemoveAt(_selectedIndex);
        }
    }
}
