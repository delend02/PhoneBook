﻿namespace PhoneBook.Domain.Entity
{
    public class TelephoneBook
    {
        public TelephoneBook(ulong iD, string lastName, string firstName, string surName, string numberPhone, string address, TelephoneDescription description)
        {
            ID = iD;
            LastName = lastName;
            FirstName = firstName;
            SurName = surName;
            NumberPhone = numberPhone;
            Address = address;
            Description = description;
        }

        public ulong ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public TelephoneDescription Description { get; set; }
    }
}
