using MovieFinder.Entities;
using System.Text.Json;

namespace MovieFinder.Services
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public MovieApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _client = clientFactory.CreateClient("TheMovieDatabaseApi");
            _configuration = configuration;
        }
        public async Task<IEnumerable<Movie>> GetMoviesByName(string searchedValue)
        {
            var url = string.Format("/3/search/movie?api_key={0}&query={1}", _configuration["ApiKeys:theMovieDatabaseApiKey"] ,searchedValue);

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var responseObject = await JsonSerializer.DeserializeAsync<Rootobject>(responseStream);

                return responseObject.results.Select(i => new Movie
                {
                    Id = i.id,
                    Title = i.original_title,
                    ReleaseDate = i.release_date,
                    Overview = i.overview,
                    ImagePath = "https://image.tmdb.org/t/p/w300" + i.poster_path

                }) ;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
