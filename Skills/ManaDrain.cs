using System;

namespace BoringRPG
{
  public class ManaDrain : Skill
  {
    public ManaDrain() : base("ManaDrain") { }

    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmount;

      drainAmount = target.MP / 2;
      target.MP -= drainAmount;
      caster.MP += drainAmount;
    }
  }
}
