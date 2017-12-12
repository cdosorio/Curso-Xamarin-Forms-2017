using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieApp
{
	public class MovieService
	{
		public static readonly int MinSearchLength = 5;
                
        private const string Url = "https://www.omdbapi.com";
        private const string apikey = "apikey=59103566";
        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Movie>> FindMoviesByTitle(string title)
        {
            if (title.Length < MinSearchLength)
                return Enumerable.Empty<Movie>();

            var _requestUri = $"{Url}/?t={title}&{apikey}";
            var response = await _client.GetAsync(_requestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                content = "[" + content + "]"; //dado que omdbapi solo devuelve un objeto, convertirlo en lista para que funcione el ejemplo
                return JsonConvert.DeserializeObject<List<Movie>>(content);
            }
            else {
                return Enumerable.Empty<Movie>();
            }                     

            /*
            if (response.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<Movie>();          
            */
        }
        

        public async Task<Movie> GetMovie(string title)
		{
			var response = await _client.GetAsync($"{Url}/?t={title}&{apikey}");

            if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Movie>(content);
		}
	}
}
