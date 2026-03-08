using System;

namespace BoringRPG
{
  internal class Cleric : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05) {
    }

    public static Cleric operator +(Cleric cleric, int amount) {
      cleric.HP += amount;

      if (cleric.HP > 75) {
        cleric.HP = 75;
      }

      return cleric;
    }

    public static Cleric operator -(Cleric cleric, int amount) {
      cleric.HP -= amount;

      if (cleric.HP < 0) {
        cleric.HP = 0;
      }

      return cleric;
    }

    public override void Hit(Archetype target) {
      if (MP >= 10) {
        int damage = Damage;
        int targetHpBefore = target.HP;

        MP -= 10;

        LastHitWasCrit = random.NextDouble() < CritChance;

        if (LastHitWasCrit) {
          damage *= 2;
        }

        target.HP -= damage;

        Console.WriteLine($"{Name} attacks {target.Name} and deals {damage} damage!");

        if (targetHpBefore > 0 && target.HP <= 0) {
          HP += 10;

          if (HP > 75) {
            HP = 75;
          }

          Console.WriteLine($"{Name} restores 10 HP!");
        }
      } else {
        LastHitWasCrit = false;

        Console.WriteLine($"{Name} has insufficient MP to attack!");
      }
    }

    public override string GetInfo() {
      return $"Cleric: {Name}: HP {HP}/75, MP {MP}/80, Ammo {Ammo}, Crit chance {CritChance * 100}%";
    }
  }
}