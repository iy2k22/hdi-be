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
}