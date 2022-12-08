using PhoneBook.ApiInterLayer.Models;
using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.PageViewModel
{
    internal class AddPageViewModel : PageViewModelBase
    {
        public AddPageViewModel()
        {
            Save = new LamdaCommand(OnSave, CanSave);
        }

        #region Button
        public ICommand Save { get; }

        private async void OnSave(object p)
        {
            var phone = new TelephoneBook
            {
                FirstName = FirstName,
                LastName = LastName,
                NumberPhone = NumberPhone,
                Address = Adress
            };

            var resultPhone = await PhoneApi.CreateAsync(phone);

            var textMessage = string.Empty;

            if (resultPhone is not null)
                textMessage = $"Пользователь {resultPhone.FirstName} {resultPhone.LastName} успешно добавлен";
            else
                textMessage = $"Возникла проблема при добавлении";

            Notification.ShowInformation(textMessage);
        }

        private bool CanSave(object p) => true;
        #endregion

        #region TextBox
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

        private string _surName;
        public string SurName
        {
            get => _surName;
            set => Set(ref _surName, value);
        }

        private string _adress;
        public string Adress
        {
            get => _adress;
            set => Set(ref _adress, value);
        }
        
        private string _numberPhone;
        public string NumberPhone
        {
            get => _numberPhone;
            set => Set(ref _numberPhone, value);
        }
        #endregion
    }
}
