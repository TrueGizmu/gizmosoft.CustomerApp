using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Gizmosoft.CustomerApp.Data;
using Gizmosoft.CustomerApp.Model;

namespace Gizmosoft.CustomerApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCustomerCommand = new RelayCommand(AddCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, CanDeleteCustomer);
        }
        
        public RelayCommand AddCustomerCommand { get; }
        public RelayCommand DeleteCustomerCommand { get; }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetField(ref _selectedCustomer, value))
                {
                    RaisePropertyChanged(nameof(IsCustomerSelected));
                    DeleteCustomerCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is null)
            {
                return;
            }

            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }

        private void AddCustomer()
        {
            var newCustomer = new Customer { FirstName = "New" };
            var newViewModel = new CustomerItemViewModel(newCustomer);
            Customers.Add(newViewModel);
            SelectedCustomer = newViewModel;
        }

        private bool CanDeleteCustomer() => IsCustomerSelected;

        private void DeleteCustomer()
        {
            if (SelectedCustomer is null) 
                return;
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }
    }
}
