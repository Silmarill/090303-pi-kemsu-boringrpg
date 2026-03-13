using System;

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

      Console.WriteLine();
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(mage.GetInfo());
      Console.WriteLine(artur.GetInfo());
      
      if (mage)
      {
        Console.WriteLine($"{mage.Name} жив.");
      }
      else
      {
        Console.WriteLine($"{mage.Name} мертв.");
      }
                
      Console.ReadKey();
    }
  }
}
