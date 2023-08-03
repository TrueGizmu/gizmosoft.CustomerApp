using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Gizmosoft.CustomerApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Customers App";
        }

        private void ButtonMoveNavigation_OnClick(object sender, RoutedEventArgs e)
        {
            var currentColumn = Grid.GetColumn(customerListGrid);
            var newColumn = currentColumn == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColumn);
            navigationSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }
    }
}
