using System;

namespace BoringRPG {
  internal interface ICanUseSkill {
    void Use (Skill skill, Archetype target);
  }
}