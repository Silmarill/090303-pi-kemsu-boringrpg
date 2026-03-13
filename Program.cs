using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      Berserker berserker = new Berserker("Конан-варвар");
      DummyClass dummy = new DummyClass("Тренировочный манекен");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{berserker.GetInfo()}\n" +
                        $"{dummy.GetInfo()}\n");

      Console.WriteLine($"{berserker.Name} атакует {dummy.Name}!");

      beforeHP = dummy.HP;
      berserker.Hit(dummy);
      damage = beforeHP - dummy.HP;

      critText = berserker.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"Текущее здоровье берсеркера: {berserker.HP}/140");
      Console.WriteLine($"Бонус от ярости при следующей атаке: {(140 - berserker.HP) / 2}");

      Console.WriteLine("\nИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(berserker.GetInfo());
      Console.WriteLine(dummy.GetInfo());

      Console.ReadKey();
    }
  }
}