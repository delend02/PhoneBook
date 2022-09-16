using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;

namespace PhoneBook.Infrastucture.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private UserContext _db;

        public UserRepository(UserContext db)
        {
            _db = db;
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Delete(ulong id)
        {
            var user = _db.Users.Find(id);
            if (user is not null)
                _db.Users.Remove(user);
        }

        public void DeleteRange(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public User Find(Func<User, bool> predicate)
        {
            return _db.Users.Find(predicate);
        }

        public IEnumerable<User> FindAll(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var result = _db.Users;
            return result;
        }

        public User GetByID(ulong id)
        {
            var result = _db.Users.Find(id);
            return result;
        }

        public IEnumerable<User> GetByID(List<ulong> id)
        {
            throw new NotImplementedException();
        }

        public void RangeDelete(IEnumerable<User> ids)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User item)
        {
            _db.Users.Update(item);
        }
    }
}
