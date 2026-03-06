using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG
{
    internal class HunterClass : Archetype {
        //пример для работы со случайными числами
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public HunterClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 85, 20, 15, 25, 0.2)
        {
        }

        public HunterClass(string name) : base(name, 85, 20, 15, 25, 0.2)
        {
        }

        public override void Hit(Archetype target)
        {
            int damage = Damage;

            // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
            LastHitWasCrit = random.NextDouble() < CritChance;

            if (LastHitWasCrit)
            {
                damage *= 2;
            }

            if (HP < target.HP)
            {
                damage += 10;
            }

            Ammo -= 1;
            target.HP -= damage;
        }

        public override string GetInfo()
        {
            return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
        }
    }
}
