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

      Console.WriteLine($"Здоровье до лечения: {berserker.HP}");
      berserker += 20;
      Console.WriteLine($"Здоровье после лечения: {berserker.HP}");

      Console.WriteLine($"Берсеркер {(berserker ? "жив" : "мёртв")}");

      Console.WriteLine($"\nЗдоровье до получения урона: {berserker.HP}");
      berserker -= 30;
      Console.WriteLine($"Здоровье после получения урона: {berserker.HP}");

      Console.WriteLine("\n=== БОЕВОЕ ВЗАИМОДЕЙСТВИЕ ===");
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