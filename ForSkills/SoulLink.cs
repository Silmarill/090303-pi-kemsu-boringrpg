using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG { 
  class SoulLink : Skill {
    int soulHP;

    public override void Use(Archetype caster, Archetype target) {
      soulHP = (caster.HP + target.HP) / 2;
      caster.HP = soulHP;
      target.HP = soulHP;
    }
  }
}