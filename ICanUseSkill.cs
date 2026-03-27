using System;
using BoringRPG.Models;

namespace BoringRPG.Skills {
  public interface ICanUseSkill {
    string UseSkill(Skill skill, Archetype target);
  }
}