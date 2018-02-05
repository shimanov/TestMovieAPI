﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SerchingAPI.Model
{

    public class TvshowRoot
    {
        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public TvshowResult[] TvshowResults { get; set; }
    }

    public class TvshowResult
    {
        public string Original_name { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Vote_count { get; set; }
        public float Vote_average { get; set; }
        public string Poster_path { get; set; }
        public string First_air_date { get; set; }
        public float Popularity { get; set; }
        public int[] Genre_ids { get; set; }
        public string Original_language { get; set; }
        public string Backdrop_path { get; set; }
        public string Overview { get; set; }
        public string[] Origin_country { get; set; }
    }

}
