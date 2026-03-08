using System;

namespace BoringRPG {
  internal class RogueClass : Archetype {

    private static Random random = new Random();
    public bool LastHitWasCrit;

    public RogueClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 70, 20, 10, 30, 0.3) {
    }

    public RogueClass(string name) : base(name, 70, 20, 10, 30, 0.3) {
    }

    public static RogueClass operator +(RogueClass rogue, int amount) {
      rogue.HP += amount;
      return rogue;
    }

    public static RogueClass operator -(RogueClass rogue, int amount) {
      rogue.HP -= amount;
      return rogue;
    }

    public static bool operator true(RogueClass rogue) {
      return rogue.HP > 0;
    }

    public static bool operator false(RogueClass rogue) {
      return rogue.HP <= 0;
    }

    public override void Hit(Archetype target) {

      int damage = Damage;
      string ammoMessage = "";

      if (Ammo > 0) {
        --Ammo;
        ammoMessage = $"(потрачено 1 Ammo, осталось {Ammo})";

        if (MP >= 5) {

          MP -= 5;
          damage += 5;
          ammoMessage += $", использовано 5 MP";
        }
      } else {
        damage /= 2;
        ammoMessage = $"(нет Ammo, урон уменьшен вдвое до {damage})";
      }

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      Console.WriteLine($"{Name} стреляет! {ammoMessage}");

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Rogue): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance {CritChance * 100}%";
    }
  }
}
