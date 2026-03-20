using System;

namespace BoringRPG {
  public class Monk : Archetype {
    public bool LastHitWasCrit;

    public Monk(string name) : base(name, 100, 50, 20, 15, 0.2) { }

    public static Monk operator +(Monk monk, int healthAmount)
    {
      monk.HP += healthAmount;
      return monk;
    }

    public static Monk operator -(Monk monk, int damageAmount)
    {
      monk.HP -= damageAmount;
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
      monk.HP += potion.Value;
      return monk;
    }

    public static Monk operator +(Monk monk, ManaPotion potion)
    {
      monk.MP += potion.Value;
      return monk;
    }

    public static Monk operator +(Monk monk, AmmoPack ammo)
    {
      monk.Ammo += ammo.Value;
      return monk;
    }

    public override void Hit(Archetype target)
    {
      Random rand = new Random();
      int damage = Damage;
      LastHitWasCrit = rand.NextDouble() < CritChance;

      if (LastHitWasCrit)
        damage *= 2;

      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name}: HP {HP}, MP {MP}, Патроны {Ammo}, Урон {Damage}, Крит {CritChance * 100}%";
    }
  }
}