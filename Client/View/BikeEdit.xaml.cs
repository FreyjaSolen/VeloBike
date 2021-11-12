using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Логика взаимодействия для BikeEdit.xaml
    /// </summary>
    public partial class BikeEdit : Window
    {
        public BikeEdit(int ID)
        {
            InitializeComponent();

            DataContext = new BikeEditVM(ID);
        }
    }
}
