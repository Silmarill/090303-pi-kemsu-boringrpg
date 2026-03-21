using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  class ManaDrain : Skill {
    
    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"{caster.Name} Использует ManaDrain на {target.Name}");
      target.MP -= 30;
      caster.MP += 30;
    }
  }
}
