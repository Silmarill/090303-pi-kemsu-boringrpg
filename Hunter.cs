using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class Hunter : Archetype {

    private static Random random = new Random();
    private bool LastHitWasCrit;

    protected Hunter(string name, int hp, int mp, int ammo, int dmg, double crit)
        : base("Divad", 85, 20, 15, 25, 0.2) { }

    public static Hunter operator +(Hunter man, int regain) {

      if (man.HP < 85) {
        man.HP = man.HP + regain;
        if (man.HP > 85) {
          man.HP = 85;
          return man;
        }
      }
      return man;

    }

    public static Hunter operator -(Hunter man, int damage) {

      if (man.HP > 0) {
        man.HP = man.HP - (damage - man.Ammo/2);
        if (man.HP < 0) {
          man.HP = 0;
          return man;
        }
      }
      return man;

    }

    public override void Hit(Archetype target) {

      int damage = Damage;
      if (this.Ammo > 0) {
        this.Ammo -= 1;
      }

      LastHitWasCrit = random.NextDouble() < 0.2;

      if (this.HP < target.HP) {
        damage += 10; 
      }
      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;

    }

    public override string GetInfo() {
      return $"{Name} (Hunter): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance: {CritChance * 100}%";
    }
  }

}

