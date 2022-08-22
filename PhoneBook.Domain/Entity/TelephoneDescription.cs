namespace PhoneBook.Domain.Entity
{
    public class TelephoneDescription
    {
        public TelephoneDescription(ulong iD, string lastName, string firstName, string surName)
        {
            ID = iD;
            LastName = lastName;
            FirstName = firstName;
            SurName = surName;
        }

        public ulong ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
