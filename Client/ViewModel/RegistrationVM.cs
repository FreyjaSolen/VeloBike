using Client.Commands;
using Client.Exceptions;
using Client.Model;
using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class RegistrationVM : INotifyPropertyChanged
    {
        private UserInfo userInfo;
        private UserRepo userRepo;
        private string pass;

        public RegistrationVM()
        {
            userInfo = new UserInfo();
            userRepo = new UserRepo("bike_local");
        }

        public string NickName
        {
            get { return userInfo.NickName; }
            set
            {
                userInfo.NickName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string Name
        {
            get { return userInfo.Name; }
            set
            {
                userInfo.Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string LastName
        {
            get { return userInfo.LastName; }
            set
            {
                userInfo.LastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        public string Pass
        {
            get { return pass; }
            set
            {
                pass = value;
                NotifyPropertyChanged("Pass");
            }
        }

        private LogCommand registCommand;
        public LogCommand RegistCommand
        {
            get
            {
                return registCommand ??
                  (registCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          if (NickName != null && Pass != null)
                          {
                              checkUser();
                          }
                          else
                          {
                              throw new NullFields();
                          }
                          addUser();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        private LogCommand logCommand;
        public LogCommand LogCommand
        {
            get
            {
                return logCommand ??
                  (logCommand = new LogCommand(obj =>
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

        private void checkUser()
        {
            if (!testLogin())
            {
                throw new NickClaim();
            }
            if (!testPass())
            {
                throw new PassClaim();
            }
            if (checkLogin())
            {
                throw new LoginBusy();
            }
        }

        private void addUser()
        {
            string pasHash = GetHash(Pass);
            int result = userRepo.addUser(NickName, pasHash);
            if (result != -1)
            {
                if (Name != null)
                {
                    userRepo.updateName(NickName, Name);
                }
                if (LastName != null)
                {
                    userRepo.updateLstName(NickName, LastName);
                }
                int id = userRepo.getUser(NickName);
                makeUserWindow(id);
            }
            else
            {
                throw new AddFail();
            }
        }
        private bool testLogin()
        {
            if (NickName == null)
                return false;
            string test = NickName.Replace(" ", "");
            if (test != NickName)
                return false;
            if (NickName.Length < 3 || NickName.Length > 20)
                return false;

            return true;
        }
        private bool testPass()
        {
            if (Pass == null)
                return false;
            string test = Pass.Replace(" ", "");
            if (test != Pass)
                return false;
            if (Pass.Length < 6 || Pass.Length > 20)
                return false;

            return true;
        }

        private bool checkLogin()
        {
            return userRepo.isUserExist(NickName);
        }

        private void makeMainWindow()
        {
            MainWindow w = new MainWindow();
            w.Show();
            Application.Current.Windows[0].Close();
        }
        private void makeUserWindow(int ID)
        {
            UserClient w = new UserClient(ID);
            w.Show();
            Application.Current.Windows[0].Close();
        }
        private void closeProgram()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private static string GetHash(string input)
        {
            //SHA512
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
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
