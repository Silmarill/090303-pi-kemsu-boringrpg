using System;

namespace BoringRPG {
  public class SoulLink : Skill {
    public int HealthDivider;

    public SoulLink()
    {
      Name = "Soul Link";
      HealthDivider = 2;
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int totalHealth;
      int newHealth;

      totalHealth = caster.HP + target.HP;
      newHealth = totalHealth / HealthDivider;

      caster.HP = newHealth;
      target.HP = newHealth;

      Console.WriteLine($"{caster.Name} использует {Name}!");
      Console.WriteLine($"Здоровье {caster.Name} и {target.Name} стало одинаковым: {newHealth} HP.");
    }
  }
}