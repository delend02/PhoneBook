using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.ViewModel
{
    public class DescriptionViewModel
    {
        public ulong ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
    }
}
