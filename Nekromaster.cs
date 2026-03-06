using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace BoringRPG {
    internal class Nekromaster : Archetype {
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public Nekromaster(string name, int hp, int mp, int ammo, int dmg, double crit) : base (name, 55, 90, 0, 30, 0.1) {
        
        }

        public Nekromaster(string name) : base(name,55, 90, 0, 30, 0.1){
        
        }
        public override void Hit(Archetype target)
        {
            int damage = 30;

            // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
            LastHitWasCrit = random.NextDouble() < 0.1;

            if (LastHitWasCrit)
            {
                damage *= 2;
            }

            target.HP -= damage;
        }

        public override string GetInfo()
        {
            return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
        }
    }
}