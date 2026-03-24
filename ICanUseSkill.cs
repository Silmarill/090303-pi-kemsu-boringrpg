using System;

namespace BoringRPG.Interfaces {
  public interface ICanUseSkill {
    void UseSkill(Skill skill, ICanUseSkill target);
  }
}