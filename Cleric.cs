using System;

namespace BoringRPG
{
    internal class Cleric : Archetype
    {
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public Cleric(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 75, 80, 0, 15, 0.05)
        {
            
        }

        public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05)
        {

        }

        public override void Hit(Archetype target)
        {
            int damage = Damage;
            LastHitWasCrit = random.NextDouble() < CritChance;

            if (LastHitWasCrit)
            {
                damage *= 2;
            }

            target.HP -= damage;
        }

        public override string GetInfo()
        {
            return $"{Name} (Cleric): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
        }

    }
}
