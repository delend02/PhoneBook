using PhoneBook.WPF.ViewModels.Command;
using System.Windows.Input;

namespace PhoneBook.WPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            Add = new LamdaCommand(OnAdd, CanAdd);
            Search = new LamdaCommand(OnSearch, CanSearch);
            Table = new LamdaCommand(OnTable, CanTable);
        }

        #region Button
        public ICommand Add { get; }

        private void OnAdd(object p)
        {

        }

        private bool CanAdd(object p) => true;
        
        public ICommand Search { get; }

        private void OnSearch(object p)
        {

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
    }
}
