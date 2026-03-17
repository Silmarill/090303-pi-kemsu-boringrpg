using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      Console.WriteLine("=== СОЗДАНИЕ ГЕРОЕВ ===");
      Cleric cleric = new Cleric("Амброзий");
      DummyClass warrior = new DummyClass("Брунгильда");

      Console.WriteLine(cleric.GetInfo());
      Console.WriteLine(warrior.GetInfo());

      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ОБЫЧНЫХ ПРЕДМЕТОВ ===");

      HealthPotion healthPotion = new HealthPotion(30);
      Console.WriteLine($"\nНайден предмет: {healthPotion.Name} - {healthPotion.GetDescription()}");
      cleric = cleric + healthPotion;
      Console.WriteLine(cleric.GetInfo());

      ManaPotion manaPotion = new ManaPotion(25);
      Console.WriteLine($"\nНайден предмет: {manaPotion.Name} - {manaPotion.GetDescription()}");
      cleric = cleric + manaPotion;
      Console.WriteLine(cleric.GetInfo());

      StrengthPotion strengthPotion = new StrengthPotion(5);
      Console.WriteLine($"\nНайден предмет: {strengthPotion.Name} - {strengthPotion.GetDescription()}");
      warrior = warrior + strengthPotion;
      cleric = cleric + strengthPotion;
      Console.WriteLine(warrior.GetInfo());
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ БЕЗУМНОГО ПРЕДМЕТА (DIVINE TALISMAN) ===");

      DivineTalisman talisman = new DivineTalisman(10);
      Console.WriteLine($"\nНайден предмет: {talisman.Name} - {talisman.GetDescription()}");
      Console.WriteLine($"Божественная энергия: {talisman.DivineCharge}");

      Console.WriteLine("\n1. Благословение (+):");
      cleric = cleric + talisman;
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n2. Проклятие (-):");
      warrior = warrior - talisman;
      Console.WriteLine(warrior.GetInfo());

      Console.WriteLine("\n3. Божественное вмешательство (*):");
      Console.WriteLine("Пробуем первый раз:");
      cleric = cleric * talisman;
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\nПробуем второй раз (энергии уже нет):");
      cleric = cleric * talisman;
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ПЕРЕГРУЗКИ ОПЕРАТОРОВ TRUE/FALSE ===");
      
      if (cleric) {
        Console.WriteLine("Клерик жив и готов к приключениям!");
      } else {
        Console.WriteLine("Клерик мертв...");
      }

      Console.WriteLine("\n=== ИТОГОВОЕ СОСТОЯНИЕ ГЕРОЕВ ===");
      Console.WriteLine(cleric.GetInfo());
      Console.WriteLine(warrior.GetInfo());

      Console.ReadKey();
    }
  }
}