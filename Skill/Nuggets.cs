using System;

namespace BoringRPG
{
  class Nuggets : Skill
  {
    private static readonly Random random = new Random();

    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmount = random.Next(10, 31);

      if (target.HP >= drainAmount)
      {
        target.HP = Math.Max(0, target.HP - drainAmount);
        caster.HP += drainAmount;
      }
    }
  }
}