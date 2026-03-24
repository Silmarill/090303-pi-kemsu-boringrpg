using System;

namespace BoringRPG.Skills
{
  internal class DramaAction : Skill
  {
    private static Random random = new Random();

    public DramaAction() : base("DramaAction")
    {
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int chance = random.Next(1, 11);

      if (chance <= 3)
      {
        string oldName = target.Name;
        target.Name = "Побеждённый " + oldName;
      }
      else if (chance <= 6)
      {
        string oldName = caster.Name;
        caster.Name = "Легендарный " + oldName;
      }
    }
  }
}