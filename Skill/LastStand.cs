using System;

namespace BoringRPG
{
  internal class LastStand : Skill
  {
    public LastStand(string name, int mana) : base(name, mana)
    {    
    }

    public override void Use(Archetype caster, Archetype target)
    {
      caster.HP = target.Damage + 1;
    }
  }
}