using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Test_Branch
{
    class Program
    {

        /// <summary>
        /// The Instance of HttpClient that we will be calling upon
        /// </summary>
        static HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            PostGoogle().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// HTTP GET Request
        /// </summary>
        static async Task GET()
        {
            string URL = "https://google.com";
            string CallBack = await Client.GetStringAsync(URL);
            Console.WriteLine(CallBack);
        }

        static async Task POST()
        {
            string URL = "http://ptsv2.com";
            string Data = @"{
                              'name': 'morpheus',
                              'job': 'leader'
                           }";
            HttpContent PostData = new StringContent(Data, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync(URL, PostData);
        }

    }
}
