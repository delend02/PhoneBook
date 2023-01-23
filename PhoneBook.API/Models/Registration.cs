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
            public byte Role { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
            public string Exception { get; set; }
        }
    }
}
