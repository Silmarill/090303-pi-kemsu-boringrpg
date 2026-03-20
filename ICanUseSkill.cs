using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG { 
  interface ICanUseSkill { 
    void Use(Skill skill, Archetype target);
  }
}
