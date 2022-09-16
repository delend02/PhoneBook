using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;

namespace PhoneBook.Infrastucture.Data.Repository
{
    public class TelephoneBookRepository : IRepository<TelephoneBook>
    {
        private PhoneContext _db;

        public TelephoneBookRepository(PhoneContext db)
        {
            _db = db;
        }

        public void Create(TelephoneBook item)
        {
            _db.Books.Add(item);
        }

        public void Delete(ulong id)
        {
            var books = _db.Books.Find(id);
            if (books is not null)
                _db.Books.Remove(books);
        }

        public TelephoneBook Find(Func<TelephoneBook, bool> predicate)
        {
            return _db.Books.Find(predicate);
        }

        public IEnumerable<TelephoneBook> GetByID(List<ulong> ids)
        {

            IEnumerable<TelephoneBook> telephoneBooks = (from book in _db.Books
                                                         where ids.Contains(book.ID)
                                                         select book).ToList();

            return telephoneBooks;
        }

        public TelephoneBook GetByID(ulong id)
        {
            var result = _db.Books.Find(id);
            return result;
        }

        public IEnumerable<TelephoneBook> GetAll()
        {
            var result = _db.Books;
            return result;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(TelephoneBook item)
        {
            _db.Books.Update(item);
        }

        public IEnumerable<TelephoneBook> FindAll(Func<TelephoneBook, bool> predicate)
        {
            var result = _db.Books.Where(predicate).ToList();
            return result;
        }

        public void DeleteRange(IEnumerable<TelephoneBook> books)
        {
            _db.Books.RemoveRange(books);
        }
    }
}
