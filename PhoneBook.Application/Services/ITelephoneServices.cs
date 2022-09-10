using PhoneBook.Application.ViewModel;

namespace PhoneBook.Application.Services
{
    public interface ITelephoneServices
    {
        Task<IEnumerable<DescriptionViewModel>> GetAll();
        Task<TelephoneViewModel> GetById(ulong id);
        Task<TelephoneViewModel> Create(TelephoneViewModel taskViewModel);
        Task Delete(ulong id);
    }
}
