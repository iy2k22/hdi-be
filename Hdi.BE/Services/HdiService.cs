using Hdi.BE.DTOs;
using Hdi.BE.Entities;
using Hdi.BE.Repositories;

namespace Hdi.BE.Services;

public class HdiService : IHdiService
{
    public IHdiRepository _repository { get; set; }

    public HdiService(IHdiRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Country>> GetCountries()
    {
        var result = await _repository.GetCountries();
        return result;
    }

    public async Task<List<Continent>> GetContinents()
    {
        var result = await _repository.GetContinents();
        return result;
    }

    public async Task<int> CreateCountry(Country country)
    {
        var result = await _repository.CreateCountry(country);
        return result;
    }

    public async Task<int> AddScore(Score score)
    {
        var result = await _repository.AddScore(score);
        return result;
    }

    public async Task<List<ScoreListCountry>> GetScoreListCountries(int continent, bool isMuslim, int year, int scoreType)
    {
        bool ascending = await _repository.GetScoreTypeAscending(scoreType);
        
        var countries = await _repository.GetCountries();
        var scores = await _repository.GetScores();

        var result = (from c in countries
            join s in scores on c.Id equals s.Country
            where ((continent == 0 || c.Continent == continent) && (!isMuslim || c.IsMuslim) && s.Year == year &&
                   s.ScoreType == scoreType)
            select new ScoreListCountry
            {
                Name = c.Name,
                Score = s.ScoreValue,
                Flag = $"&#x{c.Flag1};&#x{c.Flag2};"
            });
        
        result = ascending ? result.OrderBy(s => s.Score) : result.OrderByDescending(s => s.Score);
        
        return result.ToList();
    }

    public async Task<Dictionary<int, string>> GetCountryNames()
    {
        Dictionary<int, string> result = new Dictionary<int, string>();
        
        var countries = await _repository.GetCountries();
        foreach (Country country in countries)
        {
            result.Add(country.Id, country.Name);
        }
        
        return result;
    }

    public async Task<List<string>> GetCountryNamesOnly()
    {
        var countries = await _repository.GetCountries();
        var result = (from c in countries
            orderby c.Name
            select c.Name).ToList();
        return result;
    }

    public async Task<Score?> GetScore(int country, int year, int scoreType)
    {
        var result = await _repository.GetScore(country, year, scoreType);
        return result;
    }

    public async Task<int> UpdateScore(Score score)
    {
        var result = await _repository.UpdateScore(score);
        return result;
    }

    public async Task<Country?> GetCountry(string countryName)
    {
        var result = await _repository.GetCountry(countryName);
        return result;
    }

    public async Task<int> UpdateCountry(Country country)
    {
        var result = await _repository.UpdateCountry(country);
        return result;
    }

    public async Task<List<ScoreType>> GetScoreTypes()
    {
        var result = await _repository.GetScoreTypes();
        return result;
    }

    public async Task<int> AddScoreType(ScoreType scoreType)
    {
        var result = await _repository.AddScoreType(scoreType);
        return result;
    }

    public async Task<int> UpdateScoreType(ScoreType scoreType)
    {
        var result = await _repository.UpdateScoreType(scoreType);
        return result;
    }
}