using System;

namespace BoringRPG
{
  internal class Archer : Archetype
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Archer(string name, int hp = 80, int mp = 30, int ammo = 20, int dmg = 20, double crit = 0.25) : base(name, hp, mp, ammo, dmg, crit)
    {
    }

    public static Archer operator +(Archer myArcher, int amount)
    {
      myArcher.HP += amount;
      return myArcher;
    }

    public static Archer operator -(Archer myArcher, int amount)
    {
      myArcher.HP -= amount;
      return myArcher;
    }

    public static bool operator true(Archer myArcher)
    {
      return myArcher.HP > 0;
    }

    public static bool operator false(Archer myArcher)
    {
      return myArcher.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      int damage;
      damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        damage *= 2;

      }

      if (Ammo > 0)
      {
        --Ammo;
        Console.WriteLine($"{Name} took a shot, number of arrows: {Ammo}");
      }
      else
      {
        damage = 0;
        Console.WriteLine($"{Name} has no arrows. Damage = 0");
      }

      if (target is Archer archerTarget)
      {
        archerTarget = archerTarget - damage;
      }
      else
      {
        target.HP -= damage;
      }
    }

    public override string GetInfo()
    { 
      return $"{Name} (Archer): HP: {HP}, MP: {MP}, Ammo: {Ammo}, Crit chance: {CritChance * 100}%";
    }
  }
}