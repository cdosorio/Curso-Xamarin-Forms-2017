using System;
using Newtonsoft.Json;

namespace MovieApp
{
    //http://www.omdbapi.com/


    public class Movie
	{
		[JsonProperty("imdbID")] 
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

		[JsonProperty("Year")]
		public int ReleaseYear { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

		//[JsonProperty("Ratings")]
		//public float Rating { get; set; }

		[JsonProperty("Plot")]
		public string Summary { get; set; }
	}
}
