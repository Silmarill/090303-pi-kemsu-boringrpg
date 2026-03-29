using System;

namespace BoringRPG
{
  class Nuggets : Skill
  {
    Random rand = new Random();

    public override void Use(Archetype caster, Archetype target)
    {
      int drainAmount = rand.Next(10, 31);

      if (target.HP >= drainAmount)
      {
        target.HP -= drainAmount;
        caster.HP += drainAmount;
      }
    }
  }
}