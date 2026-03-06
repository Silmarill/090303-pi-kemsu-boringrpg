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
  internal class Hunter : DummyClass
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;
    public double CritChance;
    private int Damage;
    private int HP;
    private int Ammo;

    public Hunter(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 85, 20, 15, 25, 0.20)
    {
    }
    public Hunter(string name) : base(name, 100, 50, 10, 20, 0.3)
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

      if (target.HP > this.HP && this.Ammo > 0)
      {
        this.Ammo -= 1;
        damage += 10;
      }



      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }

    public static Hunter operator +(Hunter h1, Hunter h2)
    {
      string combinedName = $"(h1.Name)+(h2.Name)";
      int combinedHP = h1.HP + h2.HP;
      int combinedMP = h1.MP + h2.MP;
      int combinedAmmo = h1.Ammo + h2.Ammo;
      int combinedDamage = h1.Damage + h2.Damage;
      double combinedCrit = (h1.CritChance + h2.CritChance);

      return new Hunter(combinedHP, combinedMP, combinedAmmo, combinedDamage, combinedCrit);

      public static Hunter operator -(Hunter h1, Hunter h2)
    {
      string diffdName = $"(h1.Name)--(h2.Name)";
      int diffdHP = h1.HP - h2.HP;
      int diffdMP = h1.MP - h2.MP;
      int diffdAmmo = h1.Ammo - h2.Ammo;
      int diffDamage = h1.Damage - h2.Damage;
      double diffCrit = (h1.CritChance - h2.CritChance);
    }
  }
}

