using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
      BerserkerClass berserk = new BerserkerClass("Berserker");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"{berserk.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");
      Console.WriteLine($"{berserk.Name} атакует {lancelot.Name}");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;
      Console.WriteLine("======================");
      beforeHP = lancelot.HP;
      berserk.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";
      critText = lancelot.LastHitWasCrit ? " - критический удар!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(berserk.GetInfo());
      Console.ReadKey();
    }
  }
}
