using BoringRPG;
  
namespace BoringRPG {
  internal class Taunt : Skill {
  
    public override void Use(Archetype caster, Archetype target) {
      string name = Name;
      target.CritChance /= 2;
    }
  }
}