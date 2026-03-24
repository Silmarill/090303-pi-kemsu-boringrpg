using System;

namespace BoringRPG
{
  internal class Taunt : Skill
  {
    public Taunt() : base("Taunt") { }

    public override void Use(Archetype caster, Archetype target)
    {
      double originalCrit;
      originalCrit = target.CritChance;
      target.CritChance *= 0.5;

      Console.WriteLine(
        $"\n{caster.Name} применяет {Name}!" +
        $"\n{target.Name} оскорблен и теряет концентрацию!" +
        $"\nШанс крита {target.Name} уменьшен с {originalCrit * 100:F1}% до {target.CritChance * 100:F1}% на один ход!"
        );
    }
  }
}