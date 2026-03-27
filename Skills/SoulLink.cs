using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  class SoulLink : Skill
  {
    public SoulLink()
    {
      Name = "SoulLink";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int generalHealth;
      int healthDivider;

      healthDivider = 2;

      generalHealth = caster.HP + target.HP;

      caster.HP = generalHealth / healthDivider;
      target.HP = generalHealth / healthDivider;
    }
  }
}
