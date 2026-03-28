using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class DramaAction : Skill {
    private static Random _random = new Random();
    public DramaAction() : base("DramaAction") { }

    public override void Use(Archetype caster, Archetype target) {
      int chance = _random.Next(100);

      if (chance < 30) {
        string oldName = target.Name;
        target.Name = "Побеждённый " + oldName;
      } else if (chance < 60) {
        string oldName = caster.Name;
        caster.Name = "Легендарный " + oldName;
      }
    }
  }
}