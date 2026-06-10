using Hdi.BE.Contexts;
using Hdi.BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hdi.BE.Repositories;

public class HdiRepository : IHdiRepository
{
    private readonly HdiDbContext _dbContext;
    
    public HdiRepository(HdiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Country>> GetCountries()
    {
        return await _dbContext.Countries.ToListAsync();
    }

    public async Task<List<Continent>> GetContinents()
    {
        return await _dbContext.Continents.ToListAsync();
    }

    public async Task<int> CreateCountry(Country country)
    {
        await _dbContext.Countries.AddAsync(country);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> AddScore(Score score)
    {
        await _dbContext.Scores.AddAsync(score);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<List<Score>> GetScores()
    {
        return await _dbContext.Scores.ToListAsync();
    }

    public async Task<Score?> GetScore(int country, int year, int scoreType)
    {
        return await _dbContext.Scores.FirstOrDefaultAsync(s => s.Country == country && s.Year == year && s.ScoreType == scoreType);
    }

    public async Task<int> UpdateScore(Score score)
    {
        _dbContext.Scores.Update(score);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Country?> GetCountry(string countryName)
    {
        return await _dbContext.Countries.FirstOrDefaultAsync(c => c.Name == countryName);
    }

    public async Task<int> UpdateCountry(Country country)
    {
        _dbContext.Countries.Update(country);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ScoreType>> GetScoreTypes()
    {
        return await _dbContext.ScoreTypes.OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<int> AddScoreType(ScoreType scoreType)
    {
        await _dbContext.ScoreTypes.AddAsync(scoreType);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateScoreType(ScoreType scoreType)
    {
        _dbContext.ScoreTypes.Update(scoreType);
        return await _dbContext.SaveChangesAsync();
    }
}