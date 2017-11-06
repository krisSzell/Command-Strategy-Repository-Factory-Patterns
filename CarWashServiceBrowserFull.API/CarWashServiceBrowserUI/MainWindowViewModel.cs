using CarWashServiceBrowserFull.API.Models;
using CarWashServiceBrowserFull.API.Repositories;
using CarWashServiceBrowserUI.Commands;
using CarWashServiceBrowserUI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarWashServiceBrowserUI
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly JSONServicesRepository _repo;
        private ObservableCollection<Service> _services;
        private CommandHistory _commandHistory;
        private Service _selectedItem;
        private Service _editedItem;
        private ICommand _addCommand;
        private ICommand _undoCommand;
        private RelayCommand<Service> _removeCommand;

        public MainWindowViewModel()
        {
            _repo = new JSONServicesRepository();
            _services = Convert(_repo.GetAll());
            _commandHistory = new CommandHistory();
            _addCommand = new RelayCommand<Service>(OnAddPressed);
            _undoCommand = new RelayCommand<Service>(OnUndoPressed);
            _removeCommand = new RelayCommand<Service>(OnRemovePressed);
            _editedItem = new Service();
        }

        private void OnRemovePressed(Service obj)
        {
            var removeCommand = new RemoveServiceCommand(_repo, obj);
            _commandHistory.Execute(removeCommand);
            Services.Remove(obj);
        }

        private void OnUndoPressed(Service obj)
        {
            var lastCommand = _commandHistory.GetLastCommand();
            var service = _commandHistory.Undo();

            if (lastCommand is RemoveServiceCommand)
            {
                Services.Add(service);
            }
            if (lastCommand is AddServiceCommand)
            {
                Services.Remove(service);
            }
            if (lastCommand is EditServiceCommand)
            {
                var swap = Services.Single(s => s.ServiceId == service.ServiceId);
                swap = service;
            }
        }

        private void OnAddPressed(Service obj)
        {
            IServiceOperationCommand command;
            if (_selectedItem == null)
            {
                command = new AddServiceCommand(_repo, obj);
                _commandHistory.Execute(command);
                Services.Add(obj);
            } else
            if (!AreEqual(obj, _selectedItem) && _selectedItem != null)
            {
                command = new EditServiceCommand(_repo, obj, _selectedItem);
                _commandHistory.Execute(command);
                var swapIndex = Services.IndexOf(_selectedItem);
                Services.Insert(swapIndex, obj);
                var newServices = new List<Service>();
                newServices.AddRange(Services);
                newServices.RemoveAt(++swapIndex);
                var converted = Convert(newServices);
                Services = converted;
            }

            
        }

        public ObservableCollection<Service> Services {
            get { return _services; }
            set { SetProperty(ref _services, value); }
        }

        public Service SelectedItem
        {
            get { return _selectedItem; }
            set {
                if (value == null)
                {
                    value = new Service();
                }
                SetProperty(ref _selectedItem, value);
                var service = new Service
                {
                    Name = value.Name,
                    DurationInMinutes = value.DurationInMinutes,
                    Price = value.Price,
                    ServiceId = value.ServiceId
                };
                EditedItem = service;
            }
        }

        public Service EditedItem
        {
            get { return _editedItem; }
            set
            {
                SetProperty(ref _editedItem, value);
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
        }

        public ICommand UndoCommand
        {
            get { return _undoCommand; }
        }

        public ICommand RemoveCommand
        {
            get { return _removeCommand; }
        }

        private ObservableCollection<Service> Convert<Service>(IEnumerable<Service> original)
        {
            return new ObservableCollection<Service>(original);
        }

        private bool AreEqual(Service obj1, Service obj2)
        {
            bool result = false;
            if (obj1.Name == obj2.Name && obj1.Price == obj2.Price && obj1.DurationInMinutes == obj2.DurationInMinutes) result = true;

            return result;
        }
    }
}
