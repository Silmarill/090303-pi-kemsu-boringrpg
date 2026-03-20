using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class ManaDrain : Skill
    {
        public override void Use(Archetype caster, Archetype target)
        {
            Random random = new Random();
            int stolenMana = random.Next(0, 51);

            target.MP -= stolenMana;
            caster.MP += stolenMana;

        }
    }
}
