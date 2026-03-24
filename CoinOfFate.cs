using System;
using BoringRPG.Interfaces;

namespace BoringRPG.Skills {
  public class CoinOfFateSkill : Skill {
    public static Random random = new Random();

    public CoinOfFateSkill() : base("Монета судьбы", 40)
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

      Console.WriteLine($"{druidUser.Name} подбрасывает {Name}!");

      int roll = random.Next(100);

      if (roll < 30)
      {
        druidTarget.HP = 0;
        Console.WriteLine($"💀 {druidTarget.Name} умирает! 💀");
      }
      else if (roll < 60)
      {
        druidUser.HP = 0;
        Console.WriteLine($"💀 {druidUser.Name} умирает! 💀");
      }
      else
      {
        Console.WriteLine($"🍀 Ничего не произошло! 🍀");
      }
    }
  }
}