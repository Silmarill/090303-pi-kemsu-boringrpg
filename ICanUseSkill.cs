using System;

namespace BoringRPG.Skills.Interfaces {
  public interface ICanUseSkill {
    void UseSkill(Skill skill, Archetype target);
  }
}