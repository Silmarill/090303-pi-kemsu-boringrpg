using System;

namespace BoringRPG
{
  internal class Archer : Archetype
  {
    private static Random random = new Random();
    public bool lastHitWasCrit;

    public Archer(string name, int hp = 80, int mp = 30, int ammo = 20, int dmg = 20, double crit = 0.25) : base(name, hp, mp, ammo, dmg, crit)
    {
    }

    public static Archer operator +(Archer myArcher, int amount)
    {
      myArcher.HP += amount;
      return myArcher;
    }

    public static Heal operator +(Archer myArcher, Heal poisonHP)
    {
      myArcher.HP += poisonHP.Value;
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

    public int RandomEvent(Archer myArcher)
    {
      int randomInt;
      int randomNumberHP;

      randomInt = random.Next(0, 3);
      randomNumberHP = random.Next(-20, 21);

      if (randomNumberHP > 0)
      {
        myArcher = myArcher + randomNumberHP;

        return randomNumberHP;
      }
      else if (randomNumberHP < 0)
      {
        myArcher = myArcher - randomNumberHP;

        return randomNumberHP;
      }
      else
      {
        return randomNumberHP;
      }
    }

    public override void Hit(Archetype target)
    {
      int damage;
      damage = Damage;

      lastHitWasCrit = random.NextDouble() < CritChance;

      if (lastHitWasCrit)
      {
        damage *= 2;
      }

      if (Ammo > 0)
      {
        --Ammo;
      }
      else
      {
        damage = 0;
      }

      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name} (Archer): HP: {HP}, MP: {MP}, Ammo: {Ammo}, Crit chance: {CritChance * 100}%";
    }
  }
}