using Client.Commands;
using Client.Exceptions;
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
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class StationsTabVM : INotifyPropertyChanged
    {
        private Station selectedStation;
        private ObservableCollection<Station> stations { get; set; }

        public StationsTabVM()
        {
            try
            {
                stations = addStations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Station SelectedStation
        {
            get { return selectedStation; }
            set
            {
                selectedStation = value;
                StnPropertyChanged("SelectedStation");
            }
        }

        public ObservableCollection<Station> Stations
        {
            get
            {
                return stations;
            }
            set
            {
                stations = value;
                StnPropertyChanged("Stations");
            }
        }

        private LogCommand editStationCommand;
        public LogCommand EditStationCommand
        {
            get
            {
                return editStationCommand ??
                  (editStationCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          int StID = getStation(SelectedStation.Name);
                          StationEdit w = new StationEdit(StID);
                          w.Show();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedStation != null));
            }
        }
        private LogCommand addStationCommand;
        public LogCommand AddStationCommand
        {
            get
            {
                return addStationCommand ??
                  (addStationCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          StationEdit w = new StationEdit(-1);
                          w.Show();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private LogCommand delStationCommand;
        public LogCommand DelStationCommand
        {
            get
            {
                return delStationCommand ??
                  (delStationCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          string quession = $"Вы точно хотите удалить станцию {SelectedStation.Name}?";
                          MessageBoxResult result = MessageBox.Show(quession, "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                          if (result == MessageBoxResult.Yes)
                          {
                              deleteStation(SelectedStation.Name);
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedStation != null));
            }
        }

        private LogCommand refreshCommand;
        public LogCommand RefreshCommand
        {
            get
            {
                return refreshCommand ??
                  (refreshCommand = new LogCommand(obj =>
                  {
                      Stations = addStations();
                  }));
            }
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

        private void deleteStation(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            try
            {
                int result;

                result = stationRepo.delStation(name);

                if (result == 0)
                {
                    throw new DeleteFail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getStation(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void StnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

