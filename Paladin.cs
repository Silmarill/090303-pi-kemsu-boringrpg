using System;

namespace BoringRPG
{
  internal class Paladin : Archetype
  {
    private static Random random = new Random();
    public Paladin(string name) : base(name, 100, 40, 0, 20, 0.10)
    {
      // HP=100, MP=40, Ammo=0, Damage=20, CritChance=0.10 (10%)
    }

    public static Paladin operator +(Paladin paladin, HealthPotion health)
    {
      paladin.HP += health.Value;
      Console.WriteLine($"{paladin.Name} drink a health potion +{health.Value} HP");
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, ManaPotion mana)
    {
      paladin.MP += mana.Value;
      Console.WriteLine($"{paladin.Name} drink a mana potion +{mana.Value} MP");
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, AmmoPack ammo)
    {
      paladin.Ammo += ammo.Value;
      Console.WriteLine($"{paladin.Name} take box with ammo +{ammo.Value} Ammo");
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, CrabSticks crab)
    {
      paladin.Damage += crab.Value;
      Console.WriteLine($"{paladin.Name} eat CrabSticks +{crab.Value} Damage");
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, int amount)
    {
      paladin.HP += amount;
      return paladin;
    }

    public static Paladin operator -(Paladin paladin, int amount)
    {
      paladin.HP -= amount;
      return paladin;
    }

    public static bool operator true(Paladin paladin)
    {
      return paladin.HP > 0;
    }

    public static bool operator false(Paladin paladin)
    {
      return paladin.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      int damage = Damage;

      if (MP >= 10)
      {
        MP -= 10;
        damage += 5;

        LastHitWasCrit = random.NextDouble() < CritChance;
        if (LastHitWasCrit)
        {
          damage *= 2;
        }
      }
      else
      {
        LastHitWasCrit = random.NextDouble() < CritChance;
        if (LastHitWasCrit)
        {
          damage *= 2;
        }
      }

      if (target is Paladin paladinTarget)
      {
        paladinTarget -= damage;
      }
      else
      {
        target.HP -= damage;
      }
    }

    public override string GetInfo()
    {
      return $"{Name} (Mateus Paladinov): HP {HP}, MP {MP}, Ammo {Ammo}, CritChance {CritChance * 100}%";
    }

    public bool LastHitWasCrit { get; private set; }
  }
}