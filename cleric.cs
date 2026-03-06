using System;

namespace BoringRPG
{
    internal class Cleric : Archetype
    {


        private static Random random = new Random();
        public bool LastHitWasCrit;

        public Cleric(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 75, 80, 0, 15, 0.05)
        {
            // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
        }

        public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05)
        {
        }

        public override void Hit(Archetype target)
        {
            int damage = Damage;
            /*int mp = MP;
            int hp = HP;*/

            if (MP < 10)
            {
                return;
            }

            LastHitWasCrit = random.NextDouble() < CritChance;

            if (LastHitWasCrit)
            {
                damage *= 2;
            }

            MP -= 10;
            target.HP -= damage;

            if (target.HP == 0)
            {
                HP += 10;
            }

        }

        public override string GetInfo()
        {
            return $"{Name} (Хилятор3000): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}, Удары стоят 10 MP - при убийстве цели восстанавливает 10 HP%";
        }
    }
}
