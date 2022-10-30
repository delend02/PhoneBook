namespace PhoneBook.ApiInterLayer
{
    public class Api
    {
        public static DefaultHttpClient Client { get; private set; }

        static Api()
        {
            var baseUrl = "https://localhost:5001/";

            Client = new DefaultHttpClient(new Uri(baseUrl));
        }
    }
}
