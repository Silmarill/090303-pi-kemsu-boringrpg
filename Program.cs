using System;

namespace BoringRPG
{
internal class Program
{
    static void Main(string[] args)
    {
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

        Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ РАСХОДНЫХ ПРЕДМЕТОВ ===\n");

        Paladin hero = new Paladin("Тестовый Паладин");
        Console.WriteLine("Начальное состояние:");
        Console.WriteLine(hero.GetInfo());

        hero += new HealthPotion(30);
        Console.WriteLine("\nПосле HealthPotion (+30 HP):");
        Console.WriteLine(hero.GetInfo());

        hero += new ManaPotion(20);
        Console.WriteLine("После ManaPotion (+20 MP):");
        Console.WriteLine(hero.GetInfo());

        hero += new AmmoPack(5);
        Console.WriteLine("После AmmoPack (+5 Ammo):");
        Console.WriteLine(hero.GetInfo());

        hero *= new CoffeeCup(10);
        Console.WriteLine("После CoffeeCup (*10 Damage):");
        Console.WriteLine(hero.GetInfo());

        Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ НАВЫКОВ ===\n");

        Paladin hero1 = new Paladin("Могучий Пал");
        DummyClass hero2 = new DummyClass("Тренировочный манекен");

        Console.WriteLine("До применения навыков:");
        Console.WriteLine(hero1.GetInfo());
        Console.WriteLine(hero2.GetInfo());
        Console.WriteLine();

        // SoulLink
        Skill soulLink = new SoulLink();
        Console.WriteLine($"--- Используем {soulLink.Name} ---");
        hero1.UseSkill(soulLink, hero2);
        Console.WriteLine(hero1.GetInfo());
        Console.WriteLine(hero2.GetInfo());
        Console.WriteLine();

        //  ManaDrain
        Skill manaDrain = new ManaDrain();
        Console.WriteLine($"--- Используем {manaDrain.Name} ---");
        hero1.UseSkill(manaDrain, hero2);
        Console.WriteLine(hero1.GetInfo());
        Console.WriteLine(hero2.GetInfo());
        Console.WriteLine();

        // DramaAction
        Skill drama = new DramaAction();
        Console.WriteLine($"--- Используем {drama.Name} ---");
        hero1.UseSkill(drama, hero2);
        Console.WriteLine(hero1.GetInfo());
        Console.WriteLine(hero2.GetInfo());
        Console.WriteLine();

        Console.ReadKey();
    }
}
}