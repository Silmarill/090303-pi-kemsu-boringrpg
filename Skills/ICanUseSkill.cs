// An interface, that will allow heroes to use skills
namespace BoringRPG {
  internal interface ICanUseSkill {
    void UseSkill(Skill skill, Archetype target);
  }
}