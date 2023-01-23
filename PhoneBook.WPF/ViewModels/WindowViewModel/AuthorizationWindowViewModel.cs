﻿using PhoneBook.ApiInterLayer.Models;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using System;
using System.Threading.Tasks;
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
            string textMessage = default;

            try
            {
                var result = await UserApi.AuthUser(Login, Password);

                if (result is not null)
                {
                    textMessage = "Вход выполнен";
                }
            }
            catch (Exception)
            {
                textMessage = "Неверный пароль или логин";
            }

            Notification.ShowWarning(textMessage);
        }

        private bool CanEnter(object p) => true;

        public ICommand Registration { get; }

        private async void OnRegistration(object p)
        {
            
        }

        private bool CanRegistration(object p) => true;
        
        public ICommand Cancel { get; }

        private async void OnCancel(object p)
        {
            
        }

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