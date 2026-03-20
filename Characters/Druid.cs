using System;

namespace BoringRPG {
  internal class Druid : Archetype, ICanUseSkill {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name) : base(name, 90, 60, 0, 20, 0.10) {
    }

    public static Druid operator+ (Druid druid, int healing) {
      druid.HP += healing;
      return druid;
    }

    public static Druid operator+ (Druid druid, HealthPotion item) {
      druid.HP += item.value;
      return druid;
    }

    public static Druid operator+ (Druid druid, ManaPotion item) {
      druid.MP += item.value;
      return druid;
    }

    public static Druid operator+ (Druid druid, AmmoPack item) {
      druid.Ammo += item.value;
      return druid;
    }

    public static Druid operator+ (Druid druid, BugPotion item) {
      int effect = random.Next(-item.value, item.value + 1);
      druid.HP += effect;
      return druid;
    }

    public static Druid operator- (Druid druid, int damage) {
      druid.HP -= damage;
      return druid;
    }
    
    public static bool operator true(Druid druid) {
      return druid.HP > 0;
    }

    public static bool operator false(Druid druid) {
      return druid.HP <= 0;
    }

    public void Use (Skill skill, Archetype target) {
      skill.Use(this, target);
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
        if (target.HP > 45) {
          damage *= 2;
        }
      }

      if (target is Druid druidTarget) {
        druidTarget = druidTarget - damage;
      } else {
        target.HP -= damage;
      }
    }

    public override string GetInfo() {
      return $"{Name} (Druid): HP {HP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Крит {CritChance * 100}%";
    }
  }
}