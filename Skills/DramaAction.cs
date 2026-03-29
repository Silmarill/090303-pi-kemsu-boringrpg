using System;

namespace BoringRPG {
  internal class DramaAction : Skill {
    static Random random = new Random();
    int chance;
    int firstChancePoint = 30;
    int secondChancePoint = 60;

    public DramaAction() : base("DramaAction") { 
    }

    public override void Use(Archetype caster, Archetype target) {
      chance = random.Next(100);

      if (chance < firstChancePoint) { 
        string oldName = target.Name;
        target.Name = "Побежденный" + oldName;
      } else if (chance < secondChancePoint) { 
        string oldName = caster.Name;
        caster.Name = "Легендарный" + oldName;
      }
    }
  }
}
