using BoringRPG.Skills;

namespace BoringRPG
{
  interface ICanUseSkill
  {
    void UseSkill(Skill skill, Archetype target);
  }
}