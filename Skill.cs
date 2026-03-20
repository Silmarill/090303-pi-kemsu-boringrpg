using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  abstract class Skill {
    public string Name;
    
    public Skill(string name) {
            Name = name;
    }
    public abstract void Use(Archetype caster, Archetype target); 
  }
}
