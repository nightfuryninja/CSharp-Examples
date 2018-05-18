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
        /// Our Instance of W
        /// </summary>
        static HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            PostGoogle().GetAwaiter().GetResult();
        }

        static async Task GetGoogle()
        {
            string URL = "https://google.com";
            string CallBack = await Client.GetStringAsync(URL);
            Console.WriteLine(CallBack);
        }

        static async Task PostGoogle()
        {
            string URL = "http://ptsv2.com/t/1ustz-1526669968/post";
            string Data = @"{
                              'name': 'morpheus',
                              'job': 'leader'
                           }";
            HttpContent PostData = new StringContent(Data, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync(URL, PostData);
            string Callback = Response.IsSuccessStatusCode.ToString();
            Console.WriteLine(Callback);

        }

    }
}
