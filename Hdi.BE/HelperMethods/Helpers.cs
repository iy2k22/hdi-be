using Hdi.BE.DTOs;
using Hdi.BE.Entities;

namespace Hdi.BE.HelperMethods;

public class Helpers
{
    public static Country ConvertDTOToCountry(CountryAddDTO dto)
    {
        return new Country
        {
            Id = dto.Id,
            Name = dto.Name,
            Continent = dto.Continent,
            Flag1 = dto.Flag1,
            Flag2 = dto.Flag2,
            IsMuslim = dto.IsMuslim
        };
    }
}