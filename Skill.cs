using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG.Skills
{
  internal abstract class Skill
  {
    public string Name;
    public abstract void Use(Archetype caster, Archetype target);
  }
}
