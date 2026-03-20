using System;

namespace BoringRPG {
  public class Cleric : Archetype, ICanUseSkill {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05) {
    }

    // Реализация интерфейса ICanUseSkill
    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }

    // Перегрузка операторов с int
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

    // Перегрузка операторов true/false
    public static bool operator true(Cleric cleric) {
      return cleric.HP > 0;
    }

    public static bool operator false(Cleric cleric) {
      return cleric.HP <= 0;
    }

    // Перегрузка оператора + для HealthPotion
    public static Cleric operator +(Cleric hero, HealthPotion potion) {
      hero.HP += potion.Value;

      if (hero.HP > 75) {
        hero.HP = 75;
      }

      Console.WriteLine($"{hero.Name} uses {potion.Name} and restores {potion.Value} HP!");
      return hero;
    }

    // Перегрузка оператора + для ManaPotion
    public static Cleric operator +(Cleric hero, ManaPotion potion) {
      hero.MP += potion.Value;

      if (hero.MP > 80) {
        hero.MP = 80;
      }

      Console.WriteLine($"{hero.Name} uses {potion.Name} and restores {potion.Value} MP!");
      return hero;
    }

    // Перегрузка оператора + для StrengthPotion
    public static Cleric operator +(Cleric hero, StrengthPotion potion) {
      hero.Damage += potion.Value;

      Console.WriteLine($"{hero.Name} uses {potion.Name} and gains {potion.Value} damage!");
      return hero;
    }

    // Перегрузка операторов +, -, * для DivineTalisman
    public static Cleric operator +(Cleric hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} has no energy!");
        return hero;
      }

      hero.HP += talisman.Value;
      hero.MP += talisman.Value;
      hero.Damage += talisman.Value / 2;

      if (hero.HP > 75) {
        hero.HP = 75;
      }
      if (hero.MP > 80) {
        hero.MP = 80;
      }

      Console.WriteLine($"{hero.Name} receives blessing from {talisman.Name}!");
      Console.WriteLine($"  HP +{talisman.Value}!");
      Console.WriteLine($"  MP +{talisman.Value}!");
      Console.WriteLine($"  Damage +{talisman.Value / 2}!");

      talisman.ReduceCharge(talisman.Value);
      Console.WriteLine($"  Energy left: {talisman.DivineCharge}");

      return hero;
    }

    public static Cleric operator -(Cleric hero, DivineTalisman talisman) {
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

    public static Cleric operator *(Cleric hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} has no energy!");
        return hero;
      }

      int effect = random.Next(1, 101);

      Console.WriteLine($"{hero.Name} activates DIVINE INTERVENTION!");

      if (effect <= 30) {
        hero.HP = 75;
        hero.MP = 80;
        hero.Damage = 15;
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
      return $"{Name}: HP {HP}/75, MP {MP}/80, Ammo {Ammo}, Damage {Damage}, Crit chance {CritChance * 100}%";
    }
  }
}