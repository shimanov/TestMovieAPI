namespace TestMovieAPI
{
    public class Rootobject
    {
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public int VoteCount { get; set; }
        public int Id { get; set; }
        public bool Video { get; set; }
        public float VoteAverage { get; set; }
        public string Title { get; set; }
        public float Popularity { get; set; }
        public string PosterPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public int[] GenreIds { get; set; }
        public string BackdropPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
    }
}
