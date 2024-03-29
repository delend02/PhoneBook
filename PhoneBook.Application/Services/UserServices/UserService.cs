﻿using Microsoft.Extensions.Logging;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.DTO;
using System.Security.Cryptography;
using System.Text;

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

        public string Create(User user, string privateKey)
        {
            var userHash = user;
            HashPasswordToSha256(userHash.Password);
            var result = new TokenDTO();
            var hasNeedToAdd = _db.Create(userHash);
            _db.Save();

            if (hasNeedToAdd)
                result = AuthUser(user.Login, user.Password, privateKey);

            return result?.Token;
        }

        public User Delete(ulong id)
        {
            _db.Delete(id);
            _db.Save();
            return null;
        }

        public User GetByID(ulong id)
        {
            return _db.GetByID(id);
        }
        
        public TokenDTO AuthUser(string login, string password, string rsaKey)
        {
            TokenDTO token = null;
            var passHash = HashPasswordToSha256(password);
            var resultUser = _db.Get(new User { Login = login, Password = passHash });

            if (resultUser is not null && resultUser.Password == passHash)
            {
                var claims = new Dictionary<string, object>() 
                {
                    { "id", resultUser.ID }
                };

                var tokenStr = new Manager(rsaKey).CreateToken(claims);

                token = new TokenDTO { Token = tokenStr };
            }

            return token;
        }

        public User Update(User user)
        {
            _db.Update(user);
            _db.Save();
            return user;
        }

        private string HashPasswordToSha256(string password)
        {
            SHA256 sha256 = new SHA256Managed();
            var pass = sha256.ComputeHash(new UTF8Encoding().GetBytes(password));
            var resultPass = BitConverter.ToString(pass);
            return resultPass;
        }

        public User Get(User user)
        {
            var result = _db.Get(user);
            return result;
        }
    }
}
