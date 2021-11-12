using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Логика взаимодействия для UserClient.xaml
    /// </summary>
    public partial class UserClient : Window
    {
        public UserClient(int ID)
        {
            InitializeComponent();

            DataContext = new UserClientVM(ID);
        }
    }
}
