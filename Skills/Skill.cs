using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  public abstract class Skill {
    public string Name;
    internal abstract void Use(Archetype caster, Archetype target);
  }
}
