using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook.WPF.ViewModels
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        const string SourcePathPage = "../PageViews";
        protected const string AddPageSource = $"{SourcePathPage}/AddPage.xaml";
        protected string SearchPageSource = $"{SourcePathPage}/SearchPage.xaml";


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));


        protected virtual bool Set<T>(ref T fieled, T value, [CallerMemberName] string? PropertyName = null)
        {
            if (Equals(fieled, value)) return false;

            fieled = value;

            OnPropertyChanged(PropertyName);

            return true;
        }

        private string _sourcePage;
        public string SourcePage
        {
            get => _sourcePage;
            set => Set(ref _sourcePage, value);
        }

        protected void GoToPage(string source)
        {
            SourcePage = source;
        }
    }
}
