using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services.UserServices
{
    public interface IUserService
    {
        User Get(ulong ID);
        User Update(User user);
        User Delete(ulong id);
        User Create(User user);
        string AuthUser(string login, string password, string privateKey);
    }
}
