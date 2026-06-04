using System;

namespace BoringRPG
{
  class SoulLink : Skill
  {
    public override void Use(Archetype caster, Archetype target)
    {
      int averageHP = (caster.HP + target.HP) / 2;
      caster.HP = averageHP;
      target.HP = averageHP;
    }
  }
}