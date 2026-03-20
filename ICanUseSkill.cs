using System;

namespace BoringRPG {
  interface ICanUseSkill {
    void UseSkill(ICanUseSkill skill, Archetype target);
  }
}
