using PhoneBook.WPF.Service;
using PhoneBook.WPF.ViewModels;
using System.Windows;

namespace PhoneBook.WPF.Views.WindowViews
{   
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();


            (this.DataContext as WindowViewModelBase).WindowClosed += (s, e) =>
            {
                if (Clients.User?.Password is not null)
                    DialogResult = true;

                this.Close();
            };
        }
    }
}
