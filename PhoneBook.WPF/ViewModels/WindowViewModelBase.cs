using System;

namespace PhoneBook.WPF.ViewModels
{
    internal class WindowViewModelBase : ViewModelBase
    {
        internal Action<object, EventArgs> WindowClosed;
    }
}
