using PhoneBook.Domain.Entity;
using System.Net.Http;

namespace PhoneBook.WPF.Service
{
    internal static class Clients
    {
        internal static User User { get; set; }
        internal static HttpClient Client { get; set; } = new HttpClient();
    }
}
