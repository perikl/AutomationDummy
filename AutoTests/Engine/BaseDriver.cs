using Microsoft.Extensions.Configuration;

namespace ToptalTestAutomation.Engine
{
    public class BaseDriver
    {
        protected IConfigurationRoot config;

        public IConfigurationRoot GetConfig()
        {
            return config;
        }

        public BaseDriver()
        {            
            config = new ConfigurationBuilder().AddJsonFile(@"Engine\Config\config.json").Build();
        }
    }
}
