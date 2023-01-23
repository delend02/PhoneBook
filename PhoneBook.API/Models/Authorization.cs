namespace PhoneBook.API.Models
{
    public class Authorization
    {
        public class Request
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
        }
    }
}
