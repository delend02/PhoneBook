using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services
{
    public class TelephoneServices : ITelephoneServices
    {
        public Task<IEnumerable<TelephoneBook>> SearchTelephone(string phoneNumber)
        {
            return null;
        }
    }
}
