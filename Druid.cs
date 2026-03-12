using System;

namespace BoringRPG {
  internal class Druid : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name)
        : base(name, 90, 60, 0, 20, 0.10) {
    }

    public static Druid operator +(Druid druid, int regain) {
      int maxHP = 90; 

      if (druid.HP < maxHP) {
        druid.HP = druid.HP + regain;
        if (druid.HP > maxHP) {
          druid.HP = maxHP;
        }
      }
      return druid;
    }

    public static Druid operator -(Druid druid, int damage) {
      int minHP = 0;

      if (druid.HP > minHP) {
        druid.HP -= damage;
        if (druid.HP < minHP) {
          druid.HP = minHP;
        }
      }
      return druid;
    }

    public override void Hit(Archetype target) {
      int manaCost = 5; 
      int baseDamage = this.Damage;
      int hpThreshold = 45; 

      if (this.MP >= manaCost) {
        // Тратим ману
        this.MP -= manaCost;

        int damage = baseDamage;

        if (target.HP > hpThreshold) {
          damage *= 2;
        }

        target.HP -= damage;

        LastHitWasCrit = false;
      }
    }

    public override string GetInfo() {
      return $"({Name}) Druid: HP {HP}/{90}, MP {MP}/{60}, Ammo {Ammo}, Damage {Damage}, Crit Chance: {CritChance * 100}%";
    }
  }
}