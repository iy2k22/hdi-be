using Hdi.BE.Entities;

namespace Hdi.BE.DTOs;

public class CountryAddDTO : Country
{
    public bool Editing { get; set; }
}