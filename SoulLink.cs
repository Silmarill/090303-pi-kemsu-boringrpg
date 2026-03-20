using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class SoulLink : Skill{

    public SoulLink() : base("SoulLink") { }

    public override void Use(Archetype caster, Archetype target) { 

      int totalHP = caster.HP + target.HP;
      int halfHP = totalHP / 2;

      caster.HP = halfHP;
      target.HP = halfHP;

    }
  }
}
