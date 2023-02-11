using PhoneBook.Domain.Entity;
using PhoneBook.Infrastucture.Data.DTO;

namespace PhoneBook.ApiInterLayer.Models
{
    public class UserApi
    {
        public static async Task<User> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/{id}";
            var result = await Api.Client.GetAsync<User>(endpoints, cancellationToken);
            return result;
        }

        public static async Task<User> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Users;
            var result = await Api.Client.GetAsync<User>(endpoints, cancellationToken);
            return result;
        }

        public static async Task<User> CreateAsync(User telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/registration";
            var result = await Api.Client.PostAsJsonAsync<User, User>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public static async Task<User> UpdateAsync(User telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Users;
            var result = await Api.Client.PutAsJsonAsync<User, User>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public static async Task<User> DeleteAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/{id}";
            var result = await Api.Client.DeleteAsync<User>(endpoints, cancellationToken);
            return result;
        }
        
        public static async Task<string> AuthUser(string login, string password, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/auth";
            var user = new AuthDTO { Login = login, Password = password }; 
            var result = await Api.Client.PostAsJsonAsync<AuthDTO, TokenDTO>(endpoints, user, cancellationToken);
            return result.Token;
        }

        public static async Task<User> GetByLogin(string login, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Users}/login/{login}";
            var result = await Api.Client.GetAsync<User>(endpoints, cancellationToken);
            return result;
        }
    }
}
