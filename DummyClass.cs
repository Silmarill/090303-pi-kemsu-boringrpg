using System;

namespace BoringRPG
{
  internal class DummyClass : Archetype
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 100, 50, 10, 20, 0.3)
    {
    }

    public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3)
    {
    }

    public override void Hit(Archetype target)
    {
      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Crit chance {CritChance * 100}%";
    }
  }
}
