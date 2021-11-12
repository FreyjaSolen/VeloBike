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
using VeloBikeRepo.Models;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class BikesTabVM : INotifyPropertyChanged
    {
        private Byke selectedBike;
        private State selectedState;
        private ObservableCollection<Byke> bikes { get; set; }
        public ObservableCollection<State> States { get; set; }

        public BikesTabVM()
        {
            try
            {
                States = addStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Byke SelectedBike
        {
            get { return selectedBike; }
            set
            {
                selectedBike = value;
                BstPropertyChanged("SelectedBike");
            }
        }
        public State SelectedState
        {
            get { return selectedState; }
            set
            {
                selectedState = value;
                BstPropertyChanged("SelectedState");
            }
        }
        public ObservableCollection<Byke> Bikes
        {
            get
            {
                return bikes;
            }
            set
            {
                bikes = value;
                BstPropertyChanged("Bikes");
            }
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
                          Bikes = addBikes(SelectedState.StateName);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedState != null));
            }
        }

        private LogCommand editBikeCommand;
        public LogCommand EditBikeCommand
        {
            get
            {
                return editBikeCommand ??
                  (editBikeCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          BikeEdit w = new BikeEdit(SelectedBike.ID);
                          w.Show();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedBike != null && SelectedState.StateName != States[0].StateName));
            }
        }
        private LogCommand addBikeCommand;
        public LogCommand AddBikeCommand
        {
            get
            {
                return addBikeCommand ??
                  (addBikeCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          BikeEdit w = new BikeEdit(-1);
                          w.Show();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private LogCommand delBikeCommand;
        public LogCommand DelBikeCommand
        {
            get
            {
                return delBikeCommand ??
                  (delBikeCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          string quession = $"Вы точно хотите удалить велосипед с ID {SelectedBike.ID}?";
                          MessageBoxResult result = MessageBox.Show(quession, "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                          if (result == MessageBoxResult.Yes)
                          {
                              deleteBike(SelectedBike.ID);
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedBike != null && SelectedState.StateName != States[0].StateName));
            }
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

        private ObservableCollection<Byke> addBikes(string st)
        {
            BikeRepo bikeRepo = new BikeRepo("bike_local");
            ObservableCollection<Byke> bikes = new ObservableCollection<Byke>();

            List<Bike> b = bikeRepo.getBikesWithState(st);

            foreach (var item in b)
            {
                Byke byke = new Byke();
                byke.ID = item.ID;
                byke.Model = "ID: " + item.ID + ". Model: " + item.Model;

                bikes.Add(byke);
            }

            return bikes;
        }

        private void deleteBike(int ID)
        {
            BikeRepo bikeRepo = new BikeRepo("bike_local");

            try
            {
                int result;

                result = bikeRepo.deleteBike(ID);

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void BstPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}