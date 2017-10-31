using CarWashServiceBrowser.Accessibility;
using CarWashServiceBrowser.Logic;
using CarWashServiceBrowser.Logic.Strategies;
using CarWashServiceBrowser.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CarWashServiceBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServicesRepository _servicesRepository;
        private Stack<ICommand> _commands;
        private Service _selected;

        public MainWindow()
        {
            InitializeComponent();
            _servicesRepository = new ServicesRepository(
                new FakeDb(), 
                new ServicesSerializer());
            _commands = new Stack<ICommand>();
            populateListOfServices();
            _selected = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var service = getServiceFromTxtBox();

            new AddButtonCommandHandler(_commands, lstServices, _servicesRepository)
                .Handle(_selected, service);

            clearTextBoxes();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var service = getServiceFromTxtBox();

            new DeleteButtonCommandHandler(_commands, lstServices, _servicesRepository)
                .Handle(service);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo();
            }
        }

        private void lstServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lstBox = (ListBox) sender;
            _selected = (Service)lstBox.SelectedItem;

            updateMasterView(_selected);
        }

        private void updateMasterView(Service selected)
        {
            if (lstServices.SelectedIndex == -1)
            {
                clearTextBoxes();
            } else
            {
                txtName.Text = selected.Name;
                txtPrice.Text = selected.Price.ToString();
                txtDuration.Text = selected.DurationInMinutes.ToString();
            }
        }

        private void populateListOfServices()
        {
            var services = _servicesRepository.GetAll();

            foreach (var item in services)
            {
                lstServices.Items.Add(item);
            }
        }

        private Service getServiceFromTxtBox()
        {
            if (txtName.Text == null)
            {
                return null;
            }

            return ServicesFactory.CreateSingle(txtName.Text,
                Convert.ToDecimal(txtPrice.Text),
                Convert.ToInt32(txtDuration.Text));
        }

        private void clearTextBoxes()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtDuration.Text = "";
        }

    }
}
