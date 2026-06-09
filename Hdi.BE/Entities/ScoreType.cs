namespace Hdi.BE.Entities;

public class ScoreType
{
   public int Id { get; set; }
   public string Name { get; set; }
   public double Min {get; set;}
   public double Max {get; set;}
   public double Step { get; set; }
   public int Round {get; set;}
}