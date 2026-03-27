// Abstract class for all future abilities
namespace BoringRPG {
  internal abstract class Skill {
    public string Name { get; protected set; }
    public abstract string Use(Archetype caster, Archetype target);
  }
}