// Интерфейс, позволяющий героям использовать навыки
namespace BoringRPG {
  internal interface ICanUseSkill {
    string UseSkill(Skill skill, Archetype target);
  }
}