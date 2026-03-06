using BoringRPG;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace work
{
  internal abstract class Warrior
  {

    public string Name;
    public int HP;
    public int MP;
    public int Ammo;
    public int Damage;
    public double CritChance;

    protected Warrior(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 120, 20, 0, 25, 0.1)
    {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = dmg;
      CritChance = crit;
    }

  internal class Warrior : Archetype
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public bool LastHitWasCrit {}

    public Warrior(string name) : base(name, 120, 20, 0, 25, 0.10)
    {
      LastHitWasCrit = false;
    }
    public static Warrior operator +(Warrior warrior, int amount)
    {
      warrior.HP += amount;
      return warrior;
    }

    public static Warrior operator -(Warrior warrior, int amount)
    {
      warrior.HP -= amount;
      return warrior;
    }

    public static bool operator true(Warrior warrior)
    {
      return warrior.HP > 0;
    }

    public static bool operator false(Warrior warrior)
    {
      return warrior.HP <= 0;
    }

    public override void Hit(Warrior target)
    {
      LastHitWasCrit = random.NextDouble() < CritChance;

      if (HP<=5)
      {
       Console.WriteLine($"\n{Name} cant do attack");

      }
      int damage = Damage + 5;


        if (LastHitWasCrit)
      {
        damage *= 2;
      }

      target.HP -= damage;
    }
    public virtual string GetInfo()
    {
      return $"Name: {Name}, HP: {HP}, MP: {MP}, Ammo: {Ammo}, Damage: {Damage}, Crit: {CritChance}";
    }
  }

}
