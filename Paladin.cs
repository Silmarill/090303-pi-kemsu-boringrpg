using System;

namespace BoringRPG
{
    internal class Paladin : Archetype
    {
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public Paladin(string name) : base(name, 100, 40, 0, 20, 0.10)
        {
        }

        // Перегрузки для первого этапа (изменение HP через + и - int)
        public static Paladin operator +(Paladin p, int amount)
        {
            p.HP += amount;
            return p;
        }

        public static Paladin operator -(Paladin p, int amount)
        {
            p.HP -= amount;
            return p;
        }

        public static bool operator true(Paladin p) => p.HP > 0;
        public static bool operator false(Paladin p) => p.HP <= 0;

        // Перегрузки для второго этапа (применение предметов)
        public static Paladin operator +(Paladin p, HealthPotion potion)
        {
            p.HP += potion.Value;
            return p;
        }

        public static Paladin operator +(Paladin p, ManaPotion potion)
        {
            p.MP += potion.Value;
            return p;
        }

        public static Paladin operator +(Paladin p, AmmoPack ammo)
        {
            p.Ammo += ammo.Value;
            return p;
        }

        // Безумный предмет — использует оператор *
        public static Paladin operator *(Paladin p, CoffeeCup coffee)
        {
            p.Damage += coffee.Value;
            return p;
        }

        public override void Hit(Archetype target)
        {
            int baseDamage;
            if (MP >= 10)
            {
                MP -= 10;
                baseDamage = Damage + 5;
            }
            else
            {
                baseDamage = Damage;
            }

            LastHitWasCrit = random.NextDouble() < CritChance;
            if (LastHitWasCrit)
                baseDamage *= 2;

            dynamic dynTarget = target;
            _ = dynTarget - baseDamage;
        }

        public override string GetInfo()
        {
            return $"{Name} (Paladin): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Шанс крита {CritChance * 100}%";
        }
    }
}