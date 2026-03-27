using System;
using BoringRPG.Models;
using BoringRPG.Items;

namespace BoringRPG.Models {
  public class Monk : Archetype {
    public bool LastHitWasCrit;

    public int DefaultHp;
    public int DefaultMp;
    public int DefaultAmmo;
    public int DefaultDamage;
    public double DefaultCritChance;
    public int BreadMpPenalty;
    public int BreadAmmoPenalty;
    public int CritDamageMultiplier;
    public int PercentMultiplier;

    public Monk(string name) : base(name, 100, 50, 20, 15, 0.2)
    {
      LastHitWasCrit = false;
      DefaultHp = 100;
      DefaultMp = 50;
      DefaultAmmo = 20;
      DefaultDamage = 15;
      DefaultCritChance = 0.2;
      BreadMpPenalty = 10;
      BreadAmmoPenalty = 5;
      CritDamageMultiplier = 2;
      PercentMultiplier = 100;
    }

    public static Monk operator +(Monk monk, int healthAmount)
    {
      monk.HP = monk.HP + healthAmount;
      return monk;
    }

    public static Monk operator -(Monk monk, int damageAmount)
    {
      monk.HP = monk.HP - damageAmount;
      return monk;
    }

    public static bool operator true(Monk monk)
    {
      return monk.HP > 0;
    }

    public static bool operator false(Monk monk)
    {
      return monk.HP <= 0;
    }

    public static Monk operator +(Monk monk, HealthPotion potion)
    {
      monk.HP = monk.HP + potion.Value;
      return monk;
    }

    public static Monk operator +(Monk monk, ManaPotion potion)
    {
      monk.MP = monk.MP + potion.Value;
      return monk;
    }

    public static Monk operator +(Monk monk, AmmoPack ammo)
    {
      monk.Ammo = monk.Ammo + ammo.Value;
      return monk;
    }

    public static Monk operator +(Monk monk, FatBread bread)
    {
      int newHp;
      int newMp;
      int newAmmo;

      newHp = monk.HP + bread.Value;
      newMp = monk.MP - monk.BreadMpPenalty;
      newAmmo = monk.Ammo - monk.BreadAmmoPenalty;

      monk.HP = newHp;

      if (newMp < 0)
      {
        monk.MP = 0;
      }
      else
      {
        monk.MP = newMp;
      }

      if (newAmmo < 0)
      {
        monk.Ammo = 0;
      }
      else
      {
        monk.Ammo = newAmmo;
      }

      return monk;
    }

    public override void Hit(Archetype target)
    {
      Random rand;
      int damage;

      rand = new Random();
      damage = Damage;

      LastHitWasCrit = rand.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        damage = damage * CritDamageMultiplier;
      }

      target.HP = target.HP - damage;
    }

    public override string GetInfo()
    {
      return $"{Name}: HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Crit {CritChance * PercentMultiplier}%";
    }
  }
}