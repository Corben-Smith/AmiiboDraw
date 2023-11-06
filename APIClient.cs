using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APITest
{
    public class APIClient
    {
        private HttpClient clt;
        //public JsonSerializerOptions = new JsonSerializerOptions();

        /*
        public APIClient() 
        { 
            clt = new HttpClient();
            clt.BaseAddress = new Uri("https://www.amiiboapi.com/api/amiibo/");
        }
        */

        public async Task<string> GetApiDataAsync(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.amiiboapi.com/api/amiibo/");
                HttpResponseMessage response = await client.GetAsync($"?name={name}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public async Task DownloadImageAsync(Amiibo amiibo, string destination)
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images");

                client.BaseAddress = new Uri(amiibo.Image);
                HttpResponseMessage response = await client.GetAsync(string.Empty);

                if (response.IsSuccessStatusCode)
                {
                    using (Stream imageStream = response.Content.ReadAsStream())
                    using (FileStream fileStream = new FileStream(destination, FileMode.Create))
                    {
                        await imageStream.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    Console.WriteLine("Could Not Download: " + response.StatusCode);
                }
            }
        }
        
    }
}
