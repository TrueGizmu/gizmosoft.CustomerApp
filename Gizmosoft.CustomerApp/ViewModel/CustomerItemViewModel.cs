using Gizmosoft.CustomerApp.Model;

namespace Gizmosoft.CustomerApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public string? FirstName { 
            get => _model.FirstName;
            set
            {
                if (_model.FirstName == value)
                {
                    return;
                }

                _model.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                if (_model.LastName == value)
                {
                    return;
                }

                _model.LastName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                if (_model.IsDeveloper == value)
                {
                    return;
                }

                _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }
    }
}
