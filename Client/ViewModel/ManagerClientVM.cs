using Client.Commands;
using Client.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Client.ViewModel
{
    public class ManagerClientVM : INotifyPropertyChanged
    {
        private UsersTabVM usersTab;
        private BikesTabVM bikesTab;
        private StationsTabVM stationsTab;

        public ManagerClientVM()
        {
            usersTab = new UsersTabVM();
            bikesTab = new BikesTabVM();
            stationsTab = new StationsTabVM();
        }

        public UsersTabVM UsersTab
        {
            get { return usersTab; }
            set
            {
                usersTab = value;
                MngClPropertyChanged("UsersTab");
            }
        }

        public BikesTabVM BikesTab
        {
            get { return bikesTab; }
            set
            {
                bikesTab = value;
                MngClPropertyChanged("BikesTab");
            }
        }

        public StationsTabVM StationsTab
        {
            get { return stationsTab; }
            set
            {
                stationsTab = value;
                MngClPropertyChanged("StationsTab");
            }
        }

        private LogCommand helpCommand;
        public LogCommand HelpCommand
        {
            get
            {
                return helpCommand ??
                  (helpCommand = new LogCommand(obj =>
                  {
                      string message = "Вас приветствует программа Easy Bikes\n" +
                      "Для работы с базой заказов перейдите во вкладку пользователей.\n" +
                      "Для добавления, удаления и редактирования велосипедов выберите вкладку велосипедов\n" +
                      "Для добавления, удаления и редактирования станций выберите вкладку станций.\n" +
                      "Отображения изменений в базе станций происходят по кнопке \"Обновить\"\n" +
                      "Спасибо за использование нашего сервиса.";
                      MessageBox.Show(message);
                  }));
            }
        }

        private LogCommand changeCommand;
        public LogCommand ChangeCommand
        {
            get
            {
                return changeCommand ??
                  (changeCommand = new LogCommand(obj =>
                  {
                      makeMainWindow();
                  }));
            }
        }

        private LogCommand exitCommand;
        public LogCommand ExitCommand
        {
            get
            {
                return exitCommand ??
                  (exitCommand = new LogCommand(obj =>
                  {
                      closeProgram();
                  }));
            }
        }

        private void makeMainWindow()
        {
            MainWindow w = new MainWindow();
            w.Show();
            Application.Current.Windows[0].Close();
        }

        private void closeProgram()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void MngClPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
