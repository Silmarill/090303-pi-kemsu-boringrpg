using System;

namespace BoringRPG
{
  internal class Paladin : Archetype, ICanUseSkill
  {
    private static Random random = new Random();
    public Paladin(string name) : base(name, 100, 40, 0, 20, 0.10)
    {
      // HP=100, MP=40, Ammo=0, Damage=20, CritChance=0.10 (10%)
    }

    public static Paladin operator +(Paladin paladin, HealthPotion health)
    {
      paladin.HP += health.Value;
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, ManaPotion mana)
    {
      paladin.MP += mana.Value;
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, AmmoPack ammo)
    {
      paladin.Ammo += ammo.Value;
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, CrabSticks crab)
    {
      paladin.Damage += crab.Value;
      return paladin;
    }

    public static Paladin operator +(Paladin paladin, int amount)
    {
      paladin.HP += amount;
      return paladin;
    }

    public static Paladin operator -(Paladin paladin, int amount)
    {
      paladin.HP = Math.Max(0, paladin.HP - amount);
      return paladin;
    }

    public void UseSkill(Skill skill, Archetype target)
    {
      skill.Use(this, target);
    }

    public override void Hit(Archetype target)
    {
      int damage = Damage;

      if (MP >= 10)
      {
        MP = Math.Max(0, MP - 10);
        damage += 5;
      }

      LastHitWasCrit = random.NextDouble() < CritChance;
      if (LastHitWasCrit)
      {
        damage *= 2;
      }

      target.HP = Math.Max(0, target.HP - damage);
    }

    public override string GetInfo()
    {
      return $"{Name} (Mateus Paladinov): HP {HP}, MP {MP}, Ammo {Ammo}, CritChance {CritChance * 100}%";
    }

    public bool LastHitWasCrit { get; private set; }
  }
}