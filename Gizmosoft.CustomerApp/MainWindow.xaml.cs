using Gizmosoft.CustomerApp.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Gizmosoft.CustomerApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();
            Title = "Customers App";
            ViewModel = viewModel;
            root.Loaded += Root_Loaded;
        }

        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();    
        }

        public MainViewModel ViewModel { get; }

        private void ButtonMoveNavigation_OnClick(object sender, RoutedEventArgs e)
        {
            var currentColumn = Grid.GetColumn(customerListGrid);
            var newColumn = currentColumn == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColumn);
            navigationSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }

        private void ButtonToggleTheme_OnClick(object sender, RoutedEventArgs e)
        {
            root.RequestedTheme = root.RequestedTheme == ElementTheme.Light ? ElementTheme.Dark : ElementTheme.Light;
        }
    }
}
