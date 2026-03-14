using System;

namespace BoringRPG {
  public class Program {
    static void Main(string[] args)
    {
      Console.WriteLine("=== ДЕМОНСТРАЦИЯ РАСХОДУЕМЫХ ПРЕДМЕТОВ ===\n");

      Druid cedric = new Druid("Кедрик Зелёный");

      Console.WriteLine($"Начальное состояние Кедрика:");
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine();

      Console.WriteLine("1. Используем обычные предметы:");

      HealthPotion healthPotion = new HealthPotion(30);
      cedric += healthPotion;
      Console.WriteLine($"После HealthPotion(+30 HP): {cedric.GetInfo()}");

      ManaPotion manaPotion = new ManaPotion(20);
      cedric += manaPotion;
      Console.WriteLine($"После ManaPotion(+20 MP): {cedric.GetInfo()}");

      AmmoPack ammoPack = new AmmoPack(15);
      cedric += ammoPack;
      Console.WriteLine($"После AmmoPack(+15 Ammo): {cedric.GetInfo()}");

      Console.WriteLine("\n=== Демонстрация боя с предметами ===");
      Druid morgan = new Druid("Морган Лесная");

      Console.WriteLine($"Исходное состояние Морган:");
      Console.WriteLine(morgan.GetInfo());

      morgan += new HealthPotion(25);
      Console.WriteLine($"\nМорган выпила зелье здоровья (+25 HP):");
      Console.WriteLine(morgan.GetInfo());

      Console.WriteLine($"\n{morgan.Name} атакует {cedric.Name}!");
      int beforeHP = cedric.HP;
      morgan.Hit(cedric);
      int damage = beforeHP - cedric.HP;

      Console.WriteLine($"Нанесено {damage} урона");
      Console.WriteLine($"После атаки Кедрик: {cedric.GetInfo()}");

      cedric += new HealthPotion(20);
      Console.WriteLine($"\nКедрик использовал аптечку после боя:");
      Console.WriteLine(cedric.GetInfo());

      Console.ReadKey();
    }
  }
}