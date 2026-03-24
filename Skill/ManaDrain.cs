using System;

namespace BoringRPG
{
  internal class ManaDrain : Skill
  {
    public ManaDrain(string name, int mana) : base(name, mana)
    {
    }

    public override void Use(Archetype caster, Archetype target)
    {
      target.MP -= Mana;
      caster.MP += Mana;
    }
  }
}