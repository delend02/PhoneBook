using PhoneBook.Domain.Entity;
using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels.Command;
using PhoneBook.WPF.Views.WindowViews;
using System;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels.WindowViewModel
{
    internal class MainWindowViewModel : WindowViewModelBase
    {
        public MainWindowViewModel() : base()
        {
            Add = new LamdaCommand(OnAdd, CanAdd);
            Search = new LamdaCommand(OnSearch, CanSearch);
            Table = new LamdaCommand(OnTable, CanTable);
            Exit = new LamdaCommand(OnExit, CanExit);
            Enter = new LamdaCommand(OnEnter, CanEnter);
        }

        #region Button
        public ICommand Exit { get; }

        private void OnExit(object p) => WindowClosed?.Invoke(p, new EventArgs());

        private bool CanExit(object p) => true;

        public ICommand Add { get; }

        private void OnAdd(object p) => GoToPage(AddPageSource);
      
        private bool CanAdd(object p) => true;

        public ICommand Search { get; }

        private void OnSearch(object p) => GoToPage(SearchPageSource);

        private bool CanSearch(object p) => true;

        public ICommand Table { get; }

        private void OnTable(object p) => GoToPage(ContactPage);

        private bool CanTable(object p) => true;
        
        public ICommand Enter { get; }

        private void OnEnter(object p)
        {
            AuthorizationWindow authorizationWnd = new();
            authorizationWnd.ShowDialog();
        }

        private bool CanEnter(object p) => true;
        #endregion

        private string _textHeader;
        public string TextHeader
        {
            get => _textHeader;
            set => Set(ref _textHeader, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _typeLogin;
        public string TypeLogin
        {
            get => _typeLogin;
            set => Set(ref _typeLogin, value);
        }

        private string _pathImage;
        public string PathImage 
        { 
            get => _pathImage; 
            set => Set(ref _pathImage, value); 
        }

        private User _user;
        public User User 
        {
            get => _user;
            set => Set(ref _user, value);
        }
    }
}
