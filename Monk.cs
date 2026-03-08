using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class Monk : Archetype {
    public int _hitCounter;
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Monk(string name) : base(name, 95, 0, 0, 22, 0.12)
    {
      _hitCounter = 0;
    }

    public static Monk operator +(Monk monk, int pink)
    {
      monk.HP += pink;
      return monk;
    }

    public static Monk operator -(Monk monk, int pink)
    {
      monk.HP -= pink;
      return monk;
    }

    public static bool operator true(Monk monk)
    {
      return monk.HP > 0;
    }

    public static bool operator false(Monk monk)
    {
      return monk.HP <= 0;
    }

    public override void Hit(Archetype target)
    {
      _hitCounter++;

      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;
      if (LastHitWasCrit)
      {
        damage *= 2;
      }

      if (_hitCounter % 3 == 0)
      {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo()
    {
      return $"{Name} (Monk): HP {HP}, MP {MP}, Ammo {Ammo}, Урон {Damage}, Шанс крита {CritChance * 100}%.";
    }
  }
}