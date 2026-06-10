using Hdi.BE.Entities;

namespace Hdi.BE.DTOs;

public class ScoreTypeAddDTO : ScoreType
{
    public bool Editing { get; set; }
}