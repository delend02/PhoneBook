﻿using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;

namespace PhoneBook.Infrastucture.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private PhoneContext _db;

        public UserRepository(PhoneContext db)
        {
            _db = db;
        }

        public bool Create(User item)
        {
            var user = Get(item);

            var result = user == null;

            if (result)
                _db.User.Add(item);

            return result;
        }

        public void Delete(ulong id)
        {
            var user = _db.User.Find(id);
            if (user is not null)
                _db.User.Remove(user);
        }

        public void DeleteRange(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public User Find(Func<User, bool> predicate)
        {
            return _db.User.Find(predicate);
        }

        public IEnumerable<User> FindAll(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var result = _db.User;
            return result;
        }

        public User GetByID(ulong id)
        {
            var result = _db.User.Find(id);
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
            _db.User.Update(item);
        }

        public User Get(User entity)
        {
            var result = from user in _db.User
                         where user.Login.Equals(entity.Login.Trim())
                         select user;
            return result?.FirstOrDefault();
        }

        public void Dispose()
        {

        }
    }
}
