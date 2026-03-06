using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
      Cleric danila = new Cleric("Данила Нестеров");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {danila.Name}!");

      beforeHP = danila.HP;
      lancelot.Hit(danila);
      damage = beforeHP - danila.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(danila.GetInfo());
      Console.ReadKey();
    }
  }
}
