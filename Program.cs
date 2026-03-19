using System;

namespace BoringRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация боя (из первого этапа)
            Paladin lancelot = new Paladin("Ланселот Ловкий");
            DummyClass artur = new DummyClass("Артур Пендрагон");

            Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                              $"==================\n" +
                              $"{lancelot.GetInfo()}\n" +
                              $"{artur.GetInfo()}\n");

            Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

            int beforeHP = artur.HP;
            lancelot.Hit(artur);
            int damage = beforeHP - artur.HP;

            string critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

            Console.WriteLine($"Нанесено {damage} урона{critText}\n");

            Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ ПОСЛЕ БОЯ:");
            Console.WriteLine("==============================");
            Console.WriteLine(lancelot.GetInfo());
            Console.WriteLine(artur.GetInfo());

            // Демонстрация работы расходных предметов (второй этап)
            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ РАСХОДНЫХ ПРЕДМЕТОВ ===\n");

            Paladin hero = new Paladin("Тестовый Паладин");
            Console.WriteLine("Начальное состояние:");
            Console.WriteLine(hero.GetInfo());

            // Применяем обычные предметы через оператор +
            hero += new HealthPotion(30);
            Console.WriteLine("\nПосле HealthPotion (+30 HP):");
            Console.WriteLine(hero.GetInfo());

            hero += new ManaPotion(20);
            Console.WriteLine("После ManaPotion (+20 MP):");
            Console.WriteLine(hero.GetInfo());

            hero += new AmmoPack(5);
            Console.WriteLine("После AmmoPack (+5 Ammo):");
            Console.WriteLine(hero.GetInfo());

            // Применяем безумный предмет через оператор *
            hero *= new CoffeeCup(10);
            Console.WriteLine("После CoffeeCup (*10 Damage):");
            Console.WriteLine(hero.GetInfo());

            Console.ReadKey();
        }
    }
}