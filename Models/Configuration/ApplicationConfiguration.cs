using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.Models.Configuration
{
    public class ApplicationConfiguration
    {
        private static ApplicationConfiguration _configuration;

        public Timeouts Timeouts { get; set; }
        public Links Links { get; set; }
        public string SearchQuery { get; set; }
        public string Browser { get; set; }
        public string StringForCompare { get; set; }

        public static ApplicationConfiguration GetCongiguration()
        {
            var text = File.ReadAllText(@"appsettings.json");
            _configuration ??= JsonConvert.DeserializeObject<ApplicationConfiguration>(text);
            return _configuration;
        }
    }
}
