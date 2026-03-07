using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class Hunter : Archetype {

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
        man.HP = man.HP - (damage - man.Ammo);
        if (man.HP < 0) {
          man.HP = 0;
          return man;
        }
      }
      return man;

    }



    public override string GetInfo() {
      return $"{Name} (Hunter): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance: {CritChance * 100}%";
    }
  }

}

