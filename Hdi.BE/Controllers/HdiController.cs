using Hdi.BE.DTOs;
using Hdi.BE.Entities;
using Hdi.BE.Repositories;
using Hdi.BE.Services;
using Microsoft.AspNetCore.Mvc;
using Hdi.BE.HelperMethods;

namespace Hdi.BE.Controllers;

[ApiController]
[Route("[controller]")]
public class HdiController : ControllerBase
{
    private readonly IHdiService _hdiService;

    public HdiController(IHdiService hdiService)
    {
        _hdiService = hdiService;
    }

    [HttpGet]
    [Route("GetCountries")]
    public async Task<ActionResult<List<Country>>> GetCountries()
    {
        var result = await _hdiService.GetCountries();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetContinents")]
    public async Task<ActionResult<List<Continent>>> GetContinents()
    {
        var result = await _hdiService.GetContinents();
        return Ok(result);
    }

    [HttpPost]
    [Route("AddCountries")]
    public async Task<ActionResult<int>> AddCountries(List<CountryAddDTO> countries)
    {
        try
        {
            List<Country> adding = (from c in countries
                    where !c.Editing
                    select Helpers.ConvertDTOToCountry(c)).ToList();
            List<Country> editing = (from c in countries
                where c.Editing
                select Helpers.ConvertDTOToCountry(c)).ToList();

            foreach (Country c in adding)
                await _hdiService.CreateCountry(c);
            foreach (Country c in editing)
                await _hdiService.UpdateCountry(c);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ScoreAddCountry")]
    public async Task<ActionResult<List<ScoreAddCountry>>> GetScoreAddCountry()
    {
        List<Country> countries = await _hdiService.GetCountries();
        List<ScoreAddCountry> result = (from c in countries
                orderby c.Name
                select new ScoreAddCountry
                {
                    Id = c.Id,
                    Name = c.Name,
                    Flag = $"&#x{c.Flag1};&#x{c.Flag2};"
                }
            ).ToList();
        return Ok(result);
    }

    [HttpPost]
    [Route("AddScores")]
    public async Task<ActionResult<int>> AddScore(List<ScoreAdd> scores)
    {
        List<Score> adds = (from s in scores
            where !s.Editing
            select new Score
            {
                Id = s.Id,
                Country = s.Country,
                ScoreType = s.ScoreType,
                ScoreValue = s.ScoreValue,
                Year = s.Year
            }).ToList();
        List<Score> edits = (from s in scores
            where s.Editing
            select new Score
            {
                Id = s.Id,
                Country = s.Country,
                ScoreType = s.ScoreType,
                ScoreValue = s.ScoreValue,
                Year = s.Year
            }).ToList();

        try
        {
            foreach (Score s in adds)
                await _hdiService.AddScore(s);
            foreach (Score s in edits)
                await _hdiService.UpdateScore(s);
            
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    [Route("GetScoreListCountry")]
    public async Task<ActionResult<List<ScoreListCountry>>> GetScoreListCountry(int continent, bool isMuslim, int year, int scoreType)
    {
        var result = await _hdiService.GetScoreListCountries(continent, isMuslim, year, scoreType);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetCountryNames")]
    public async Task<ActionResult<Dictionary<int, string>>> GetCountryNames()
    {
        var result = await _hdiService.GetCountryNames();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetScore")]
    public async Task<ActionResult<Score?>> GetScore(int country, int year, int scoreType)
    {
        var result = await _hdiService.GetScore(country, year, scoreType);
        return Ok(result);
    }

    [HttpPatch]
    [Route("UpdateScore")]
    public async Task<ActionResult<int>> UpdateScore(Score score)
    {
        var result = await _hdiService.UpdateScore(score);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetCountryNamesOnly")]
    public async Task<ActionResult<List<string>>> GetCountryNamesOnly()
    {
        var result = await _hdiService.GetCountryNamesOnly();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetCountry")]
    public async Task<ActionResult<Country?>> GetCountry(string countryName)
    {
        var result = await _hdiService.GetCountry(countryName);
        return Ok(result);
    }

    [HttpPatch]
    [Route("UpdateCountry")]
    public async Task<ActionResult<int>> UpdateCountry(Country country)
    {
        var result = await _hdiService.UpdateCountry(country);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetScoreTypes")]
    public async Task<ActionResult<List<ScoreType>>> GetScoreTypes()
    {
        var result = await _hdiService.GetScoreTypes();
        return Ok(result);
    }

    [HttpPost]
    [Route("UploadScoreTypes")]
    public async Task<ActionResult<int>> UploadScoreTypes(List<ScoreTypeAddDTO> scoreTypes)
    {
        try
        {
            List<ScoreType> adding = (from s in scoreTypes
                where !s.Editing
                select new ScoreType
                {
                    Id = s.Id,
                    Name = s.Name,
                    Min = s.Min,
                    Max = s.Max,
                    Step = s.Step,
                    Round = s.Round,
                    Ascending = s.Ascending
                }).ToList();

            List<ScoreType> editing = (from s in scoreTypes
                where s.Editing
                select new ScoreType
                {
                    Id = s.Id,
                    Name = s.Name,
                    Min = s.Min,
                    Max = s.Max,
                    Step = s.Step,
                    Round = s.Round,
                    Ascending = s.Ascending
                }).ToList();

            foreach (ScoreType s in adding)
                await _hdiService.AddScoreType(s);
            foreach (ScoreType s in editing)
                await _hdiService.UpdateScoreType(s);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}