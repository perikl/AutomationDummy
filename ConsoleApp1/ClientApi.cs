using RestSharp;

namespace KBCIBack
{
    class ClientApi
    {
        private static ClientApi _instance;
        public RestClient Client { get; set; }        

        private ClientApi()
        {
            Client = new RestClient("");            
        }

        public static ClientApi GetInstance()
        {
            return _instance ?? (_instance = new ClientApi());
        }
    }
}
