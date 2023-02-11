using PhoneBook.ApiInterLayer.Models;
using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using System;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.WindowViewModel
{
    internal class RegistrationViewModel : WindowViewModelBase
    {
        public RegistrationViewModel()
        {
            Regist = new LamdaCommand(OnRegist, CanRegist);
            Cancel = new LamdaCommand(OnCancel, CanCancel);
        }

        public ICommand Regist { get; }

        private async void OnRegist(object p)
        {
            try
            {
                var user = new User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Login = Login,
                    Password = Password,
                    Role = Role.User
                };

                var resultUser = await UserApi.CreateAsync(user);

                if (resultUser?.Password != null)
                {
                    Notification.ShowSuccess("Пользователь зарегестрирован");
                    Clients.User = user;
                    WindowClosed?.Invoke(p, new EventArgs());
                }
                else
                {
                    Notification.ShowError("Пользователь уже существует");
                }
            }
            catch (Exception ex)
            {
                Notification.ShowWarning(ex.Message);
            }
        }

        private bool CanRegist(object p) => true;

        public ICommand Cancel { get; }

        private async void OnCancel(object p) => WindowClosed?.Invoke(p, new EventArgs());

        private bool CanCancel(object p) => true;

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

    }
}
