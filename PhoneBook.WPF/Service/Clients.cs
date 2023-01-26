using PhoneBook.ApiInterLayer;
using PhoneBook.Domain.Entity;

namespace PhoneBook.WPF.Service
{
    internal static class Clients
    {
        internal static User User { get; set; } = new User();
        internal static Api Api { get; set; }
    }
}
