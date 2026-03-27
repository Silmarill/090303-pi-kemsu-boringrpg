// Абстрактный класс для всех будущих способностей
namespace BoringRPG {
  internal abstract class Skill {
    public string Name { get; protected set; }
    public abstract string Use(Archetype caster, Archetype target);
  }
}