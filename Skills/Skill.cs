using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal abstract class Skill {
    public string Name { get; set; }

    public Skill(string name) {
      Name = name;
    }

    public abstract void Use(Archetype caster, Archetype target);
  }
}