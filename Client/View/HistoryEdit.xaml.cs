using Client.ViewModel;
using System.Windows;

namespace Client.View
{
    /// <summary>
    /// Логика взаимодействия для HistoryEdit.xaml
    /// </summary>
    public partial class HistoryEdit : Window
    {
        public HistoryEdit(int ID)
        {
            InitializeComponent();

            DataContext = new EditHistoryVM(ID);
        }
    }
}
