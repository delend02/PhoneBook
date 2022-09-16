using PhoneBook.Domain.Entity;
using PhoneBook.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Web.Mappers
{
    public static class TelephoneBookMappers
    {
        public static TelephoneBook ConstructToEntities(this TelephoneBookModel telephoneBookModel)
        {
            return new TelephoneBook
            {
                Address = telephoneBookModel.Address,
                FirstName = telephoneBookModel.FirstName,
                LastName = telephoneBookModel.LastName,
                NumberPhone = telephoneBookModel.NumberPhone,
                SurName = telephoneBookModel.SurName
            };
        }

        public static ICollection<TelephoneBookModel> ConstructToListModels(this IEnumerable<TelephoneBook> telephoneBook)
        {
            var books = telephoneBook.Select(item => new TelephoneBookModel
            {
                ID = item.ID,
                SurName = item.SurName,
                Address = item.Address,
                FirstName = item.FirstName,
                LastName = item.LastName,
                NumberPhone = item.NumberPhone
            });

            var booksResult = books.ToList();

            return booksResult;
        }

        public static TelephoneBookModel ConstructToModels(this TelephoneBook telephoneBook)
        {
            return new TelephoneBookModel
            {
                Address = telephoneBook.Address,
                FirstName = telephoneBook.FirstName,
                LastName = telephoneBook.LastName,
                NumberPhone = telephoneBook.NumberPhone,
                SurName = telephoneBook.SurName
            };
        }
    }
}