using Client.Commands;
using Client.Exceptions;
using Client.Model;
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
    public class BikeEditVM : INotifyPropertyChanged
    {
        private Station selectedStation;
        private State selectedState;
        private BikeExtended bikeModel;
        public ObservableCollection<Station> Stations { get; set; }
        public ObservableCollection<State> States { get; set; }

        public BikeEditVM(int ID)
        {
            try
            {
                Stations = addStations();
                States = addStates();
                if (ID == -1)
                {
                    bikeModel = new BikeExtended(ID);
                }
                else
                {
                    bikeModel = returnBike(ID);
                    returnState();
                    returnStation();
                }
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
                BikePropertyChanged("SelectedStation");
            }
        }
        public State SelectedState
        {
            get { return selectedState; }
            set
            {
                selectedState = value;
                BikePropertyChanged("SelectedState");
            }
        }

        public BikeExtended BikeModel
        {
            get { return bikeModel; }
            set
            {
                bikeModel = value;
                BikePropertyChanged("BikeModel");
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
                          if (BikeModel.Model.Length < 20)
                          {
                              throw new BikeDescFail();
                          }
                          if (BikeModel.ID == -1)
                          {
                              addNewBike(BikeModel.Model, SelectedStation.Name);
                          }
                          else
                          {
                              updateBike(BikeModel.ID, BikeModel.Model, SelectedState.StateName, SelectedStation.Name);
                          }
                          closeWindow();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  },
                  (obj) => SelectedState != null && SelectedStation != null));
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
        private ObservableCollection<State> addStates()
        {
            StateRepo stateRepo = new StateRepo("bike_local");
            List<string> st = stateRepo.getStates();

            ObservableCollection<State> sts = new ObservableCollection<State>();

            foreach (var item in st)
            {
                State s = new State(item);
                sts.Add(s);
            }

            return sts;
        }

        private BikeExtended returnBike(int ID)
        {
            BikeExtended bikeExtended = new BikeExtended();

            BikeRepo bikeRepo = new BikeRepo("bike_local");

            VeloBike b = bikeRepo.getBike(ID);

            bikeExtended.ID = b.ID;
            bikeExtended.Model = b.Model;
            bikeExtended.StateiD = b.StateiD;
            bikeExtended.StationID = b.StationID;

            return bikeExtended;
        }

        private void returnState()
        {
            foreach (var item in States)
            {
                if (item.StateName == bikeModel.StateiD)
                {
                    SelectedState = item;
                    break;
                }
            }
        }

        private void returnStation()
        {
            foreach (var item in Stations)
            {
                if (item.Name == bikeModel.StationID)
                {
                    SelectedStation = item;
                    break;
                }
            }
        }

        private void addNewBike(string desc, string choice)
        {
            int station = getStation(choice);
            int result;
            try
            {
                result = addBikeResult(desc, station);
                if (result == -1)
                {
                    throw new AddFail();
                }
                else
                {
                    MessageBox.Show($"Новый велосипед успешно добавлен\nсо статусом: Свободен (по-умолчанию для всех новых велосипедов)\nна станцию {choice}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int addBikeResult(string desc, int station)
        {
            int result = -1;
            BikeRepo bikeRepo = new BikeRepo("bike_local");

            result = bikeRepo.addByke(desc, station);

            return result;
        }

        private void updateBike(int ID, string desc, string state, string station)
        {
            int stateID = getState(state);
            int stationID = getStation(station);
            int result;
            try
            {
                result = updateBikeResult(ID, desc, stateID, stationID);
                if (result == -1)
                {
                    throw new AddFail();
                }
                else
                {
                    MessageBox.Show($"Bелосипед c ID {ID} обновлён успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int updateBikeResult(int ID, string desc, int state, int station)
        {
            int result = -1;
            BikeRepo bikeRepo = new BikeRepo("bike_local");

            result = bikeRepo.updateBike(ID, desc, state, station);

            return result;
        }

        private string getState(int ID)
        {
            StateRepo stateRepo = new StateRepo("bike_local");

            return stateRepo.getState(ID);
        }

        private string getStation(int ID)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(ID);
        }

        private int getStation(string name)
        {
            StationRepo stationRepo = new StationRepo("bike_local");

            return stationRepo.getStation(name);
        }

        private int getState(string name)
        {
            StateRepo stateRepo = new StateRepo("bike_local");

            return stateRepo.getState(name);
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
        public void BikePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
