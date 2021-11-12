using Client.Commands;
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
    public class UsersTabVM : INotifyPropertyChanged
    {
        private UserNick selectedUser;
        private OrderHM selectedOrder;
        private ToggleHistory toggleHistory;
        public ObservableCollection<UserNick> Users { get; set; }
        private ObservableCollection<OrderHM> clientsHistory { get; set; }

        public UsersTabVM()
        {
            toggleHistory = new ToggleHistory();
            try
            {
                Users = addClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public UserNick SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                MngPropertyChanged("SelectedUser");
            }
        }
        public OrderHM SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                MngPropertyChanged("SelectedOrder");
            }
        }
        public ToggleHistory ToggleOrders
        {
            get { return toggleHistory; }
            set
            {
                toggleHistory = value;
                MngPropertyChanged("ToggleOrders");
            }
        }
        public ObservableCollection<OrderHM> ClientsHistory
        {
            get
            {
                return clientsHistory;
            }
            set
            {
                clientsHistory = value;
                MngPropertyChanged("ClientsHistory");
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
                          if (ToggleOrders.getSwitcher())
                          {
                              ClientsHistory = addHistories(SelectedUser.Nick);
                          }
                          else
                          {
                              ClientsHistory = addOrders(SelectedUser.Nick);
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                      ToggleOrders.switchBTN();
                  },
                (obj) => SelectedUser != null));
            }
        }
        private LogCommand checkoutCommand;
        public LogCommand CheckoutCommand
        {
            get
            {
                return checkoutCommand ??
                  (checkoutCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          makeEditWindow(SelectedOrder.ID);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                (obj) => SelectedOrder != null && ToggleOrders.getSwitcher()));
            }
        }
        private ObservableCollection<UserNick> addClients()
        {
            UserRepo userRepo = new UserRepo("bike_local");
            List<string> nicks = userRepo.getClients();

            ObservableCollection<UserNick> usrs = new ObservableCollection<UserNick>();

            foreach (var item in nicks)
            {
                UserNick s = new UserNick(item);
                usrs.Add(s);
            }

            return usrs;
        }
        private ObservableCollection<OrderHM> addHistories(string UserName)
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");

            List<OrderText> orders = historyRepo.getMngHistory(UserName);

            ObservableCollection<OrderHM> histories = new ObservableCollection<OrderHM>();

            foreach (var item in orders)
            {
                OrderHM h = new OrderHM();
                h.ID = item.ID;
                h.OrderText = item.Text;

                histories.Add(h);
            }

            return histories;
        }
        private ObservableCollection<OrderHM> addOrders(string UserName)
        {
            HistoryRepo historyRepo = new HistoryRepo("bike_local");

            List<OrderText> orders = historyRepo.getMngOrders(UserName);

            ObservableCollection<OrderHM> histories = new ObservableCollection<OrderHM>();

            foreach (var item in orders)
            {
                OrderHM h = new OrderHM();
                h.ID = item.ID;
                h.OrderText = item.Text;

                histories.Add(h);
            }

            return histories;
        }

        private void makeEditWindow(int OrderID)
        {
            HistoryEdit w = new HistoryEdit(OrderID);
            w.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void MngPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}