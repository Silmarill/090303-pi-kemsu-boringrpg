using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BoringRPG {
  internal class Rogue : Archetype, ICanUseSkill {
    public Rogue(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 70, 20, 10, 30, 0.30) {
    }

    public Rogue(string name) : base(name, 70, 20, 10, 30, 0.30) {
    }

    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }

    public override void Hit(Archetype target) {
      int damage = Damage;
    }

    public static Rogue operator +(Rogue rogue, int health) {
      rogue.HP += health;
      return rogue;
    }

    public static Rogue operator -(Rogue rogue, int health) {
      rogue.HP -= health;
      return rogue;
    }

    public override string GetInfo() {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Шанс крита {CritChance * 100}%";
    }

    public static Rogue operator +(Rogue rogue, Heal potion) {
      rogue.HP += potion.value;
      return rogue;
    }

    public static Rogue operator +(Rogue rogue, ManaRestore potion) {
      rogue.MP += potion.value;
      return rogue;
    }

    public static Rogue operator +(Rogue rogue, AmmoPack potion) {
      rogue.Ammo += potion.value;
      return rogue;
    }

    public static Rogue operator -(Rogue rogue, FatBurger potion) {
      rogue.HP -= potion.value;
      rogue.Damage += potion.value;
      return rogue;
    }
  }
}
