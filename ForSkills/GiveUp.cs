using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  class  GiveUp : Skill {
    
    public override void Use(Archetype caster, Archetype target) {
      caster.HP -= caster.HP;
    }
  }
}
