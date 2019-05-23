using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Test_Branch
{
    class Program
    {

        /// <summary>
        /// Our Instance of HttpClient.
        /// </summary>
        static HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            GetJSON().GetAwaiter().GetResult();
        }

        static async Task Get()
        {
            string URL = "https://google.com";
            HttpResponseMessage Result = await Client.GetAsync(URL);
            string CallBack = await Result.Content.ReadAsStringAsync();
            Console.WriteLine(CallBack);
        }

        static async Task Post()
        {
            string URL = "http://ptsv2.com";
            string Data = @"{
                              'name': 'Harry',
                              'job': 'CEO'
                           }";
            HttpContent PostData = new StringContent(Data, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync(URL, PostData);
            string Callback = Response.IsSuccessStatusCode.ToString();
            Console.WriteLine(Callback);

        }

        static async Task GetJSON()
        {
            string URL = "";

            string Response = await Client.GetStringAsync(URL);

            dynamic Data = JsonConvert.DeserializeObject<dynamic>(Response);

            Console.WriteLine(Data.response.player_level);


        }
        
        /// <summary>
        /// Converts an object into a dictionary.
        /// </summary>
        /// <param name="obj">Object to be converted.</param>
        /// <example>x = ObjToDict(OAuthClientParameters)</example>
        /// <returns>A Dictionary<string, string></returns>
        public Dictionary<string, string> ObjToDict(object obj)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach(var propertyInfo in obj.GetType().GetProperties())
            {
                dict.Add(propertyInfo.Name, propertyInfo.GetValue(obj).ToString());
            }

            return dict;
        }
        
    }
}
