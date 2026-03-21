using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  class CoinOfFate : Skill
  {
    private static Random random = new Random();

    public CoinOfFate()
    {
      Name = "CoinOfFate";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int ChangeRandom;
      int SelfHarmProbability = 3;
      int TargetHarmProbability = 7;

    ChangeRandom = random.Next(1, 11);

      Console.WriteLine($"{caster.Name} is using {Name} on {target.Name}!\n");

      if (ChangeRandom <= SelfHarmProbability)
      {
        caster.HP = 0;
        Console.WriteLine($"{caster.Name} lost his health!\n");
      }

      else if (ChangeRandom > SelfHarmProbability && ChangeRandom < TargetHarmProbability)
      {
        target.HP = 0;
        Console.WriteLine($"{target.Name} lost his health!\n");
      }

      else
      {
        Console.WriteLine("nothing happened!\n");
      }
    }
  }
}
