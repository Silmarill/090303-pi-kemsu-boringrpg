using System;

namespace BoringRPG {
  internal class Berserker : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Berserker(string name, int hp, int mp, int ammo, int dmg, double crit)
      : base(name, hp, mp, ammo, dmg, crit) {
    }

    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15) {
    }

    public static Berserker operator +(Berserker berserker, int amount) {
      berserker.HP += amount;
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int amount) {
      berserker.HP -= amount;
      return berserker;
    }

    public static bool operator true(Berserker berserker) {
      return berserker.HP > 0;
    }
    public static bool operator false(Berserker berserker) {
      return berserker.HP <= 0;
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      int rageBonus = (140 - HP) / 2;
      damage += rageBonus;

      LastHitWasCrit = random.NextDouble() < CritChance;
      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Berserker): HP {HP}/{140}, MP {MP}, Ammo {Ammo}, " +
             $"Урон {Damage}, Шанс крита {CritChance * 100}%, " +
             $"Бонус ярости: {(140 - HP) / 2}";
    }
  }
} 