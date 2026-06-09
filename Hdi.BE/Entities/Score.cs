using Microsoft.EntityFrameworkCore;

namespace Hdi.BE.Entities;

public class Score
{
    public int Id { get; set; }
    public int Country { get; set; }
    public double ScoreValue { get; set; }
    public int Year { get; set; }
    public int ScoreType { get; set; }
}