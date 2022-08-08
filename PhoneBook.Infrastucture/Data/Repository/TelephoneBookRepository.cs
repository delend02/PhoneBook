using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;

namespace PhoneBook.Infrastucture.Data.Repository
{
    public class TelephoneBookRepository : IRepository<TelephoneBook>
    {
        private PhoneContext _db;

        public TelephoneBookRepository()
        {

        }

        public void Create(TelephoneBook item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TelephoneBook Find(Func<TelephoneBook, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TelephoneBook Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TelephoneBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TelephoneBook item)
        {
            throw new NotImplementedException();
        }
    }
}
