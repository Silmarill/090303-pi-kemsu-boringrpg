using BoringRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  class Extreme : Skill
  {
    public override void Use(Archetype caster, Archetype target)
    {
      if (caster == target)
      {
        Console.WriteLine("Невозможно использовать аим на себя!");
        return;
      }

      int totalHP = caster.HP + target.HP;

      caster.HP = totalHP / 5;
      target.HP = totalHP / 5;

      Console.WriteLine($"{caster.Name} прибавляет аим с {target.Name}!");
      Console.WriteLine($"Здоровье выровдено у обоих теперь {caster.HP}");
    }
  }
}


