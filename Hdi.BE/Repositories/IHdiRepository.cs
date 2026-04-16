using Hdi.BE.Entities;

namespace Hdi.BE.Repositories;

public interface IHdiRepository
{
    public Task<List<Country>> GetCountries();
    public Task<List<Continent>> GetContinents();
    public Task<int> CreateCountry(Country country);
    public Task<int> AddScore(Score score);
    public Task<List<Score>> GetScores();
}