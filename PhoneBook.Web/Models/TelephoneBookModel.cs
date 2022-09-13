using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Web.Models
{
    public class TelephoneBookModel
    {
        public ulong ID { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        [Required]
        public string NumberPhone { get; set; }

        public string Address { get; set; }
    }
}
