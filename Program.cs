using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args)
    {
      Console.WriteLine("=== ДЕМОНСТРАЦИЯ РАСХОДУЕМЫХ ПРЕДМЕТОВ ===\n");

      Druid cedric = new Druid("Кедрик Зелёный");

      Console.WriteLine("Начальное состояние:");
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine();

      Console.WriteLine("1. Использование обычных предметов:");
      Console.WriteLine("-------------------------------------");

      HealthPotion healthPotion = new HealthPotion(30);
      cedric += healthPotion;
      Console.WriteLine(cedric.GetInfo());

      ManaPotion manaPotion = new ManaPotion(20);
      cedric += manaPotion;
      Console.WriteLine(cedric.GetInfo());

      AmmoPack ammoPack = new AmmoPack(15);
      cedric += ammoPack;
      Console.WriteLine(cedric.GetInfo());

      Console.WriteLine();

      Console.WriteLine("2. Использование безумных предметов:");
      Console.WriteLine("-------------------------------------");

      DoubleEspresso espresso = new DoubleEspresso(10);

      if (cedric > espresso)
      {
      }
      Console.WriteLine(cedric.GetInfo());

      Console.WriteLine();

      Console.WriteLine("3. Пробуем двойной эспрессо с оператором >:");
      Console.WriteLine("-------------------------------------");

      DoubleEspresso coffee = new DoubleEspresso(20);

      if (cedric > coffee)
      {
      }
      Console.WriteLine(cedric.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}