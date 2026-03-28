using System;
using BoringRPG.Skills.Interfaces;

namespace BoringRPG.Skills {
  public class TauntSkill : Skill {
    public TauntSkill() : base("Провокация", 20)
    {
    }

    public override string Use(Archetype user, Archetype target)
    {
      double oldCrit;

      if (user.MP < ManaCost)
      {
        return $"Не хватает маны для {Name}!";
      }

      user.MP -= ManaCost;

      oldCrit = target.CritChance;
      target.CritChance = target.CritChance / 2;

      return $"{user.Name} использует {Name} на {target.Name}!\n" +
             $"{target.Name} был спровоцирован! Шанс крита уменьшен с {oldCrit * 100}% до {target.CritChance * 100}%";
    }
  }
}