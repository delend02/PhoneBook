using PhoneBook.Application.Mappers;
using PhoneBook.Application.ViewModel;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Application.Services
{
    public class TelephoneServices : ITelephoneServices
    {
        private readonly TelephoneViewModelMapper _telephoneViewModelMapper;
        private readonly IRepository<TelephoneBook> _telephoneRepository;

        public TelephoneServices(TelephoneViewModelMapper telephoneViewModelMapper, IRepository<TelephoneBook> telephoneRepository)
        {
            _telephoneViewModelMapper = telephoneViewModelMapper;
            _telephoneRepository = telephoneRepository;
        }

        public Task<TelephoneViewModel> Create(TelephoneViewModel taskViewModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DescriptionViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TelephoneViewModel> GetById(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
