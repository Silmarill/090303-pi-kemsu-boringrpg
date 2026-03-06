using System;

namespace BoringRPG {
  internal class Druid : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name) : base(name, 90, 60, 0, 20, 0.10) {
    }

    public static Druid operator +(Druid druid, int healing) {
      druid.HP += healing;
      return druid;
    }

    public static Druid operator -(Druid druid, int damage) {
      druid.HP -= damage;
      return druid;
    }
    
    // true
    public static bool operator true(Druid druid) {
      return druid.HP > 0;
    }

    // false
    public static bool operator false(Druid druid) {
      return druid.HP <= 0;
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      // тратит 5 МР
      // eсли цель имеет больше 50% HP - урон удваивается
      if (MP >= 5) {
        MP -= 5;
        if (target.HP < 45) {
          damage *= 2;
        }
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Druid): HP {HP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Крит {CritChance * 100}%";
    }
  }
}