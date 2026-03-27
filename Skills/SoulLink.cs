using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class SoulLink : Skill
    {
        public SoulLink() : base("Связь душ")
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