using System;

namespace BoringRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string critText;
            int beforeHP, damage;

            Berserker berserker = new Berserker("Берсерк");
            DummyClass target = new DummyClass("Цель");

            Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                              $"==================\n" +
                              $"{berserker.GetInfo()}\n" +
                              $"{target.GetInfo()}\n");

            Console.WriteLine($"{berserker.Name} атакует {target.Name}!");

            beforeHP = target.HP;
            berserker.Hit(target);
            damage = beforeHP - target.HP;

            critText = berserker.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

            Console.WriteLine($"Нанесено {damage} урона{critText}\n");

            Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
            Console.WriteLine("======================");
            Console.WriteLine(berserker.GetInfo());
            Console.WriteLine(target.GetInfo());
            Console.ReadKey();
        }
    }
}