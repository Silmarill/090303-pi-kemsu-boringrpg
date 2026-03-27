using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG {
  public class DestinyShuffle : Skill {
    private static Random random = new Random();

    public DestinyShuffle() {
      Name = "DestinyShuffle";
    }

    internal override void Use(Archetype caster, Archetype target) {
      for (int swapIndex = 0; swapIndex < 3; ++swapIndex) {
        switch (random.Next(1, 4)) {
          case 1:
            int temporaryHP = caster.HP;
            caster.HP = target.HP;
            target.HP = temporaryHP;
            break;

          case 2:
            int temporaryMP = caster.MP;
            caster.MP = target.HP;
            target.HP = temporaryMP;
            break;

          case 3:
            int temporaryDamage = caster.Damage;
            caster.Damage = Convert.ToInt32(target.CritChance * 100);
            target.CritChance = temporaryDamage / 100.0;
            break;
        }
      }
    }
  }
}
