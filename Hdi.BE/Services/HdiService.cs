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

    public async Task<List<ScoreListCountry>> GetScoreListCountries()
    {
        var countries = await _repository.GetCountries();
        var scores = await _repository.GetScores();

        var result = (from c in countries
            join s in scores on c.Id equals s.Country
            orderby s.ScoreValue descending
            select new ScoreListCountry
            {
                Name = c.Name,
                Score = s.ScoreValue,
                Flag = $"&#x{c.Flag1};&#x{c.Flag2};"
            }).ToList();
        return result;
    }
}