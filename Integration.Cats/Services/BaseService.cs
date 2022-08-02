using Integration.Cats.Api.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Cats.Services
{
    /// <summary>
    /// Base Service of the Cats API. Contains all of the endpoints
    /// </summary>
    public class BaseService
    {
        protected Configurations Configurations;

        public BaseService(IOptions<Configurations> configurations)
        {
            Configurations = configurations.Value;
        }

        /// <summary>
        /// Creates a GET request to the url
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected internal async Task<string> Get(string endpoint)
        {
            try
            {
                var url = $"{Configurations.CatsApi.Url}{Configurations.CatsApi.Version}/{endpoint}";
                HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Add("x-api-key", Configurations.CatsApi.Secret);
                    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                    var response = await client.GetAsync(url);
                    var result = response.Content.ReadAsStringAsync().Result;

                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
