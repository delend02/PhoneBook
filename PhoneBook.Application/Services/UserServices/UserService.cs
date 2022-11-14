using Microsoft.Extensions.Logging;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _db;
        private readonly ILogger<UserService> _logger;

        public UserService(IRepository<User> db, ILogger<UserService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public User Create(User user)
        {
            _db.Create(user);
            _db.Save();
            return user;
        }

        public User Delete(ulong id)
        {
            _db.Delete(id);
            _db.Save();
            return null;
        }

        public User Get(ulong id)
        {
            return _db.GetByID(id);
        }

        public User Update(User user)
        {
            _db.Update(user);
            _db.Save();
            return user;
        }
    }
}
