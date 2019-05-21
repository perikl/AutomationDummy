using RestSharp;

namespace ToptalTestAutomation.Engine
{
    public class ClientApi : BaseDriver
    {
        private static ClientApi _instance;
        public RestClient Client { get; set; }        

        private ClientApi()
        {
            Client = new RestClient(config["urlAPI"]);            
        }

        public static ClientApi GetInstance()
        {
            return _instance ?? (_instance = new ClientApi());
        }
    }
}
