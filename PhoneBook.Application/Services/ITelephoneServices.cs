using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services
{
    public interface ITelephoneServices
    {
        IEnumerable<TelephoneBook> Search(string name);
        IEnumerable<TelephoneBook> GetAll();
        TelephoneBook Get(ulong ID);
        void Delete(ulong id);
        void Create(TelephoneBook telephoneBooks);
    }
}
