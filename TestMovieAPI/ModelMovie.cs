namespace TestMovieAPI
{
    public class Rootobject
    {
        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public int Vote_count { get; set; }
        public int Id { get; set; }
        public bool Video { get; set; }
        public float Vote_average { get; set; }
        public string Title { get; set; }
        public float Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public int[] Genre_ids { get; set; }
        public string Backdrop_path { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
    }
}
