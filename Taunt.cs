using System;
using BoringRPG.Interfaces;

namespace BoringRPG.Skills {
  public class TauntSkill : Skill {
    public TauntSkill() : base("Провокация", 20)
    {
    }

    public override void Use(ICanUseSkill user, ICanUseSkill target)
    {
      Druid druidUser = user as Druid;
      Druid druidTarget = target as Druid;

      if (druidUser == null || druidTarget == null)
      {
        Console.WriteLine("Ошибка: цель не является друидом!");
        return;
      }

      if (druidUser.MP < ManaCost)
      {
        Console.WriteLine($"Не хватает маны для {Name}!");
        return;
      }

      druidUser.MP -= ManaCost;

      Console.WriteLine($"{druidUser.Name} использует {Name} на {druidTarget.Name}!");
      Console.WriteLine($"{druidTarget.Name} был спровоцирован! Шанс крита уменьшен на 50%");

      druidTarget.CritChance = druidTarget.CritChance / 2;
    }
  }
}