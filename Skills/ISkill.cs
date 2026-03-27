using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  interface ISkill
  {
    void UseSkill(Skill skill, Archetype target);
  }

  abstract class Skill
  {
    public string Name;
    public abstract void Use(Archetype caster, Archetype target);
  }
}

