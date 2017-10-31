using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Models;
using System.Windows.Controls;

namespace CarWashServiceBrowser.Logic
{
    public class ModifyServiceCommand : ICommand
    {
        private Service _currentService;
        private Service _modifiedService;
        private ServicesRepository _repo;
        private ListBox _listBox;
        private int _selectedIndex;

        public ModifyServiceCommand(ListBox listBox, ServicesRepository repo, Service current, Service modified)
        {
            _currentService = current;
            _modifiedService = modified;
            _repo = repo;
            _listBox = listBox;
            _selectedIndex = _listBox.SelectedIndex;
        }

        public void Execute()
        {
            _repo.Modify(_currentService, _modifiedService);
            _listBox.Items[_selectedIndex] = _modifiedService;
        }

        public void Undo()
        {
            _repo.Modify(_modifiedService, _currentService);
            _listBox.Items[_selectedIndex] = _currentService;
        }
    }
}
