using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class DramaAction : Skill
    {
        public override void Use(Archetype caster, Archetype target)
        {
            Random random = new Random();
            double chance;
            chance = random.Next(0, 11);
            //chance = 4;

            if (chance == 3)
            {
                chance = random.Next(0, 1);

                if (chance == 0)
                {
                    target.Name = target.Name + " Побеждённый";
                } else {
                    target.Name = target.Name + " Легендарный";
                }

                if (chance == 0)
                {
                    caster.Name = caster.Name + " Легендарный";
                }
                else
                {
                    caster.Name = caster.Name + " Побеждённый";
                }

            }

            if (chance == 4)
            {
                Console.WriteLine($"{caster.Name} дарит розу {target.Name}");
            }


        }
    }
}
