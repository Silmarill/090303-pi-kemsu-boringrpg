using System;

namespace BoringRPG.Skills
{
  internal interface ICanUseSkill
  {
    void UseSkill(Skill skill, Archetype target);
  }
}