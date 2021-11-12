using Client.Commands;
using Client.Model;
using Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VeloBikeRepo.Models;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class EditHistoryVM : INotifyPropertyChanged
    {
        private HistoryEditModel editHistory;
        private Station selectedStation;

        public ObservableCollection<Station> Stations { get; set; }

        public EditHistoryVM(int ID)
        {
            try
            {
                editHistory = returnHistory(ID);
                Stations = addStations();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public HistoryEditModel EditHistory
        {
            get { return editHistory; }
            set
            {
                editHistory = value;
                NotifyPropertyChanged("EditHistory");
            }
        }
        public Station SelectedStation
        {
            get { return selectedStation; }
            set
            {
                selectedStation = value;
                NotifyPropertyChanged("SelectedStation");
            }
        }
        private LogCommand resultCommand;
        public LogCommand ResultCommand
        {
            get
            {
                return resultCommand ??
                  (resultCommand = new LogCommand(obj =>
                  {
                      EditHistory.Cost = getCoast();
                      if (EditHistory.Cost < 10)
                      {
                          EditHistory.Cost = 10;
                      }
                  },
                (obj) => SelectedStation != null));
            }
        }

        private LogCommand cancelCommand;
        public LogCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                  (cancelCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          closeWindow();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }

        private LogCommand okCommand;
        public LogCommand OkCommand
        {
            get
            {
                return okCommand ??
                  (okCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          setOrder();
                          closeWindow();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => EditHistory.Cost > 9));
            }
        }

        private HistoryEditModel returnHistory(int OrderID)
        {
            HistoryEditModel h = new HistoryEditModel();

            try
            {
                HistoryRepo historyRepo = new HistoryRepo("bike_local");

                History history = historyRepo.getOrderFromID(OrderID);

                h.OrderID = history.ID;
                h.User = history.User;
                h.Date = new DateTime(history.Date);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            h.DateEnd = DateTime.Now;

            return h;
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

        private long getCoast()
        {
            return (EditHistory.DateEnd.Ticks - EditHistory.Date.Ticks) / 10000000000;
        }

        private void setOrder()
        {
            int stID = getStID(SelectedStation.Name);
            int bID = getBikeID();
            noteOrder(stID);
            setVoidByke(bID, stID);
        }
        private void noteOrder(int StationID)
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");

            historyRepo.addStAndCoast(EditHistory.OrderID, StationID, EditHistory.Cost);
        }
        private int getStID(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(name);
        }
        private int getBikeID()
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");

            return historyRepo.getBykeIDFromOrder(EditHistory.OrderID);
        }
        private void setVoidByke(int ID, int Station)
        {
            BikeRepo bikeRepo = new BikeRepo("bike_local");

            bikeRepo.setVoid(ID);
            bikeRepo.setStation(ID, Station);
        }

        private void closeWindow()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
