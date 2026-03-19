using System;

namespace BoringRPG
{
    internal class DummyClass : Archetype
    {
        private static Random random = new Random();
        public bool LastHitWasCrit;

        public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3)
        {
        }

        public override void Hit(Archetype target)
        {
            int damage = Damage;
            LastHitWasCrit = random.NextDouble() < CritChance;
            if (LastHitWasCrit)
                damage *= 2;

            target.HP -= damage;
        }

        public override string GetInfo()
        {
            return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Шанс крита {CritChance * 100}%";
        }

        // Перегрузки для первого этапа
        public static DummyClass operator +(DummyClass d, int amount)
        {
            d.HP += amount;
            return d;
        }

        public static DummyClass operator -(DummyClass d, int amount)
        {
            d.HP -= amount;
            return d;
        }

        public static bool operator true(DummyClass d) => d.HP > 0;
        public static bool operator false(DummyClass d) => d.HP <= 0;

        // Перегрузки для второго этапа
        public static DummyClass operator +(DummyClass d, HealthPotion potion)
        {
            d.HP += potion.Value;
            return d;
        }

        public static DummyClass operator +(DummyClass d, ManaPotion potion)
        {
            d.MP += potion.Value;
            return d;
        }

        public static DummyClass operator +(DummyClass d, AmmoPack ammo)
        {
            d.Ammo += ammo.Value;
            return d;
        }

        // Безумный предмет
        public static DummyClass operator *(DummyClass d, CoffeeCup coffee)
        {
            d.Damage += coffee.Value;
            return d;
        }
    }
}