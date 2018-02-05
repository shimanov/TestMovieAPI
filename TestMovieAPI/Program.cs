using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestMovieAPI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите название фильма:");
            string query = Console.ReadLine();
            if (query != string.Empty)
            {
                Console.WriteLine("\nВот что мы смогли найти:\n");
                //Язык выдачи результата поиска
                const string lang = "ru";
                //APIKey
                const string key = "8885138dda6fdebc5b0e3dc327da6a91";

                SearchMoviesAsync(key, query, lang).Wait();
            }
            else
            {
                Console.WriteLine("Название фильма не введено");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод результата поиска
        /// </summary>
        /// <param name="apiKey">ApikKey для доступа</param>
        /// <param name="searchMovie">Ключевое слово для поиска</param>
        /// <param name="lang">Язык выдачи результата</param>
        /// <returns></returns>
        private static async Task SearchMoviesAsync(string apiKey,
            string searchMovie, string lang)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringResultAsync = await client.GetStringAsync($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language={lang}&query={searchMovie}").ConfigureAwait(false);

            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(stringResultAsync);
            if (rootobject.TotalResults == 0)
            {
                Console.WriteLine("По вашему запросу ничего не найдено");
            }
            else
            {
                foreach (var movie in rootobject.Results)
                {
                    Console.WriteLine($"ID: {movie.Id}\nTitle: {movie.Title}\nRelease date: {movie.ReleaseDate}\nOverview: {movie.Overview}\n");
                }
            }
        }
    }
}
