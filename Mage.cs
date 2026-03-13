using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class Mage : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Mage(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 60, 100, 0, 35, 0.05) {

    }

    public Mage(string name) : base(name, 60, 100, 0, 35, 0.05) {
    }

    public static Mage operator -(Mage mage, int dmg) {
      mage.HP -= dmg;
      return mage;
    }

    public static Mage operator +(Mage mage, int heal) {
      mage.HP += heal;
      return mage;
    }

    public static bool operator true(Mage mage) {
      return mage.HP > 0;
    }

    public static bool operator false(Mage mage) {
      return mage.HP <= 0;
    }


    public override void Hit(Archetype target) {
      int damage = Damage;
      int mp = MP;

      //Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      //target.HP -= damage;*/

      if (mp >= 10) {
        target.HP -= damage;
      } else {
        target.HP -= 0;
      }

    }

    public override string GetInfo() {
      return $"{Name} (Mage): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}
