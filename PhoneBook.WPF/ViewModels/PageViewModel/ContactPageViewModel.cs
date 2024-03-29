﻿using PhoneBook.ApiInterLayer.Models;
using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using PhoneBook.WPF.Views.WindowViews;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.PageViewModel
{
    internal class ContactPageViewModel : PageViewModelBase
    {
        public ContactPageViewModel()
        {
            InitViewTable();
            EditPhone = new LamdaCommand(OnEditPhone, CanEditPhone);
            AddNewPhone = new LamdaCommand(OnAddNewPhone, CanAddNewPhone);
        }

        private async void InitViewTable()
        {
            try
            {
                var resultPhone = await PhoneApi.GetAllAsync();
                ListOfContact = new ObservableCollection<TelephoneBook>(resultPhone);
            }
            catch (Exception)
            {

            }
        }

        private ObservableCollection<TelephoneBook> _listOfContact;
        public ObservableCollection<TelephoneBook> ListOfContact 
        {
            get => _listOfContact; 
            set => Set(ref _listOfContact, value); 
        }

        private TelephoneBook _selectedPhone;
        public TelephoneBook SelectePhone 
        {
            get => _selectedPhone;
            set => Set(ref _selectedPhone, value);
        }

        #region Button
        public ICommand EditPhone { get; }

        private void OnEditPhone(object p)
        {
            if (!Clients.User.Role.HasFlag(Role.Admin))
            {
                Notification.ShowWarning("Редактировать может только администратор или автор");
                return;
            }

            EditWindow editWnd = new EditWindow(SelectePhone);
            editWnd.ShowDialog();
        }

        private bool CanEditPhone(object p) => true;

        public ICommand AddNewPhone { get; }

        private void OnAddNewPhone(object p)
        {
            if (!Clients.User.Role.HasFlag(Role.Admin))
            {
                Notification.ShowWarning("Добавлять телефон может только авторизованный пользователь");
                return;
            }

            GoToPage(AddPageSource);
        }

        private bool CanAddNewPhone(object p) => true;
        #endregion

    }
}
