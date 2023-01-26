namespace PhoneBook.ApiInterLayer
{
    public class Api
    {
        private const string baseUrl = "https://localhost:5001/";

        internal static DefaultHttpClient Client { get; private set; } = new DefaultHttpClient(new Uri(baseUrl));

        public static void UseToken(string token) => Client = new DefaultHttpClient(new Uri(baseUrl), token);
    }
}
