using PhoneBook.WPF.ViewModels.Command;
using System.Collections.Generic;
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
        }

        #region Button
        public ICommand Exit { get; }

        private void OnExit(object p)
        {

        }

        private bool CanExit(object p) => true;

        public ICommand Add { get; }

        private void OnAdd(object p)
        {
            GoToPage(AddPageSource);
        }

        private bool CanAdd(object p) => true;

        public ICommand Search { get; }

        private void OnSearch(object p)
        {
            GoToPage(SearchPageSource);
        }

        private bool CanSearch(object p) => true;

        public ICommand Table { get; }

        private void OnTable(object p)
        {

        }

        private bool CanTable(object p) => true;
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
    }
}
