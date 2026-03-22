using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract class for all future abilities
namespace BoringRPG {
  internal abstract class Skill {
    public string Name { get; protected set; }
    public abstract void Use(Archetype caster, Archetype target);
  }
}