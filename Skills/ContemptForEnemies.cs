using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG.Skills {
  internal class ContemptForEnemies : Skill {

    private static Random random = new Random();
    double chanceRidicule = 0.5;

    public ContemptForEnemies() {
    }

    public override void Use(Archetype caster, Archetype target) {

      int basicPercentage = 100;
      int gainPercentage = 110;
      int percentageReduction = 90;

      caster.HP = caster.HP / basicPercentage * gainPercentage;
      caster.MP = caster.MP / basicPercentage * gainPercentage;
      caster.Ammo = caster.Ammo / basicPercentage * gainPercentage;
      caster.Damage = caster.Damage / basicPercentage * gainPercentage;
      caster.CritChance = caster.CritChance / basicPercentage * gainPercentage;

      if (random.NextDouble() < chanceRidicule) {
        Console.WriteLine($"{caster.Name} насмехается над {target.Name} ");
        target.HP = target.HP / basicPercentage * percentageReduction;
        target.MP = target.MP / basicPercentage * percentageReduction;
        target.Ammo = target.Ammo / basicPercentage * percentageReduction;
        target.Damage = target.Damage / basicPercentage * percentageReduction;
        target.CritChance = target.CritChance / basicPercentage * percentageReduction;
      }
    }
  }
}
