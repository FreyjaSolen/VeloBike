using Client.Commands;
using Client.Exceptions;
using Client.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class StationEditVM : INotifyPropertyChanged
    {
        private int id;
        private Station st;

        public StationEditVM(int ID)
        {
            id = ID;
            try
            {
                if (id == -1)
                {
                    st = new Station();
                }
                else
                {
                    string name = getStation(id);
                    st = new Station(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Station St
        {
            get { return st; }
            set
            {
                st = value;
                StationPropertyChanged("St");
            }
        }

        private LogCommand applyCommand;
        public LogCommand ApplyCommand
        {
            get
            {
                return applyCommand ??
                  (applyCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          if (id == -1)
                          {
                              addStation(St.Name);
                          }
                          else
                          {
                              updateStation(id, St.Name);
                          }
                          closeWindow();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
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

        private void addStation(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            int result;
            try
            {
                result = addStationResult(name);
                if (result == -1)
                {
                    throw new AddFail();
                }
                else
                {
                    MessageBox.Show($"Новая станция {name} успешно добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int addStationResult(string desc)
        {
            int result = -1;
            StationRepo stationRepo = new StationRepo("bike_local");

            result = stationRepo.addStation(desc);

            return result;
        }

        private void updateStation(int StID, string station)
        {
            int result;
            try
            {
                result = updateStationResult(StID, station);
                if (result == -1)
                {
                    throw new AddFail();
                }
                else
                {
                    MessageBox.Show($"Станция {station} обновлена успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int updateStationResult(int StID, string desc)
        {
            int result = -1;
            StationRepo stationRepo = new StationRepo("bike_local");

            result = stationRepo.updateStation(StID, desc);

            return result;
        }

        private string getStation(int ID)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(ID);
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
        public void StationPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}