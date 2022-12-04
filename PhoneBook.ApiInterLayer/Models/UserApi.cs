using PhoneBook.Domain.Entity;

namespace PhoneBook.ApiInterLayer.Models
{
    public class UserApi
    {
        public async Task<User> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/{id}";
            var result = await Api.Client.GetAsync<User>(endpoints, cancellationToken);
            return result;
        }

        public async Task<User> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Users;
            var result = await Api.Client.GetAsync<User>(endpoints, cancellationToken);
            return result;
        }

        public async Task<User> CreateAsync(User telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Users;
            var result = await Api.Client.PostAsJsonAsync<User, User>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public async Task<User> UpdateAsync(User telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Users;
            var result = await Api.Client.PutAsJsonAsync<User, User>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public async Task<User> DeleteAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/{id}";
            var result = await Api.Client.DeleteAsync<User>(endpoints, cancellationToken);
            return result;
        }
    }
}
