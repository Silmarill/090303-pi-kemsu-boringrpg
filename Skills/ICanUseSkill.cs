using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// An interface, that will allow heroes to use skills
namespace BoringRPG {
  internal interface ICanUseSkill {
    void UseSkill(Skill skill, Archetype target);
  }
}