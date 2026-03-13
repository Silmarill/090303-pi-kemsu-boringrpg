using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Cleric lancelot = new Cleric("Ланселот Ловкий");
      DummyClass artur = new DummyClass("Артур Пендрагон");
      
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
      
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ ПОСЛЕ АТАКИ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      
      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ПЕРЕГРУЗКИ ОПЕРАТОРОВ + И - ===");
      
      Console.WriteLine($"\nТекущее HP Клерика: {lancelot.HP}/75");
      
      Console.WriteLine("\nПрименяем оператор + (лечение): lancelot = lancelot + 20");
      lancelot = lancelot + 20;
      Console.WriteLine($"HP после лечения: {lancelot.HP}/75");
      
      Console.WriteLine("\nПрименяем оператор - (получение урона): lancelot = lancelot - 30");
      lancelot = lancelot - 30;
      Console.WriteLine($"HP после получения урона: {lancelot.HP}/75");
      
      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ПЕРЕГРУЗКИ ОПЕРАТОРОВ TRUE/FALSE ===");
      
      Console.WriteLine($"\nТекущее HP Клерика: {lancelot.HP}/75");
      
      if (lancelot) {
        Console.WriteLine("Клерик жив (HP > 0) - оператор true вернул true");
      } else {
        Console.WriteLine("Клерик мертв (HP <= 0) - оператор true вернул false");
      }
      
      Console.WriteLine("\nНаносим критический урон, чтобы убить Клерика:");
      Console.WriteLine("lancelot = lancelot - 100");
      lancelot = lancelot - 100;
      Console.WriteLine($"HP после получения урона: {lancelot.HP}/75");
      
      if (lancelot) {
        Console.WriteLine("Клерик жив (HP > 0)");
      } else {
        Console.WriteLine("Клерик мертв (HP <= 0) - оператор true вернул false");
      }
      Console.ReadKey();
    }
  }
}