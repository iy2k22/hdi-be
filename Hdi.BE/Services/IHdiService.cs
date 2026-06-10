using Hdi.BE.DTOs;
using Hdi.BE.Entities;

namespace Hdi.BE.Services;

public interface IHdiService
{
    public Task<List<Country>> GetCountries();
    public Task<List<Continent>> GetContinents();
    public Task<int> CreateCountry(Country country);
    public Task<int> AddScore(Score score);
    public Task<List<ScoreListCountry>> GetScoreListCountries(int continent, bool isMuslim, int year, int scoreType);
    public Task<Dictionary<int, string>> GetCountryNames();
    public Task<Score?> GetScore(int country, int year, int scoreType);
    public Task<int> UpdateScore(Score score);
    public Task<List<string>> GetCountryNamesOnly();
    public Task<Country?> GetCountry(string countryName);
    public Task<int> UpdateCountry(Country country);
    public Task<List<ScoreType>> GetScoreTypes();
    public Task<int> AddScoreType(ScoreType scoreType);
    public Task<int> UpdateScoreType(ScoreType scoreType);
}