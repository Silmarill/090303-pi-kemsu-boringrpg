using System;

namespace BoringRPG
{
  public class Warrior : Archetype
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Warrior(string name) : base(name, 120, 20, 0, 25, 0.10)
    {
      LastHitWasCrit = false;
    }

    public static Warrior operator +(Warrior warrior, int amount)
    {
      warrior.HP += amount;
      return warrior;
    }

    public static Warrior operator -(Warrior warrior, int amount)
    {
      warrior.HP -= amount;
      return warrior;
    }

    public static bool operator true(Warrior warrior)
    {
      return warrior.HP > 0;
    }

    public static bool operator false(Warrior warrior)
    {
      return warrior.HP <= 0;
    }

    public static Warrior operator +(Warrior warrior, HealthPotion potion)
    {
      warrior.HP += potion.Value;
      return warrior;
    }

    public static Warrior operator +(Warrior warrior, ManaPotion potion)
    {
      warrior.MP += potion.Value;
      return warrior;
    }

    public static Warrior operator +(Warrior warrior, AmmoPack pack)
    {
      warrior.Ammo += pack.Value;
      return warrior;
    }

    public static Warrior operator +(Warrior warrior, FatBurger burger)
    {
      warrior.MP += 20;
      warrior.Ammo += 20;
      return warrior;
    }

    public override void Hit(Archetype target)
    {
      if (HP <= 5) {
        LastHitWasCrit = false;
        return;
      }

      HP -= 5;
      int damage = Damage + 5;
      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name}: HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Crit {CritChance * 100}%";
    }
  }
}