using System;
using BoringRPG.Items;
using BoringRPG.Skills;

namespace BoringRPG
{
  internal class Berserker : Archetype, ICanUseSkill
  {
    public static Random random = new Random();
    public bool LastHitWasCrit;
    private readonly int maxHP;

    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15)
    {
      maxHP = 140;
    }

    public void UseSkill(Skill skill, Archetype target)
    {
      skill.Use(this, target);
    }

    public static Berserker operator +(Berserker berserker, ManaPotion potion)
    {
      berserker.MP += potion.Value;
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, AmmoPack ammo)
    {
      berserker.Ammo += ammo.Value;
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, BerserkerElixir elixir)
    {
      berserker.HP -= 20;
      berserker.Damage += 15;
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, CrazyPotion potion)
    {
      berserker.HP += potion.Value;
      if (berserker.HP > berserker.maxHP)
      {
        berserker.HP = berserker.maxHP;
      }
      berserker.Damage += 20;
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, int amount)
    {
      berserker.HP += amount;
      if (berserker.HP > berserker.maxHP)
      {
        berserker.HP = berserker.maxHP;
      }
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int amount)
    {
      berserker.HP -= amount;
      if (berserker.HP < 0)
      {
        berserker.HP = 0;
      }
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

      Berserker berserkerTarget;
      if (target is Berserker)
      {
        berserkerTarget = (Berserker)target;
        berserkerTarget -= damage;
      }
      else
      {
        target.HP -= damage;
      }
    }

    public override string GetInfo()
    {
      string status;
      if (this)
      {
        status = "Жив";
      }
      else
      {
        status = "Повержен";
      }
      return $"{Name} (Berserker): HP {HP}/{maxHP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Шанс крита {CritChance * 100}%, Статус: {status}";
    }
  }
}