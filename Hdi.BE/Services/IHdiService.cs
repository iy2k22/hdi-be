using Hdi.BE.DTOs;
using Hdi.BE.Entities;

namespace Hdi.BE.Services;

public interface IHdiService
{
    public Task<List<Country>> GetCountries();
    public Task<List<Continent>> GetContinents();
    public Task<int> CreateCountry(Country country);
    public Task<int> AddScore(Score score);
    public Task<List<ScoreListCountry>> GetScoreListCountries(int continent, bool isMuslim);
}