using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BoringRPG {
  internal class Rogue : Archetype {
    public Rogue(string name, int HP, int MP, int ammo, int dmg, double crit) : base(name, 70, 20, 10, 30, 0.30) {
    }

    public Rogue(string name) : base(name, 70, 20, 10, 30, 0.30) {
    }

    public override void Hit(Archetype target) {
      int damage = Damage;
    }

    public static Rogue operator +(Rogue rogue, int health ) {
      rogue.HP += health;
      return rogue;
    }

    public override string GetInfo() {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }


  }
}
