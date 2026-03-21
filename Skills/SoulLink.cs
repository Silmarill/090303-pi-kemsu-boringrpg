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

      Console.WriteLine($"{caster.Name} using {Name} in {target.Name}!\n");

      generalHealth = caster.HP + target.HP;

      caster.HP = generalHealth / healthDivider;
      target.HP = generalHealth / healthDivider;

      Console.WriteLine($"health {caster.Name} = {caster.HP},health {target.Name} = {caster.HP}!\n");
    }
  }
}
