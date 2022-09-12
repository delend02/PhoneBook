using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Application.Services
{
    public class TelephoneService : ITelephoneServices
    {
        private readonly IRepository<TelephoneBook> _db;

        public TelephoneService(IRepository<TelephoneBook> db)
        {
            _db = db;
        }

        public void Create(TelephoneBook telephoneBooks)
        {
            _db.Create(telephoneBooks);
            _db.Save();
        }

        public void Delete(ulong id)
        {
            _db.Delete(id);
            _db.Save();
        }

        public TelephoneBook Get(ulong ID)
        {
            return _db.GetByID(ID);
        }

        public IEnumerable<TelephoneBook> GetAll()
        {
            return _db.GetAll();
        }

        public IEnumerable<TelephoneBook> Search(string name)
        {
            var result = _db.FindAll(book => book.FirstName.Contains(name));
            return result;
        }
    }
}
