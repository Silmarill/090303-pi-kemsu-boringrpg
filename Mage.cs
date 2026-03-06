using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class Mage : Archetype
    {
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public Mage (string name, int hp, int mp, int ammo, int dmg, double crit)
            : base(name, hp, mp, ammo, dmg, crit)
        {
          
        }


        public override void Hit(Archetype target)
        {
            int damage = Damage;

            if (MP >= 10)
            {
                MP -= 10; 
                LastHitWasCrit = random.NextDouble() < CritChance;

                if (LastHitWasCrit)
                {
                    damage *= 2;
                }

                target.HP -= damage;
            }
      
        }
        public static Mage operator +(Mage mage, int value)
        {
            mage.HP += value;
            return mage;
        }

        public static Mage operator -(Mage mage, int value)
        {
            mage.HP -= value;
            return mage;
        }


        public override string GetInfo()
        {
            return $"{Name} (Mage): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
        }
    }
}
