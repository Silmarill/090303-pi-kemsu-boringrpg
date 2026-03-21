using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG { 
  class SoulLink : Skill {
    int soulHP;
    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"{caster.Name} Использует SoulLink на {target.Name}");
      soulHP = (caster.HP + target.HP) / 2;
      caster.HP = soulHP;
      target.HP = soulHP;
    }
  }
}