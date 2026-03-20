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
            chance = random.Next(1, 101);

            if (chance == 30)
            {
                random.Next(0, 1);

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

            if (chance == 40)
            {
                Console.WriteLine($"{caster.Name} дарит розу {target.Name}");
            }


        }
    }
}
