using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Application.Services
{
    public class UserServices : IUserServices
    {
        private IRepository<User> _db;

        public UserServices(IRepository<User> db)
        {
            _db = db;
        }

        public void Create(User user)
        {
            _db.Create(user);
        }

        public void Delete(ulong id)
        {
            _db.Delete(id);
        }

        public User Get(ulong id)
        {
            return _db.GetByID(id);
        }

        public void Update(User user)
        {
            _db.Update(user);
        }
    }
}
