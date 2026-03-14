using System;
using static BoringRPG.ConsumableItem;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Mage mage = new Mage("Маг");
      DummyClass artur = new DummyClass("Артур Пендрагон");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{mage.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.WriteLine($"{mage.Name} атакует !");

      beforeHP = artur.HP;
      mage.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = mage.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"{artur.Name} ранит {mage.Name}.");
      mage -= 5;
      Console.WriteLine($"Нанесено 5 урона\n");

      Console.WriteLine($"{mage.Name} восстанавливает здоровье.");
      mage += 10;
      Console.WriteLine($"Восстановлено 10 HP\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(mage.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine();

      if (mage) {
        Console.WriteLine($"{mage.Name} жив.\n");
      }
      else {
        Console.WriteLine($"{mage.Name} мертв.\n");
      }
      HealthPotion heartPotion = new HealthPotion(50);
      mage += heartPotion;
      ManaPotion manaPotion = new ManaPotion(20);
      mage += manaPotion;
      AmmoPack ammoPack = new AmmoPack(10);
      mage += ammoPack;

      Console.WriteLine(mage.GetInfo());

      CrazyArtifact artifact = new CrazyArtifact(50);
      mage -= artifact;

      Console.WriteLine(mage.GetInfo());

      Console.ReadKey();
    }
  }
}
