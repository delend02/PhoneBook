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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TelephoneDescription Find(Func<TelephoneDescription, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TelephoneDescription Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TelephoneDescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TelephoneDescription item)
        {
            throw new NotImplementedException();
        }
    }
}
