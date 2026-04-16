using Hdi.BE.DTOs;
using Hdi.BE.Entities;
using Hdi.BE.Repositories;
using Hdi.BE.Services;
using Microsoft.AspNetCore.Mvc;

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
    [Route("CreateCountry")]
    public async Task<ActionResult<int>> CreateCountry(Country country)
    {
        var result = await  _hdiService.CreateCountry(country);
        return Ok(result);
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
    [Route("AddScore")]
    public async Task<ActionResult<int>> AddScore(Score score)
    {
        var result = await _hdiService.AddScore(score);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetScoreListCountry")]
    public async Task<ActionResult<List<ScoreListCountry>>> GetScoreListCountry()
    {
        var result = await _hdiService.GetScoreListCountries();
        return Ok(result);
    }
}