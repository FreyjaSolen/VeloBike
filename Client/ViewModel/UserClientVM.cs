using Client.Commands;
using Client.Exceptions;
using Client.Model;
using Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using VeloBikeRepo.Models;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class UserClientVM : INotifyPropertyChanged
    {
        private int id;
        private string nameUser;
        private Byke selectedByke;
        private Station selectedStation;
        private ToggleHistory toggleHistory;

        private ObservableCollection<Byke> bykes { get; set; }
        private ObservableCollection<ClientHM> clientHistory { get; set; }
        public ObservableCollection<Station> stations { get; set; }

        public UserClientVM(int ID)
        {
            try
            {
                id = ID;
                stations = addStations();
                nameUser = getNameUser(ID);
                clientHistory = addHistory(ID);
                toggleHistory = new ToggleHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<Byke> Bykes
        {
            get
            {
                return bykes;
            }
            set
            {
                bykes = value;
                OnPropertyChanged("Bykes");
            }
        }
        public ObservableCollection<ClientHM> ClientHistory
        {
            get
            {
                return clientHistory;
            }
            set
            {
                clientHistory = value;
                OnPropertyChanged("ClientHistory");
            }
        }

        public Byke SelectedByke
        {
            get { return selectedByke; }
            set
            {
                selectedByke = value;
                OnPropertyChanged("SelectedByke");
            }
        }

        public ToggleHistory TglHistory
        {
            get { return toggleHistory; }
            set
            {
                toggleHistory = value;
                OnPropertyChanged("ToggleHistory");
            }
        }

        public Station SelectedStation
        {
            get { return selectedStation; }
            set
            {
                selectedStation = value;
                OnPropertyChanged("SelectedStation");
            }
        }
        public string UserName
        {
            get { return nameUser; }
            set
            {
                nameUser = value;
                OnPropertyChanged("UserName");
            }
        }

        public int getID()
        {
            return id;
        }

        private LogCommand addBikesCommand;
        public LogCommand AddBikesCommand
        {
            get
            {
                return addBikesCommand ??
                  (addBikesCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          Bykes = addBykes(SelectedStation.Name);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                  (obj) => SelectedStation != null));
            }
        }

        private LogCommand orderCommand;
        public LogCommand OrderCommand
        {
            get
            {
                return orderCommand ??
                  (orderCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          madeOrder(id, SelectedStation.Name, SelectedByke.ID);
                          MessageBox.Show("Велосипед забронирован\nСмотрите вкладку истории заказов");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                  (obj) => SelectedByke != null));
            }
        }

        private LogCommand historyCommand;
        public LogCommand HistoryCommand
        {
            get
            {
                return historyCommand ??
                  (historyCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          if (toggleHistory.getSwitcher())
                          {
                              ClientHistory = addHistory(id);
                          }
                          else
                          {
                              ClientHistory = addOrders(id);
                          }
                          TglHistory.switchBTN();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
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
                      "Для начала работы выберите станцию в выпадающем меню и нажмите кнопку \"Ok\"." +
                      "Вам отобразится список доступных велосипедов.\n" +
                      "Выбрав понравившийся транспорт, просто нажмите кнопку \"Забронировать\" или\n" +
                      "просто щёлкните дважды по нему мышкой - вот и всё, готово!\n" +
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

        private string getNameUser(int ID)
        {
            string name = null;

            UserRepo userRepo = new UserRepo("bike_local");

            bool result = userRepo.ifName(ID);

            if (result)
            {
                name = userRepo.getName(ID);
            }
            else
            {
                name = userRepo.getUser(ID);
            }

            return name;
        }

        private ObservableCollection<Byke> addBykes(string st)
        {
            BikeRepo bykeRepo = new BikeRepo("bike_local");
            ObservableCollection<Byke> bikes = new ObservableCollection<Byke>();

            List<Bike> b = bykeRepo.getBikesFromStation(st);

            foreach (var item in b)
            {
                Byke byke = new Byke();
                byke.ID = item.ID;
                byke.Model = item.Model;

                bikes.Add(byke);
            }

            return bikes;
        }

        private ObservableCollection<Station> addStations()
        {
            StationRepo stationRepo = new StationRepo("bike_local");
            List<string> named = stationRepo.getAllStations();

            ObservableCollection<Station> sts = new ObservableCollection<Station>();

            foreach (var item in named)
            {
                Station s = new Station(item);
                sts.Add(s);
            }

            return sts;
        }

        private ObservableCollection<ClientHM> addHistory(int ID)
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");
            List<string> orders = historyRepo.getClientHistory(ID);

            ObservableCollection<ClientHM> h = new ObservableCollection<ClientHM>();

            foreach (var item in orders)
            {
                ClientHM o = new ClientHM(item);
                h.Add(o);
            }

            return h;
        }

        private ObservableCollection<ClientHM> addOrders(int ID)
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");
            List<string> orders = historyRepo.getClientOrders(ID);

            ObservableCollection<ClientHM> h = new ObservableCollection<ClientHM>();

            foreach (var item in orders)
            {
                ClientHM o = new ClientHM(item);
                h.Add(o);
            }

            return h;
        }

        private void madeOrder(int UserID, string station, int bikeID)
        {
            try
            {
                bookBike(bikeID);
                int result = 0;

                result = makeNote(UserID, station, bikeID);
                if (result == -1)
                {
                    throw new OrderFail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int makeNote(int UserID, string station, int bikeID)
        {
            DateTime time = DateTime.Now;
            long timeTic = time.Ticks;
            int stationID = getStationID(station);

            int result = 0;

            HistoryRepo historyRepo = new HistoryRepo("bike_local");
            result = historyRepo.addOrder(UserID, timeTic, stationID, bikeID);

            return result;
        }
        private int getStationID(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(name);
        }

        private void bookBike(int ID)
        {
            BikeRepo bykeRepo = new BikeRepo("bike_local");

            bykeRepo.setBusy(ID);
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
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
