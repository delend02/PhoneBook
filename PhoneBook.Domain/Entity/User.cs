namespace PhoneBook.Domain.Entity
{
    public class User
    {
        public ulong ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
