using PhoneBook.Domain.Entity;
using System.Windows;

namespace PhoneBook.WPF.Views.WindowViews
{
    public partial class EditWindow : Window
    {
        public EditWindow(TelephoneBook phone)
        {
            Phone = phone;
            InitializeComponent();
        }

        public TelephoneBook Phone
        {
            get { return (TelephoneBook)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(TelephoneBook), typeof(EditWindow), new PropertyMetadata(new TelephoneBook()));
    }
}
