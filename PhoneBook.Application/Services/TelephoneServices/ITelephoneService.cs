using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services.TelephoneServices
{
    public interface ITelephoneService
    {
        List<TelephoneBook> Search(string name);
        List<TelephoneBook> GetAll();
        TelephoneBook Get(ulong ID);
        TelephoneBook Update(TelephoneBook telephoneBook);
        TelephoneBook Delete(ulong id);
        IEnumerable<TelephoneBook> RangeDelete(List<ulong> ids);
        TelephoneBook Create(TelephoneBook telephoneBooks);
    }
}
