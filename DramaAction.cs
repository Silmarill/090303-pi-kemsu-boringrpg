using System;

namespace BoringRPG {
  internal class DramaAction : Skill {
    static Random random = new Random();

    public DramaAction() : base("DramaAction") { 
    }

    public overrise void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"{caster.Name} использует навык {Name} на {target.Name}");

      //В процессе
    }
  }
}
