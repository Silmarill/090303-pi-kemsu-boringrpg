using System;
using BoringRPG.Interfaces;

namespace BoringRPG.Skills {
  public class SoulLinkSkill : Skill {
    public SoulLinkSkill() : base("Связь душ", 30)
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

      int totalHP = druidUser.HP + druidTarget.HP;
      int newHP = totalHP / 2;

      Console.WriteLine($"{druidUser.Name} использует {Name} на {druidTarget.Name}!");
      Console.WriteLine($"Было: {druidUser.Name} HP={druidUser.HP}, {druidTarget.Name} HP={druidTarget.HP}");

      druidUser.HP = newHP;
      druidTarget.HP = newHP;

      Console.WriteLine($"Стало: {druidUser.Name} HP={druidUser.HP}, {druidTarget.Name} HP={druidTarget.HP}");
    }
  }
}