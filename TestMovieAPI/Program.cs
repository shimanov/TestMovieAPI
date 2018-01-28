using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestMovieAPI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имя фильма");
            string query = Console.ReadLine();
            Console.WriteLine("Вот что мы смогли найти:");
            const string lang = "ru";
            const string key = "8885138dda6fdebc5b0e3dc327da6a91";

            SearchMoviesAsync(key, query, lang).Wait();

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="searchMovie"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        private static async Task SearchMoviesAsync(string apiKey,
            string searchMovie, string lang)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringResult = client.GetStringAsync("https://api.themoviedb.org/3/search/movie?api_key="
                                                     + apiKey
                                                     + "&language="
                                                     + lang
                                                     + "&query="
                                                     + searchMovie);
            var resultTask = await stringResult;

            var array = JArray.Parse(JObject.Parse(resultTask).SelectToken("results").ToString());
            foreach (var a in array)
            {
                var id = JObject.Parse(a.ToString()).SelectToken("id");
                var title = JObject.Parse(a.ToString()).SelectToken("title");
                var releaseDate = JObject.Parse(a.ToString()).SelectToken("release_date");
                var overview = JObject.Parse(a.ToString()).SelectToken("overview");

                Console.WriteLine($"ID: {id}\nTitle: {title}\nRelease date: {releaseDate}\nOverview: {overview}\n");
            }
        }
    }
}
