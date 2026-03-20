using System;

namespace BoringRPG {
  internal class Cleric : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Cleric(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 75, 80, 0, 15, 0.05) {
    }

    public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05) {
    }

    public static Cleric operator +(Cleric cleric, int value) {
      cleric.HP += value;
      return cleric;
    }

    public static Cleric operator -(Cleric cleric, int value) {
      cleric.HP -= value;
      return cleric;
    }

    public static bool operator true(Cleric cleric) {
      return cleric.HP > 0;
    }

    public static bool operator false(Cleric cleric) {
      return cleric.HP <= 0;
    }

    public static Cleric operator +(Cleric cleric, HealthPotion healthPotion) {
      cleric.HP += healthPotion.Value;
      return cleric;
    }

    public static Cleric operator +(Cleric cleric, ManaPotion manaPotion) {
      cleric.MP += manaPotion.Value;
      return cleric;
    }

    public static Cleric operator +(Cleric cleric, AmmoPack ammoPack) {
      cleric.Ammo += ammoPack.Value;
      return cleric;
    }

    public static Cleric operator +(Cleric cleric, RagePie ragePie) {
      cleric.Damage += ragePie.Value;
      cleric.HP += ragePie.Value;
      cleric.MP += ragePie.Value;
      cleric.Ammo += ragePie.Value;
      return cleric;
    }

    public override void Hit(Archetype target) {
      if (MP >= 10) {
        MP -= 10;
        int damage = Damage;
        LastHitWasCrit = random.NextDouble() < CritChance;

        if (LastHitWasCrit) {
          damage *= 2;
        }

        target.HP -= damage;

        if (target.HP <= 0) {
          HP += 10;
        }
      }
      else {
        Console.WriteLine("Недостаточно маны!");
      }
    }

    public override string GetInfo() {
      return $"{Name} (Cleric): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }


  }
}