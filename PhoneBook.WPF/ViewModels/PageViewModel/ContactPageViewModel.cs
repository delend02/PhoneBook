using PhoneBook.ApiInterLayer.Models;
using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using PhoneBook.WPF.Views.PageViews;
using System;
using System.Collections.Generic;
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
            var resultPhone = await PhoneApi.GetAllAsync() ?? new List<TelephoneBook>();
            ListOfContact = new ObservableCollection<TelephoneBook>(resultPhone);
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
            EditPage editPage = new EditPage()
            {
                Phone = SelectePhone
            };
        }

        private bool CanEditPhone(object p) => true;

        public ICommand AddNewPhone { get; }

        private void OnAddNewPhone(object p)
        {
            GoToPage(AddPageSource);
        }

        private bool CanAddNewPhone(object p) => true;
        #endregion

    }
}
