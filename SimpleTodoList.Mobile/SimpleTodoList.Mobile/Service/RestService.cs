using System.Net.Http;

namespace SimpleTodoList.Mobile.Service
{
    public class RestService
    {
        public HttpClient client;

        public string TodoUrl { get; set; } = "https://10.0.2.2:7122/api/TodoItem"; 
        public RestService()
        {
             HttpClientHandler handler = GetInsecureHandler();
             client = new HttpClient(handler);
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
