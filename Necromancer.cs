using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    // Field for storing the bonus from skeletons
    private int skeletonBonus = 0;

    public Necromancer(string name) : base(name, 55, 90, 0, 30, 0.1) {
    }

    // Overload "!"
    public static bool operator !(Necromancer hero) {
      // true (dead), if HP <= 0
      return hero.HP <= 0;
    }

    // Does hero alive? (HP > 0)
    public static bool operator true(Necromancer hero) {
      return hero.HP > 0;
    }

    // Does hero dead (HP <= 0)
    public static bool operator false(Necromancer hero) {
      return hero.HP <= 0;
    }

    // Overload (+ HP)
    public static Necromancer operator +(Necromancer hero, int amount) {
      hero.HP += amount;
      return hero;
    }

    // Overload (- HP)
    public static Necromancer operator -(Necromancer hero, int amount) {
      hero.HP -= amount;
      return hero;
    }

    public override void Hit(Archetype target) {
      // If mana is enough
      if (MP >= 15) {
        MP -= 15;

        // Damage = default damage + bonus from skeletons
        int currentDamage = Damage + skeletonBonus;
        int hpBefore = target.HP;

        target.HP -= currentDamage;

        // If damage is dealt, summon a new skeleton (+5 to the next instance)
        if (target.HP < hpBefore) {
          skeletonBonus += 5;
          Console.WriteLine($"{Name} strikes with magic! A skeleton has been summoned..");
        }
      }
      // If mana is low, it deals normal damage
      else {
        target.HP -= Damage;
        Console.WriteLine($"{Name}: Not enough mana! Strike with a standard staff.");
      }
    }

    public override string GetInfo() {
      return $"{Name} (Necromancer): HP {HP}, MP {MP}, Skeleton Bonus +{skeletonBonus}, Current Magic Damage {Damage + skeletonBonus}";
    }
  }
}