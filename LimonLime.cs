using BoringRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  class LimonLime : Skill
  {
    Random rand = new Random();

    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmount = rand.Next(5, 25);

      if (target.MP >= drainAmount)
      {
        target.MP -= drainAmount;
        caster.MP += drainAmount;

        Console.WriteLine($"{caster.Name} использует CocaCola на {target.Name}!");
        Console.WriteLine($" Высосано {drainAmount} маны! Мана {target.Name}: {target.MP}, мана {caster.Name}: {caster.MP}");
      }
      else
      {
        Console.WriteLine($"Неудача! У {target.Name} недостаточно маны ({target.MP} / {drainAmount})");
      }
    }
  }
}
