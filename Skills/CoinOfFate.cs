using System;

namespace BoringRPG
{
  internal class CoinOfFate : Skill
  {
    private static Random random = new Random();

    public CoinOfFate() : base("CoinOfFate") { }

    public override void Use(Archetype caster, Archetype target)
    {
      Console.WriteLine($"\n{caster.Name} подбрасывает монетку судьбы!");

      int roll;
      roll = random.Next(100);

      if (roll < 30)
      { 
        Console.WriteLine($"Выпало 0-29: {target.Name} падает замертво!");
        target.HP = 0;
      }
      else if (roll < 60)
      { 
        Console.WriteLine($"Выпало 30-59: {caster.Name} падает замертво!");
        caster.HP = 0;
      }
      else
      { 
        Console.WriteLine($"Выпало 60-99: Монетка звякнула... Ничего не произошло!");
      }
    }
  }
}