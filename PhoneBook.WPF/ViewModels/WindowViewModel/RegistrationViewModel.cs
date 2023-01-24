using PhoneBook.ApiInterLayer.Models;
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
                var token = await UserApi.AuthUser(Login, Password);

                if (token is not null)
                {
                    //Clients.Client = token;

                    WindowClosed?.Invoke(p, new EventArgs());
                    Notification.ShowSuccess("Вход выполнен");
                }
            }
            catch (Exception)
            {
                Notification.ShowWarning("Неверный пароль или логин");
            }
        }

        private bool CanRegist(object p) => true;

        public ICommand Cancel { get; }

        private async void OnCancel(object p) => WindowClosed?.Invoke(p, new System.EventArgs());

        private bool CanCancel(object p) => true;

        private string _firstName;
        public string FirsName
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
