using System;
using BoringRPG.Skills.Interfaces;

namespace BoringRPG {
  public abstract class Archetype : ICanUseSkill {
    public string Name;
    public int HP;
    public int MP;
    public int Ammo;
    public int Damage;
    public double CritChance;

    public Archetype(string name, int hp, int mp, int ammo, int damage, double critChance)
    {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = damage;
      CritChance = critChance;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();

    public virtual void UseSkill(Skill skill, Archetype target)
    {
      string result;

      result = skill.Use(this, target);
      Console.WriteLine(result);
    }
  }
}