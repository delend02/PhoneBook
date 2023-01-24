using PhoneBook.WPF.ViewModels;
using System.Windows;

namespace PhoneBook.WPF.Views.WindowViews
{   
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            (this.DataContext as WindowViewModelBase).WindowClosed += (s, e)
                => this.Close();
        }
    }
}
