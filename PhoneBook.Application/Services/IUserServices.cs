using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Services
{
    public interface IUserServices
    {
        User Get(ulong ID);
        void Update(User user);
        void Delete(ulong id);
        void Create(User user);
    }
}
