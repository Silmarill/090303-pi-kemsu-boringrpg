using System;

namespace BoringRPG
{
  internal class Nekromaster : Archetype
  {
    private static Random random = new Random();
    private int _skeletonBonus;
    public bool LastHitWasCrit;

    public Nekromaster(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 55, 90, 0, 30, 0.1)
    {
      _skeletonBonus = 0;
    }

    public Nekromaster(string name) : base(name, 55, 90, 0, 30, 0.1)
    {
      _skeletonBonus = 0;
    }

    public static Nekromaster operator +(Nekromaster necromancer, HealPotion potion)
    {
      necromancer.HP += potion.Value;
      Console.WriteLine($"{necromancer.Name} выпил зелье здоровья +{potion.Value} HP");
      return necromancer;
    }

    public static Nekromaster operator +(Nekromaster necromancer, ManaPotion potion)
    {
      necromancer.MP += potion.Value;
      Console.WriteLine($"{necromancer.Name} выпил зелье маны +{potion.Value} MP");
      return necromancer;
    }

    public static Nekromaster operator +(Nekromaster necromancer, CocaCola coka)
    {
      necromancer.HP += coka.Value;
      necromancer.MP += coka.Value;
      necromancer.Damage += coka.Value;
      Console.WriteLine($"{necromancer.Name} выпил CocaCola +{coka.Value} HP, +{coka.Value} MP, +{coka.Value} Damage");
      return necromancer;
    }

    public static Nekromaster operator -(Nekromaster necromancer, int amount)
    {
      necromancer.HP -= amount;
      return necromancer;
    }

    public static bool operator true(Nekromaster necromancer)
    {
      return necromancer.HP > 0;
    }

    public static bool operator false(Nekromaster necromancer)
    {
      return necromancer.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      if (MP < 15)
      {
        LastHitWasCrit = false;
        return;
      }

      MP -= 15;

      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;
      if (LastHitWasCrit)
      {
        damage *= 2;
      }

      damage += _skeletonBonus;

      int targetHpBefore = target.HP;
      target.HP -= damage;

      if (target.HP < targetHpBefore)
      {
        _skeletonBonus += 5;
      }
    }

    public override string GetInfo()
    {
      return $"{Name} (Некромант): HP {HP}/55, MP {MP}/90, Damage {Damage}, Crit {CritChance * 100}%, SkeletonBonus +{_skeletonBonus}";
    }
  }
}
