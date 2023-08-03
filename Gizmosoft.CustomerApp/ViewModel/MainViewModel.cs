using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Gizmosoft.CustomerApp.Data;

namespace Gizmosoft.CustomerApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetField(ref _selectedCustomer, value))
                {
                    RaisePropertyChanged(nameof(IsCustomerSelected));
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
    }
}
