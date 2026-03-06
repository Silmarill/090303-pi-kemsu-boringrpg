using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace BoringRPG {
    internal class Nekromaster : Archetype {
        private static Random random = new Random();
        private int _skeletonBonus;
        public bool LastHitWasCrit;

        _skeletonBonus = 0;
        public Nekromaster(string name, int hp, int mp, int ammo, int dmg, double crit) : base (name, 55, 90, 0, 30, 0.1) {
        
        }

        public Nekromaster(string name) : base(name,55, 90, 0, 30, 0.1){
        
        }
        public static Nekromaster operator +(Nekromaster necromancer, int amount)
        {
            necromancer.HP += amount;
            return necromancer;
        }
        public static Nekromaster operator -(Nekromaster necromancer, int amount)
        {
            necromancer.HP -= amount;
            return necromancer;
        }
        public override void Hit(Nekromaster target)
        {
            if (MP < 15)
            {
                LastHitWasCrit = false;
                return;
            }

            MP -= 15;

            int damage = Damage;

            LastHitWasCrit = random.NextDouble() < CritChance;
            if (LastHitWasCrit)
            {
                damage *= 2;
            }

            damage += _skeletonBonus;

            int targetHpBefore = target.HP;

            target -= damage;

            if (target.HP < targetHpBefore)
            {
                _skeletonBonus += 5;
            }
        }

        public override string GetInfo()
        {
            return $"{Name} (Некромант): HP {HP}/55, MP {MP}/90, Damage {Damage}, Crit {CritChance * 100}%, SkeletonBonus +{_skeletonBonus}";
        }
    }
}