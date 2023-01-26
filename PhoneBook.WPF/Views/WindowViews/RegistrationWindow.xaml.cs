using PhoneBook.WPF.ViewModels;
using System.Windows;

namespace PhoneBook.WPF.Views.WindowViews
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            (this.DataContext as WindowViewModelBase).WindowClosed += (s, e)
                => this.Close();
        }
    }
}
