using System;

namespace BoringRPG
{
  internal class DramaAction : Skill
  {
    private static Random random = new Random();

    public DramaAction() : base("DramaAction") { }

    public override void Use(Archetype caster, Archetype target)
    {
      int chance;
      chance = random.Next(100);

      if (chance < 30) {
        target.Name = "Побеждённый " + target.Name;
        Console.WriteLine($"{caster.Name} переименовал {target.Name} в Побеждённый!");
      } else if (chance < 60) {
        caster.Name = "Легендарный " + caster.Name;
        Console.WriteLine($"{caster.Name} переименовал себя в Легендарный!");
      } else {
        Console.WriteLine($"{caster.Name} дарит розу {target.Name}");
      }
    }
  }
}
