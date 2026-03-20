using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  public abstract class Skill {
    public string Name { get; protected set; }
    protected Skill(string name) {
      Name = name;
    }   
    
  internal abstract void Use(Archetype caster, Archetype target);
  }
}
