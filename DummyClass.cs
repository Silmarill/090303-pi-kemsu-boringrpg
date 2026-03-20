using System;

namespace BoringRPG {
  public class DummyClass : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3) {
    }

    // Перегрузка операторов с int
    public static DummyClass operator +(DummyClass hero, int amount) {
      hero.HP += amount;

      if (hero.HP > 100) {
        hero.HP = 100;
      }

      return hero;
    }

    public static DummyClass operator -(DummyClass hero, int amount) {
      hero.HP -= amount;

      if (hero.HP < 0) {
        hero.HP = 0;
      }

      return hero;
    }

    // Перегрузка операторов true/false
    public static bool operator true(DummyClass hero) {
      return hero.HP > 0;
    }

    public static bool operator false(DummyClass hero) {
      return hero.HP <= 0;
    }

    // Перегрузка оператора + для HealthPotion
    public static DummyClass operator +(DummyClass hero, HealthPotion potion) {
      hero.HP += potion.Value;

      if (hero.HP > 100) {
        hero.HP = 100;
      }

      Console.WriteLine($"{hero.Name} uses {potion.Name} and restores {potion.Value} HP!");
      return hero;
    }

    // Перегрузка оператора + для ManaPotion
    public static DummyClass operator +(DummyClass hero, ManaPotion potion) {
      hero.MP += potion.Value;

      if (hero.MP > 50) {
        hero.MP = 50;
      }

      Console.WriteLine($"{hero.Name} uses {potion.Name} and restores {potion.Value} MP!");
      return hero;
    }

    // Перегрузка оператора + для StrengthPotion
    public static DummyClass operator +(DummyClass hero, StrengthPotion potion) {
      hero.Damage += potion.Value;

      Console.WriteLine($"{hero.Name} uses {potion.Name} and gains {potion.Value} damage!");
      return hero;
    }

    // Перегрузка операторов +, -, * для DivineTalisman
    public static DummyClass operator +(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} has no energy!");
        return hero;
      }

      hero.HP += talisman.Value;
      hero.MP += talisman.Value / 2;
      hero.Damage += talisman.Value;

      if (hero.HP > 100) {
        hero.HP = 100;
      }
      if (hero.MP > 50) {
        hero.MP = 50;
      }

      Console.WriteLine($"{hero.Name} receives blessing from {talisman.Name}!");
      Console.WriteLine($"  HP +{talisman.Value}!");
      Console.WriteLine($"  MP +{talisman.Value / 2}!");
      Console.WriteLine($"  Damage +{talisman.Value}!");

      talisman.ReduceCharge(talisman.Value);
      Console.WriteLine($"  Energy left: {talisman.DivineCharge}");

      return hero;
    }

    public static DummyClass operator -(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} has no energy!");
        return hero;
      }

      int cursePower = talisman.Value * 2;

      hero.HP -= cursePower;
      hero.MP -= cursePower / 2;
      hero.Damage -= talisman.Value;

      if (hero.HP < 0) {
        hero.HP = 0;
      }
      if (hero.MP < 0) {
        hero.MP = 0;
      }
      if (hero.Damage < 1) {
        hero.Damage = 1;
      }

      Console.WriteLine($"{hero.Name} receives CURSE from {talisman.Name}!!!");
      Console.WriteLine($"  HP -{cursePower}!");
      Console.WriteLine($"  MP -{cursePower / 2}!");
      Console.WriteLine($"  Damage -{talisman.Value}!");

      talisman.ReduceCharge(cursePower);
      Console.WriteLine($"  Energy left: {talisman.DivineCharge}");

      return hero;
    }

    public static DummyClass operator *(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} has no energy!");
        return hero;
      }

      int effect = random.Next(1, 101);

      Console.WriteLine($"{hero.Name} activates DIVINE INTERVENTION!");

      if (effect <= 30) {
        hero.HP = 100;
        hero.MP = 50;
        hero.Damage = 20;
        Console.WriteLine($"MIRACLE! {hero.Name} is fully healed by divine power!");
      }
      else if (effect <= 60) {
        hero.HP /= 2;
        hero.MP /= 2;
        Console.WriteLine($"DIVINE WRATH! {hero.Name} loses half HP and MP!");
      }
      else if (effect <= 85) {
        hero.HP = 999;
        Console.WriteLine($"IMMORTALITY! {hero.Name} receives 999 HP!");
      }
      else {
        Console.WriteLine($"ASCENSION! {hero.Name} leaves this world...");
        hero.HP = 0;
      }

      talisman.ReduceCharge(talisman.DivineCharge);
      Console.WriteLine($"  {talisman.Name} has exhausted all energy!");

      return hero;
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name}: HP {HP}/100, MP {MP}/50, Ammo {Ammo}, Damage {Damage}, Crit chance {CritChance * 100}%";
    }
  }
}