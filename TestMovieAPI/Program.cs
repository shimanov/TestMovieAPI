﻿using Newtonsoft.Json.Linq;
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
                const string key = "";

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
            var stringResultAsync = client.GetStringAsync("https://api.themoviedb.org/3/search/movie?api_key="
                                                     + apiKey
                                                     + "&language="
                                                     + lang
                                                     + "&query="
                                                     + searchMovie).ConfigureAwait(false);
            var resultTask = await stringResultAsync;

            var array = JArray.Parse(JObject.Parse(resultTask).SelectToken("results").ToString());
            foreach (var a in array)
            {
                var id = JObject.Parse(a.ToString()).SelectToken("id");
                var title = JObject.Parse(a.ToString()).SelectToken("title");
                var releaseDate = JObject.Parse(a.ToString()).SelectToken("release_date");
                var overview = JObject.Parse(a.ToString()).SelectToken("overview");
                var poster = JObject.Parse(a.ToString()).SelectToken("poster_path");
                var backdrop = JObject.Parse(a.ToString()).SelectToken("backdrop_path");

                Console.WriteLine($"ID: {id}\nTitle: {title}\nRelease date: {releaseDate}\nOverview: {overview}\nPoster path: https://image.tmdb.org/t/p/w185/{poster}\nBackdrop path: https://image.tmdb.org/t/p/w1280{backdrop}\n");
            }
            
        }
    }
}
