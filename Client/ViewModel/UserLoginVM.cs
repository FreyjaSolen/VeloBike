using Client.Commands;
using Client.Exceptions;
using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using VeloBikeRepo.Repository;

namespace Client.ViewModel
{
    public class UserLoginVM : INotifyPropertyChanged
    {
        private string pass;
        private string nick;

        private UserRepo userRepo;

        public UserLoginVM()
        {
            userRepo = new UserRepo("bike_local");
        }

        public string Nick
        {
            get { return nick; }
            set
            {
                nick = value;
                NotifyPropertyChanged("Nick");
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

        private LogCommand helpCommand;
        public LogCommand HelpCommand
        {
            get
            {
                return helpCommand ??
                  (helpCommand = new LogCommand(obj =>
                  {
                      string message = "Вас приветствует программа Easy Bikes\n" +
                      "Для начала работы введите свой логин и пароль. " +
                      "Если у вас ещё нет аккаунта, нажмите кнопку \"Регистрация\". " +
                      "Спасибо за использование нашего сервиса.";
                      MessageBox.Show(message);
                  }));
            }
        }

        private LogCommand checkCommand;
        public LogCommand CheckCommand
        {
            get
            {
                return checkCommand ??
                  (checkCommand = new LogCommand(obj =>
                  {
                      try
                      {
                          if (Nick != null && Pass != null)
                          {
                              userCheck();
                          }
                          else
                          {
                              throw new NullFields();
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        private LogCommand registrationCommand;
        public LogCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new LogCommand(obj =>
                  {
                      makeRegistrationWindow();
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

        public void userCheck()
        {
            try
            {
                if (!nickCheck())
                {
                    throw new LoginFail();
                }
                if (!passCheck())
                {
                    throw new PassFail();
                }

                int id = userRepo.getUser(Nick);

                if (isManager())
                {
                    makeManagerWindow();
                }
                else
                {
                    makeUserWindow(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool nickCheck()
        {
            return userRepo.isUserExist(Nick);
        }

        private bool passCheck()
        {
            string p = GetHash(Pass);
            return userRepo.isLogExist(Nick, p);
        }

        private bool isManager()
        {
            return userRepo.isManager(Nick);
        }

        private void makeUserWindow(int ID)
        {
            UserClient w = new UserClient(ID);
            w.Show();
            Application.Current.Windows[0].Close();
        }

        private void makeManagerWindow()
        {
            ManagerClient w = new ManagerClient();
            w.Show();
            Application.Current.Windows[0].Close();
        }

        private void makeRegistrationWindow()
        {
            Registration w = new Registration();
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
