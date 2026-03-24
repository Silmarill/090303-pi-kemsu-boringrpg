using BoringRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG.skills
{
  class ManaDrain : Skill
  {
    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmmount = Math.Min(20, target.MP);

      if (drainAmmount > 0)
      {
        target.MP -= drainAmmount;
        caster.MP += drainAmmount;

        Console.WriteLine($"{caster.Name} высасывает {drainAmmount} маны у {target.Name}!");
        Console.WriteLine($"Мана {target.Name}: {target.MP}, мана {caster.Name}: {caster.MP}");
      }
      else
      {
        Console.WriteLine($" у {target.Name} нет маны для высасывания!");
      }
    }
  }
}
