using PhoneBook.Domain.Entity;

namespace PhoneBook.ApiInterLayer.Models
{
    public sealed class PhoneApi
    {
        public static async Task<TelephoneBook> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Phone}/{id}";
            var result = await Api.Client.GetAsync<TelephoneBook>(endpoints, cancellationToken);
            return result;
        }

        public static async Task<TelephoneBook> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Phone;
            var result = await Api.Client.GetAsync<TelephoneBook>(endpoints, cancellationToken);
            return result;
        }

        public static async Task<TelephoneBook> CreateAsync(TelephoneBook telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Phone;
            var result = await Api.Client.PostAsJsonAsync<TelephoneBook, TelephoneBook>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public static async Task<TelephoneBook> UpdateAsync(TelephoneBook telephoneBook, CancellationToken cancellationToken = default)
        {
            var endpoints = Endpoints.Phone;
            var result = await Api.Client.PutAsJsonAsync<TelephoneBook, TelephoneBook>(endpoints, telephoneBook, cancellationToken);
            return result;
        }

        public static async Task<TelephoneBook> DeleteAsync(ulong id, CancellationToken cancellationToken = default)
        {
            var endpoints = $"{Endpoints.Phone}/{id}";
            var result = await Api.Client.DeleteAsync<TelephoneBook>(endpoints, cancellationToken);
            return result;
        }
    }
}
