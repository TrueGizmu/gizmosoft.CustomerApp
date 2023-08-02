using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Gizmosoft.CustomerApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        
        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomer.Content = "Customer added";
        }
    }
}
