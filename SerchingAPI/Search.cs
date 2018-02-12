using Newtonsoft.Json;
using SerchingAPI.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerchingAPI
{
    public class Search
    {
        public static async Task SearchMoviesAsync(string apiKey, string lang, string query)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var resultMovieAsync = await client.GetStringAsync($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language={lang}&query={query}")
                .ConfigureAwait(false);

            MovieRoot movieRoot = JsonConvert.DeserializeObject<MovieRoot>(resultMovieAsync);
            if (movieRoot.TotalResults == 0)
            {
                Console.WriteLine("По вашему запросу ничего не найдено");
            }
            else
            {
                foreach (var movie in movieRoot.MovieResults)
                {
                    Console.WriteLine($"ID: {movie.Id}\nTitle: {movie.Title}\nRelease date: {movie.ReleaseDate}\nOverview: {movie.Overview}\n");
                }
            }
        }
    }
}
