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
            Console.WriteLine($"{caster.Name} использовал DestinyShuffle. {caster.Name} и {target.Name} поменялись HP.\n");
            break;

          case 2:
            int temporaryMP = caster.MP;
            caster.MP = target.HP;
            target.HP = temporaryMP;
            Console.WriteLine($"{caster.Name} использовал DestinyShuffle. {caster.Name} поменял MP на HP {target.Name}, {target.Name} поменял HP на MP {caster.Name}.\n");
            break;

          case 3:
            int temporaryDamage = caster.Damage;
            caster.Damage = Convert.ToInt32(target.CritChance * 100);
            target.CritChance = temporaryDamage / 100.0;
            Console.WriteLine($"{caster.Name} использовал DestinyShuffle. {caster.Name} поменял Damage на CritChance {target.Name}, {target.Name} поменял CritChance на Damage {caster.Name}.\n");
            break;
        }
      }
    }
  }
}
