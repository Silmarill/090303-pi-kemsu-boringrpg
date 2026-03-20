using System;

namespace BoringRPG {
  internal class BerserkerClass : Archetype {

    private static Random random = new Random();
    private int maxHP;
    public bool LastHitWasCrit;

    public BerserkerClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, hp, mp, ammo, dmg, crit) {
      maxHP = hp;
    }

    public BerserkerClass(string name) : base(name, 140, 0, 0, 30, 0.15) {
      maxHP = 140;
    }

    public override void Hit(Archetype target) {
      int rageBonus = (maxHP - HP) / 2;
      int damage = Damage + rageBonus;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public static Archetype operator +(Archetype hero, ConsumableItem item)
    {
      return hero;
    }

    public static Archetype operator *(Archetype hero, CoffeeCup cup)
    {
      return hero;
    }

      public override string GetInfo() {
      int rageBonus = (maxHP - HP) / 2;
      return Name + " (Berserker): HP " + HP + "/" + maxHP +
             ", MP " + MP + ", Ammo " + Ammo +
             ", Damage " + Damage + " (+" + rageBonus + " rage)" +
             ", Шанс крита " + (CritChance * 100) + "%";
    }
  }
}
