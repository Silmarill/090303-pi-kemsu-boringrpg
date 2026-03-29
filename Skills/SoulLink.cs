using System;

namespace BoringRPG
{
  public class SoulLink : Skill
  {
    public SoulLink() : base("SoulLink") { }

    public override void Use(Archetype caster, Archetype target)
    {
      int totalHP;

      totalHP = caster.HP + target.HP;
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;
    }
  }
}
