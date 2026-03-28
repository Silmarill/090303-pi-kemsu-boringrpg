using System;
using BoringRPG.Skills.Interfaces;

namespace BoringRPG.Skills {
  public class SoulLinkSkill : Skill {
    public SoulLinkSkill() : base("Связь душ", 30)
    {
    }

    public override string Use(Archetype user, Archetype target)
    {
      int totalHP;
      int newHP;
      string oldUserHP;
      string oldTargetHP;

      if (user.MP < ManaCost)
      {
        return $"Не хватает маны для {Name}!";
      }

      user.MP -= ManaCost;

      totalHP = user.HP + target.HP;
      newHP = totalHP / 2;

      oldUserHP = $"{user.Name} HP={user.HP}";
      oldTargetHP = $"{target.Name} HP={target.HP}";

      user.HP = newHP;
      target.HP = newHP;

      return $"{user.Name} использует {Name} на {target.Name}!\n" +
             $"Было: {oldUserHP}, {oldTargetHP}\n" +
             $"Стало: {user.Name} HP={user.HP}, {target.Name} HP={target.HP}";
    }
  }
}