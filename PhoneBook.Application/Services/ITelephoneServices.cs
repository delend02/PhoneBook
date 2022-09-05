using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services
{
    public interface ITelephoneServices
    {
        Task<IEnumerable<TelephoneBook>> SearchTelephone(string phoneNumber);
    }
}
