using System;
using BoringRPG.Skills.Interfaces;

namespace BoringRPG.Skills {
  public class CoinOfFateSkill : Skill {
    public static Random random = new Random();

    public CoinOfFateSkill() : base("Монета судьбы", 40)
    {
    }

    public override string Use(Archetype user, Archetype target)
    {
      int roll;
      string result;

      if (user.MP < ManaCost)
      {
        return $"Не хватает маны для {Name}!";
      }

      user.MP -= ManaCost;

      result = $"{user.Name} подбрасывает {Name}!\n";

      roll = random.Next(100);

      if (roll < 30)
      {
        target.HP = 0;
        result += $" {target.Name} умирает! ";
      }
      else if (roll < 60)
      {
        user.HP = 0;
        result += $" {user.Name} умирает! ";
      }
      else
      {
        result += $" Ничего не произошло! ";
      }

      return result;
    }
  }
}