using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SerchingAPI
{
    public class Search
    {
        private string apiKey;
        public string ApiKey
        {
            set
            {
                if (value != string.Empty)
                {
                    throw new ArgumentException("");
                }
                else
                {
                    apiKey = value;
                }
            }
            get
            {
                { return apiKey;  }
            }
        }

        public string lang;
        public string query;

        private static async Task SearchMoviesAsync()
        {

        }
    }
}
