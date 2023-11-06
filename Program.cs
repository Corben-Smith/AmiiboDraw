using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FastConsole;
using ImageToConsole;
using System.Drawing;

namespace APITest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();

            APIClient client = new APIClient();

            string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString();

            RootAmiibo amiibos;
            bool run = true;

            do
            {

                Console.WriteLine("Give me the name of the character");


                //getting the json from the api
                string temp = await client.GetApiDataAsync(Console.ReadLine());

                //making an amiibo object from the json given
                amiibos = JsonConvert.DeserializeObject<RootAmiibo>(temp);

                if (amiibos.amiibo.Length == 0)
                {
                    Console.WriteLine("You did not enter a valid name. Please try again.");
                }
                else
                {
                    run = false;
                }
            } while(run);


            Console.WriteLine($"Which version of {amiibos.amiibo[0].Name} would you like to display?");
            for (int i = 0; i < amiibos.amiibo.Length; i++)
            {
                Console.WriteLine($"Version {i + 1}\t Game: {amiibos.amiibo[i].GameSeries}\tAmiibo Series: {amiibos.amiibo[i].AmiiboSeries}");

            }

            Amiibo amiibo = new Amiibo();
            bool tp = int.TryParse(Console.ReadLine(), out int temprr);
            if (tp && temprr <= amiibos.amiibo.Length)
            {
                
                amiibo = amiibos.amiibo[temprr - 1];
            }
            else
            {
                await Console.Out.WriteLineAsync("You did not give a valid input, so you are getting version 1.");
                amiibo = amiibos.amiibo[0];
            }

            Console.WriteLine(amiibo);

            string path = root + @$"\images\{amiibo.Name}.png";


            await Console.Out.WriteLineAsync(path);
            await client.DownloadImageAsync(amiibo, path);

            Bitmap bmp = new Bitmap(path);

            FConsole.Clear();
            while (true)
            {
                ConsoleImage.DrawImage(bmp, 2, 10);
                FConsole.Clear();
            }
        }
    }
}


