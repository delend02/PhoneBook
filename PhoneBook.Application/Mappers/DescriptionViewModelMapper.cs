using PhoneBook.Application.ViewModel;
using PhoneBook.Domain.Entity;

namespace PhoneBook.Application.Mappers
{
    public class DescriptionViewModelMapper
    {
        public IEnumerable<DescriptionViewModel> ConstructFromListOfEntities(IEnumerable<TelephoneBook> books)
        {
            var descriptionViewModel = books.Select(item => new DescriptionViewModel
            {
                ID = item.ID,
                Address = item.Address,
                SurName = item.SurName,
                FirstName = item.FirstName,
                LastName = item.LastName,
                NumberPhone = item.NumberPhone
            }
            );

            return descriptionViewModel;
        }

        public DescriptionViewModel ConstructFromEntity(TelephoneBook book)
        {
            return new DescriptionViewModel
            {
                ID = book.ID,
                Address = book.Address,
                SurName = book.SurName,
                FirstName = book.FirstName,
                LastName = book.LastName,
                NumberPhone = book.NumberPhone
            };
        }
    }
}
