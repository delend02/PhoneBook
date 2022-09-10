using PhoneBook.Application.ViewModel;
using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Mappers
{
    public class TelephoneViewModelMapper
    {
        public IEnumerable<TelephoneViewModel> ConstructFromListOfEntities(IEnumerable<TelephoneBook> books)
        {
            var telephoneViewModel = books.Select(item => new TelephoneViewModel
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                NumberPhone = item.NumberPhone
            }
            );

            return telephoneViewModel;
        }

        public TelephoneViewModel ConstructFromEntity(TelephoneBook book)
        {
            return new TelephoneViewModel
            {
                FirstName = book.FirstName,
                NumberPhone = book.NumberPhone,
                LastName = book.LastName
            };
        }
    }
}
