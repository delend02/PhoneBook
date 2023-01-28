using PhoneBook.ApiInterLayer;
using PhoneBook.ApiInterLayer.Models;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using PhoneBook.WPF.Views.WindowViews;
using System;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.WindowViewModel
{
    internal class AuthorizationWindowViewModel : WindowViewModelBase
    {
        public AuthorizationWindowViewModel()
        {
            Enter = new LamdaCommand(OnEnter, CanEnter);
            Registration = new LamdaCommand(OnRegistration, CanRegistration);
            Cancel = new LamdaCommand(OnCancel, CanCancel);
        }

        public ICommand Enter { get; }

        private async void OnEnter(object p)
        {
            try
            {
                var message = "Неверный пароль или логин";
                var token = await UserApi.AuthUser(Login, Password);

                if (token is not null)
                {
                    Api.UseToken(token);

                    var user = await UserApi.GetByLogin(Login) ?? throw new Exception("Не удалось получить пользователя. Свяжитесь с тех.поддержкой");

                    Clients.User = user;

                    message = $"Вход выполнен. Вы авторизованы как {Clients.User.Login}";
                }

                Notification.ShowInformation(message);

                WindowClosed?.Invoke(p, new EventArgs());
                
            }
            catch (Exception ex)
            {
                Notification.ShowWarning(ex.Message);
            }
        }

        private bool CanEnter(object p) => true;

        public ICommand Registration { get; }

        private async void OnRegistration(object p)
        {
            RegistrationWindow registrationWnd = new RegistrationWindow();

            registrationWnd.Closing += (s, e) =>
            {
                WindowClosed?.Invoke(p, new EventArgs());
            };
            
            registrationWnd.ShowDialog();
        }

        private bool CanRegistration(object p) => true;
        
        public ICommand Cancel { get; }

        private async void OnCancel(object p) => WindowClosed?.Invoke(p, new System.EventArgs());

        private bool CanCancel(object p) => true;

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
