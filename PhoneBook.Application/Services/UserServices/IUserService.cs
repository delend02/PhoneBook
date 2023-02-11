using PhoneBook.Domain.Entity;
using PhoneBook.Infrastucture.Data.DTO;

namespace PhoneBook.Application.Services.UserServices
{
    public interface IUserService
    {
        User GetByID(ulong ID);
        User Get(User user);
        User Update(User user);
        User Delete(ulong id);
        string Create(User user, string privateKey);
        TokenDTO AuthUser(string login, string password, string privateKey);
    }
}
