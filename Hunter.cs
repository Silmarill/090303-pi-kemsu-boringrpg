using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG
{
  internal class Hunter : Archetype
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;


    public Hunter(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 85, 20, 15, 25, 0.20)
    {
    }
    public Hunter(string name) : base(name, 100, 50, 10, 20, 0.3)
    {
    }

    public static Hunter operator +(Hunter hunter, int amount)
    {
      hunter.HP += amount;
      return hunter;
    }
    public static Hunter operator -(Hunter hunter, int amount)
    {
      hunter.HP -= amount;
      return hunter;
    }

    public static bool operator true(Hunter hunter)
    {
      return hunter.HP > 0;
    }

    public static bool operator false(Hunter hunter)
    {
      return hunter.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      if (Ammo > 0)
      {
        Ammo--;
        int damage = Damage;

        if (target.HP > this.HP)
        {
          damage += 10;
        }

        LastHitWasCrit = random.NextDouble() < CritChance;
        if (LastHitWasCrit)
        {
          damage *= 2;
        }

        target.HP -= damage;
      }
      else
      {
        LastHitWasCrit = false;
      }
    }

    public override string GetInfo()
    {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}