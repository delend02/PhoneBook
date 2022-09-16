using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services
{
    public interface ITelephoneServices
    {
        List<TelephoneBook> Search(string name);
        List<TelephoneBook> GetAll();
        TelephoneBook Get(ulong ID);
        void Delete(ulong id);
        void RangeDelete(List<ulong> ids);
        void Create(TelephoneBook telephoneBooks);
    }
}
