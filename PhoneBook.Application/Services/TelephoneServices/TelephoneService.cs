using Microsoft.Extensions.Logging;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Application.Services.TelephoneServices
{
    public class TelephoneService : ITelephoneService
    {
        private readonly IRepository<TelephoneBook> _db;
        private readonly ILogger<TelephoneService> _logger;

        public TelephoneService(IRepository<TelephoneBook> db, ILogger<TelephoneService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public TelephoneBook Get(ulong ID)
        {
            return _db.GetByID(ID);
        }

        public List<TelephoneBook> GetAll()
        {
            return _db.GetAll().ToList();
        }

        public TelephoneBook Create(TelephoneBook telephoneBooks)
        {
            _db.Create(telephoneBooks);
            _db.Save();
            return telephoneBooks;
        }

        public TelephoneBook Update(TelephoneBook telephoneBook)
        {
            _db.Update(telephoneBook);
            return telephoneBook;
        }

        public TelephoneBook Delete(ulong id)
        {
            _db.Delete(id);
            _db.Save();
            return null;
        }

        public IEnumerable<TelephoneBook> RangeDelete(List<ulong> ids)
        {
            var result = _db.GetByID(ids);
            _db.DeleteRange(result);
            _db.Save();
            return null;
        }

        public List<TelephoneBook> Search(string name)
        {
            var result = _db.FindAll(book => book.FirstName.Contains(name)).ToList();
            return result;
        }
    }
}
