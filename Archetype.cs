using System;
using System.Collections.Generic;

namespace BoringRPG {
  public abstract class Archetype : ICanUseSkill {
    public string Name;
    public int HP;
    public int MP;
    public int Ammo;
    public int Damage;
    public double CritChance;

    public Archetype(string name, int hp, int mp, int ammo, int dmg, double crit)
    {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = dmg;
      CritChance = crit;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();

    public void UseSkill(Skill skill, Archetype target)
    {
      if (skill == null)
      {
        Console.WriteLine("Нельзя использовать пустой навык.");
        return;
      }

      if (target == null)
      {
        Console.WriteLine("Нельзя применить навык на пустую цель.");
        return;
      }

      skill.Use(this, target);
    }
  }
}