using System;

namespace BoringRPG
{
  internal class Berserker : Archetype
  {

    public static Random random = new Random();
    public bool LastHitWasCrit;
    private readonly int maxHP;

    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15)
    {
      maxHP = 140;
    }

    public static Berserker operator +(Berserker berserker, ManaPotion potion)
    {
      Console.WriteLine($"Использовано: {potion.GetDescription()}");
      berserker.MP += potion.Value;
      Console.WriteLine($"Мана: {berserker.MP} MP\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, AmmoPack ammo)
    {
      Console.WriteLine($"Использовано: {ammo.GetDescription()}");
      berserker.Ammo += ammo.Value;
      Console.WriteLine($"Патроны: {berserker.Ammo}\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, BerserkerElixir elixir)
    {
      Console.WriteLine($"Использовано: {elixir.GetDescription()}");
      berserker.HP -= 20;
      berserker.Damage += 15;
      Console.WriteLine($"HP: {berserker.HP}/{berserker.maxHP}");
      Console.WriteLine($"Урон: {berserker.Damage}\n");
      return berserker;
    }

    public static Berserker operator *(Berserker berserker, CrazyPotion potion)
    {
      Console.WriteLine($"Использовано: {potion.GetDescription()}");
      berserker.HP += potion.Value;
      if (berserker.HP > berserker.maxHP)
        berserker.HP = berserker.maxHP;
      berserker.Damage += 20;
      Console.WriteLine($"HP: {berserker.HP}/{berserker.maxHP}");
      Console.WriteLine($"Урон: {berserker.Damage}\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, int amount)
    {
      berserker.HP += amount;
      if (berserker.HP > berserker.maxHP)
        berserker.HP = berserker.maxHP;
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int amount)
    {
      berserker.HP -= amount;
      if (berserker.HP < 0)
        berserker.HP = 0;
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