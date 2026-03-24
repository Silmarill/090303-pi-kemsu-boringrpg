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

      Console.WriteLine($"{caster.Name} использует пассивный навык - презрение к врагам");

      int basicPercentage = 100;
      int gainPercentage = 110;
      int percentageReduction = 90;
      if (random.NextDouble() < chanceRidicule) {
        
        caster.HP += ((target.HP / basicPercentage * gainPercentage) - target.HP);
        double casterMP = caster.MP + (((double)target.MP / basicPercentage * gainPercentage) - target.MP);
        caster.MP = (int)casterMP;
        caster.Ammo += ((target.Ammo / basicPercentage * gainPercentage) - target.Ammo);
        caster.Damage += ((target.Damage / basicPercentage * gainPercentage) - target.Damage);
        caster.CritChance += ((target.CritChance / basicPercentage * gainPercentage) - target.CritChance);

        target.HP = target.HP / basicPercentage * percentageReduction;
        target.MP = target.MP / basicPercentage * percentageReduction;
        target.Ammo = target.Ammo / basicPercentage * percentageReduction;
        target.Damage = target.Damage / basicPercentage * percentageReduction;
        target.CritChance = target.CritChance / basicPercentage * percentageReduction;

        Console.WriteLine($"{caster.Name} насмехается над {target.Name}!!!\n" +
                          $"{caster.Name} украл 10% характеристик {target.Name}!!!");
      } else {
        Console.WriteLine($"{target.Name} игнорирует насмешки {caster.Name}");
      }
    }
  }
}
