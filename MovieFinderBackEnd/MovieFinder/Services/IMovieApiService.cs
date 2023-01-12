using MovieFinder.Entities;

namespace MovieFinder.Services
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movie>> GetMoviesByName(string searchedValue);

    }
}
