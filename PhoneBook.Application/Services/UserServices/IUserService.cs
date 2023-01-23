using PhoneBook.Domain.Entity;
using PhoneBook.Infrastucture.Data.DTO;

namespace PhoneBook.Application.Services.UserServices
{
    public interface IUserService
    {
        User Get(ulong ID);
        User Update(User user);
        User Delete(ulong id);
        User Create(User user);
        TokenDTO AuthUser(string login, string password, string privateKey);
    }
}
