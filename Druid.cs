using System;

namespace BoringRPG {
  public class Druid : Archetype {

    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name) : base(name, 90, 60, 0, 20, 0.10)
    {
    }

    public static Druid operator +(Druid druid, int amount)
    {
      druid.HP += amount;
      return druid;
    }

    public static Druid operator -(Druid druid, int amount)
    {
      druid.HP -= amount;
      return druid;
    }

    public static Druid operator +(Druid druid, ConsumableItem item)
    {
      item.ApplyEffect(druid);
      return druid;
    }

    public static bool operator true(Druid druid)
    {
      return druid.HP > 0;
    }

    public static bool operator false(Druid druid)
    {
      return druid.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      int baseDamage;
      int manaPoint;

      baseDamage = Damage;
      manaPoint = 5;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        baseDamage *= 2;
      }
      else if (MP >= manaPoint)
      {
        MP -= manaPoint;
      }
      else if (target.HP > 45)
      {
        baseDamage *= 2;
      }
      else
      {
        baseDamage = 0;
      }

      target.HP -= baseDamage;

    }

    public override string GetInfo()
    {
      return $"{Name} (Druid): HP {HP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Шанс крита {CritChance * 100}%";

    }
  }
}  




