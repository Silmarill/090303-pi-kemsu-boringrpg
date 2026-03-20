using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class SoulLink : Skill {

        public override void Use(Archetype caster, Archetype target) {
            int totalHP;
            totalHP = caster.HP + target.HP;
            caster.HP = totalHP / 2;
            target.HP = totalHP / 2;
        }
    }
}
