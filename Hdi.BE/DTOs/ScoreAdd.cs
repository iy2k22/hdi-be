using Hdi.BE.Entities;

namespace Hdi.BE.DTOs;

public class ScoreAdd : Score
{
    public bool Editing { get; set; }
}