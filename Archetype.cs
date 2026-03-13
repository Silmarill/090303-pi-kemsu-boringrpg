using System;
using System.Collections.Generic;

namespace BoringRPG {
  internal abstract class Archetype {

    public string Name;
    public int HP;
    public int MP;
    public int Ammo;
    public int Damage;
    public double CritChance;
    public int Healing;

    protected Archetype(string name, int hp, int mp, int ammo, int dmg, int heal, double crit) {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = dmg;
      CritChance = crit;
      Healing = heal;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();
  }

}
