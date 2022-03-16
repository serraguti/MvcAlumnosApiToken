using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MvcAlumnosApiToken.Services
{
    public class ServiceApiToken
    {
        private string UrlApi;

        public ServiceApiToken(string urlapi)
        {
            this.UrlApi = urlapi;
        }

        public async Task<string> GetTokenAsync(string curso)
        {
            string request = "/api/alumnoskeys/token/" + curso;
            using (WebClient client = new WebClient())
            {
                client.Headers["content-type"] = "application/json";

            }
        }
    }
}
