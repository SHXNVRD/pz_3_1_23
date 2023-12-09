using OOO_NAN.Model;
using OOO_NAN.Database;
using System;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;

namespace OOO_NAN.ViewModel
{
    class AutorizationViewModel : Common.ViewModelBase
    {
        private string userEmail;
        private SecureString userPassword; 

        private RelayCommand? closeWindowCommand;
        private RelayCommand? authorizationCommand;

        public AutorizationViewModel()
        {

        }

        public string UserEmail
        {
            get { return userEmail; }
            set
            {
                userEmail = value;
                OnPropertyChanged();
            }
        }

        public SecureString UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ??
                    (closeWindowCommand = new RelayCommand(parametr => CloseWindow()));
            }
        }

        public RelayCommand AuthorizationCommand
        {
            get
            {
                return authorizationCommand ??
                    (authorizationCommand = new RelayCommand(ExcecuteAuthorizationCommand, CanExcecuteAuthorizationCommand));
            }
        }

        private bool CanExcecuteAuthorizationCommand(object? arg)
        {
            bool validData;
            Regex emailRegex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");

            if (string.IsNullOrWhiteSpace(UserEmail) || !emailRegex.IsMatch(UserEmail) || UserPassword.Length < 8)
                validData = false;
            else
                validData = true;
                return validData;
        }

        private void ExcecuteAuthorizationCommand(object? obj)
        {
            try
            {
                using (OooNanContext db = new OooNanContext())
                {
                    var user = db.Clients.Where(x => (x.Email == UserEmail && x.Password == UserPassword.ToString())).FirstOrDefault();

                    if (user != null)
                        MessageBox.Show("Вы успешно авторизовались");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
