using BoringRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG.skills
{
  class ManaDrain : Skill
  {
    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmmount = Math.Min(20, target.MP);

      if (drainAmmount > 0)
      {
        target.MP -= drainAmmount;
        caster.MP += drainAmmount;
      }
    }
  }
}
