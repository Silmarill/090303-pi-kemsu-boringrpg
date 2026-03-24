using System;

namespace BoringRPG.Skills
{
  internal class SoulLink : Skill
  {
    public SoulLink() : base("SoulLink")
    {
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int totalHP = caster.HP + target.HP;
      int newHP = totalHP / 2;

      caster.HP = newHP;
      target.HP = newHP;
    }
  }
}