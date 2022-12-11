using PhoneBook.Domain.Entity;
using System.Windows;
using System.Windows.Controls;

namespace PhoneBook.WPF.Views.PageViews
{
    public partial class EditPage : Page
    {
        public EditPage()
        {
            InitializeComponent();
        }

        public TelephoneBook Phone
        {
            get { return (TelephoneBook)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(TelephoneBook), typeof(EditPage), new PropertyMetadata(new TelephoneBook()));


    }
}
