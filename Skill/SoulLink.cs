using System;

namespace BoringRPG
{
  internal class SoulLink : Skill
  {   
    int resultCast = 0;

    public SoulLink(string name, int mana) : base(name, mana)
    {
    }

    public override void Use(Archetype caster, Archetype target)
    {
      resultCast = caster.HP + target.HP;
      resultCast /= 2;

      caster.HP = resultCast;
      target.HP = resultCast;
    }
  }
}