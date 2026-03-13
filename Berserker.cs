using System;

namespace BoringRPG
{
  internal class Berserker : Archetype
  {

    public static Random random = new Random();
    public bool LastHitWasCrit;
    private int maxHP;

    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15)
    {
      maxHP = 140;
    }

    public static Berserker operator +(Berserker berserker, int amount)
    {
      berserker.HP += amount;
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int amount)
    {
      berserker.HP -= amount;
      return berserker;
    }

    public static bool operator true(Berserker berserker)
    {
      return berserker.HP > 0;
    }

    public static bool operator false(Berserker berserker)
    {
      return berserker.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      int damage = Damage;

      int rageBonus = (maxHP - HP) / 2;
      damage += rageBonus;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        damage *= 2;
      }

      if (target is Berserker berserkerTarget)
      {
        berserkerTarget -= damage;
      }
      else
      {
        target.HP -= damage;
      }
    }

    public override string GetInfo()
    {
      string status = this ? "Жив" : "Повержен";
      return $"{Name} (Berserker): HP {HP}/{maxHP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Шанс крита {CritChance * 100}%, Статус: {status}";
    }
  }
}