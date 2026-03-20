using System;

namespace BoringRPG
{
    internal class DramaAction : Skill
    {
        private static Random random = new Random();

        public DramaAction()
        {
            Name = "Drama Action";
        }

        public override void Use(Archetype caster, Archetype target)
        {
            double chance = random.NextDouble(); 

            if (chance < 0.3) 
            {
                target.Name = "Побеждённый " + target.Name;
                Console.WriteLine($"{caster.Name} переименовывает {target.Name} в 'Побеждённый'!");
            }
            else if (chance < 0.6) 
            {
                caster.Name = "Легендарный " + caster.Name;
                Console.WriteLine($"{caster.Name} становится 'Легендарным'!");
            }
            else 
            {
                Console.WriteLine($"{caster.Name} дарит розу {target.Name} 💐");
            }
        }
    }
}