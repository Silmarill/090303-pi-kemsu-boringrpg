using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      HunterClass amogus = new HunterClass("Амогус Гус");

      int healPackage;
      healPackage = 15;

      Console.WriteLine("\n----- ИСПОЛЬЗОВАНИЕ ПРЕДМЕТОВ -----");

      HealthPotion healthPotion = new HealthPotion(30);
      ManaPotion manaPotion = new ManaPotion(20);
      AmmoPack ammoPack = new AmmoPack(8);
      EnergyDrink energyDrink = new EnergyDrink(24);

      CharacterWithItems wrappedLancelot = new CharacterWithItems(lancelot);
      CharacterWithItems wrappedAmogus = new CharacterWithItems(amogus);

      Console.WriteLine($"\n{amogus.Name} находит зелье здоровья ({healthPotion.Value} ед.)!");
      wrappedAmogus = wrappedAmogus + healthPotion;

      Console.WriteLine($"\n{lancelot.Name} находит зелье маны ({manaPotion.Value} ед.)!");
      wrappedLancelot = wrappedLancelot + manaPotion;

      Console.WriteLine($"\n{amogus.Name} находит патроны ({ammoPack.Value} шт.)!");
      wrappedAmogus = wrappedAmogus + ammoPack;

      Console.WriteLine($"\n{amogus.Name} выпивает энергетик!");
      wrappedAmogus = wrappedAmogus + energyDrink;

      Console.WriteLine($"\n{amogus.Name} находит второй энергетик и смешивает их!");
      ++energyDrink;
      wrappedAmogus = wrappedAmogus + energyDrink;

      Console.WriteLine("\n----- СОСТОЯНИЕ ПОСЛЕ ПРЕДМЕТОВ -----");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(amogus.GetInfo());
      Console.WriteLine("\n----- ПРОДОЛЖЕНИЕ БИТВЫ -----");

      Console.WriteLine("Амогус находит аптечку и лечится!");
      amogus = amogus + healPackage;

      if (amogus ? false : true)
      {
        Console.WriteLine("О нет! Амогус слишком слаб для битвы!");
        return;
      }

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                                $"==================\n" +
                                $"{lancelot.GetInfo()}\n" +
                                $"{amogus.GetInfo()}\n");

      Console.WriteLine($"{amogus.Name} атакует {lancelot.Name}");

      beforeHP = lancelot.HP;
      amogus.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = amogus.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      int counterDamage;
      counterDamage = 10;

      if (lancelot.HP > 0)
      {
        Console.WriteLine($"{lancelot.Name} контратакует!");
        amogus = amogus - counterDamage;
      }

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(amogus.GetInfo());
      Console.ReadKey();
    }
  }
}