using System;
using BoringRPG.Models;

namespace BoringRPG.Skills {
  public class Taunt : Skill {
    public double CritReductionPercent;
    public double OneValue;
    public double HundredPercent;

    public Taunt()
    {
      Name = "Taunt";
      CritReductionPercent = 0.5;
      OneValue = 1.0;
      HundredPercent = 100.0;
    }

    public override string Use(Archetype caster, Archetype target)
    {
      double newCritChance;

      newCritChance = target.CritChance * (OneValue - CritReductionPercent);
      target.CritChance = newCritChance;

      return $"{caster.Name} использует {Name} на {target.Name}!\nШанс критического удара {target.Name} уменьшен на {CritReductionPercent * HundredPercent}% и теперь составляет {target.CritChance * HundredPercent}%.";
    }
  }
}