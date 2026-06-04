using System;

namespace BoringRPG
{
  class ManaDrain : Skill
  {
    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmount;
      drainAmount = Math.Min(20, target.MP);
      if (drainAmount > 0)
      {
        target.MP = Math.Max(0, target.MP - drainAmount);
        caster.MP += drainAmount;
      }
    }
  }
}