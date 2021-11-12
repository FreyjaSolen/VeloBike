using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerClient.xaml
    /// </summary>
    public partial class ManagerClient : Window
    {
        public ManagerClient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ManagerClientVM();
        }
    }
}
