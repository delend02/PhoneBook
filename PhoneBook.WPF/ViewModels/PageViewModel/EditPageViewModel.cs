using PhoneBook.ApiInterLayer.Models;
using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.PageViewModel
{
    internal class EditPageViewModel : PageViewModelBase
    {
        public EditPageViewModel()
        {
            LoadPhone();
            Save = new LamdaCommand(OnSave, CanSave);
        }

        private void LoadPhone()
        {
            FirstName = Phone.FirstName;
            LastName = Phone.LastName;
            SurName = Phone.SurName;
            NumberPhone = Phone.NumberPhone;
            Adress = Phone.Address;
        }

        #region Button
        public ICommand Save { get; }

        private async void OnSave(object p)
        {
            var phone = new TelephoneBook
            {
                FirstName = FirstName,
                LastName = LastName,
                SurName = SurName,
                NumberPhone = NumberPhone,
                Address = Adress
            };

            var resultPhone = await PhoneApi.UpdateAsync(phone);

            var textMessage = string.Empty;

            if (resultPhone is not null)
                textMessage = $"Пользователь {resultPhone.FirstName} {resultPhone.LastName} успешно обновлён";
            else
                textMessage = $"Возникла проблема при обновлении";

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

        private TelephoneBook _phone;
        public TelephoneBook Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
    }
}
