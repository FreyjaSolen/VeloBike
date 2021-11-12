using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Логика взаимодействия для StationEdit.xaml
    /// </summary>
    public partial class StationEdit : Window
    {
        public StationEdit(int ID)
        {
            InitializeComponent();

            DataContext = new StationEditVM(ID);
        }
    }
}
