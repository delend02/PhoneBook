namespace PhoneBook.API.Models
{
    public class Registration
    {
        public class Request
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public int Role { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
        }
    }
}
