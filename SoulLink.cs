using System;
using BoringRPG.Models;

namespace BoringRPG.Skills {
  public class SoulLink : Skill {
    public int HealthDivider;

    public SoulLink()
    {
      Name = "Soul Link";
      HealthDivider = 2;
    }

    public override string Use(Archetype caster, Archetype target)
    {
      int totalHealth;
      int newHealth;

      totalHealth = caster.HP + target.HP;
      newHealth = totalHealth / HealthDivider;

      caster.HP = newHealth;
      target.HP = newHealth;

      return $"{caster.Name} использует {Name}!\nЗдоровье {caster.Name} и {target.Name} стало одинаковым: {newHealth} HP.";
    }
  }
}