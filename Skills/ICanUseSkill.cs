// An interface, that will allow heroes to use skills
namespace BoringRPG {
  internal interface ICanUseSkill {
    string UseSkill(Skill skill, Archetype target);
  }
}