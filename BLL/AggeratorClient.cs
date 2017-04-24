using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BO;
using Newtonsoft.Json;

namespace BLL
{
    public class AggeratorClient : IAggeratorClient
    {
        public async Task<T> GetAggergatorResult<T>(string baseAddress, string location)
        {
            // create a new client to process request
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // wait for response
            HttpResponseMessage response = await client.GetAsync(location);
            // check valid response
            if (response.IsSuccessStatusCode)
            {
                // get response stream
                var stream = await response.Content.ReadAsStreamAsync();
                stream.Position = 0;
                // read incoming data
                var data = new StreamReader(stream).ReadToEnd();
                // deserialize data
                var result = JsonConvert.DeserializeObject<T>(data);

                return result;
 
            }
            else
            {
                throw new Exception("ERROR");

            }
        }
    }
}
