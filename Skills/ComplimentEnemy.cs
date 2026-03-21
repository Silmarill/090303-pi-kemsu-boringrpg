using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  class ComplimentEnemy : Skill
  {
    public ComplimentEnemy()
    {
      Name = "ComplimentEnemy";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int damageMultiplier;
      int CritChangeMultiplier;

      CritChangeMultiplier = 2;
      damageMultiplier = 10;

      target.Damage += damageMultiplier;
      target.CritChance *= CritChangeMultiplier;

      Console.WriteLine($"{target.Name} receives an improvement to critical chance and damage\n");
      Console.WriteLine($"Damage {target.Name} = {target.Damage}, critical chance = {target.CritChance}!\n");
    }
  }
}
