using System.Net.Http;

namespace customers_management_app.MainService
{
    public class ApiService
    {
        public HttpClient Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7028/api/");
            return client;
        }
    }
}
