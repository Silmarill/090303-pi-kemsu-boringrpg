using System;

namespace BoringRPG
{
  internal class HunterClass : Archetype, ICanUseSkill
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public HunterClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 85, 20, 15, 25, 0.2)
    {
    }

    public HunterClass(string name) : base(name, 85, 20, 15, 25, 0.2)
    {
    }

    public static HunterClass operator +(HunterClass hunter, int amount)
    {
      hunter.HP += amount;
      return hunter;
    }

    public static HunterClass operator -(HunterClass hunter, int amount)
    {
      hunter.HP -= amount;
      return hunter;
    }

    public static bool operator true(HunterClass hunter)
    {
      return hunter.HP > 0;
    }

    public static bool operator false(HunterClass hunter)
    {
      return hunter.HP <= 0;
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

      if (HP < target.HP)
      {
        damage += 10;
      }

      Ammo -= 1;
      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name} (Hunter): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }

    public void UseSkill(Skill skill, Archetype target)
    {
      skill.Use(this, target);
    }
  }
}