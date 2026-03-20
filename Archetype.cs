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

    protected Archetype(string name, int hp, int mp, int ammo, int dmg, double crit) {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = dmg;
      CritChance = crit;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();

    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }
  }
}