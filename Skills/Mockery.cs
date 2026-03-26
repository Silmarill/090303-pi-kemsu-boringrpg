using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG.Skills {
  internal class Mockery : Skill {

    private static Random random = new Random();
    double chanceRidicule = 0.5;
    int skillTime;

    public Mockery(int time) {
      skillTime = time;
    }

    public override void Use(Archetype caster, Archetype target) {

      Console.WriteLine($"{caster.Name} использует навык - насмешка");
      int basicPercentage = 100;
      int gainPercentage = 110;
      int percentageReduction = 90;

      for (int indexI = 1; indexI <= skillTime; ++indexI) {
        if (random.NextDouble() < chanceRidicule) {
          double casterMP;
          double casterDamage;
          double casterHP;

          casterHP = caster.HP + (((double)target.HP / basicPercentage * gainPercentage) - target.HP);
          caster.HP = (int)casterHP;
          casterMP = caster.MP + (((double)target.MP / basicPercentage * gainPercentage) - target.MP);
          caster.MP = (int)casterMP;
          casterDamage = caster.Damage +(((double)target.Damage / basicPercentage * gainPercentage) - target.Damage);
          caster.Damage = (int)casterDamage;
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
}
