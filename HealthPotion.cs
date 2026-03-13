using System;

namespace BoringRPG
{
    public class HealthPotion : ConsumableItem
    {
        public HealthPotion(int value) : base("Health Potion", value)
        {
        }

        public override string GetDescription()
        {
            return $"Восстанавливает {Value} HP";
        }
        public static Archetype operator +(Archetype hero, HealthPotion potion)
        {
            hero.HP += potion.Value;

            if (hero is Cleric && hero.HP > 75)
            {
                hero.HP = 75;
            }
            else if (hero is DummyClass && hero.HP > 100)
            {
                hero.HP = 100;
            }

            Console.WriteLine($"{hero.Name} uses {potion.Name} and restores {potion.Value} HP!");
            return hero;
        }
    }
}