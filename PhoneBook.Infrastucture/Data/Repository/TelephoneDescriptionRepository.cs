using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;

namespace PhoneBook.Infrastucture.Data.Repository
{
    public class TelephoneDescriptionRepository : IRepository<TelephoneDescription>
    {
        private PhoneContext _db;

        public TelephoneDescriptionRepository()
        {

        }

        public void Create(TelephoneDescription item)
        {
            _db.Descriptions.Add(item);
        }

        public void Delete(int id)
        {
            var books = _db.Books.Find(id);
            if (books is not null)
                _db.Books.Remove(books);
        }

        public TelephoneDescription Find(Func<TelephoneDescription, bool> predicate)
        {
            return _db.Descriptions.Find(predicate);
        }

        public TelephoneDescription GetByID(int id)
        {
            var result = _db.Descriptions.Find(id);
            return result;
        }

        public IEnumerable<TelephoneDescription> GetAll()
        {
            var result = _db.Descriptions.ToList();
            return result;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(TelephoneDescription item)
        {
            _db.Descriptions.Update(item);
        }
    }
}
