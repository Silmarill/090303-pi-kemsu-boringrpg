using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      RogueClass rapfael = new RogueClass("Рафаэль Могучий");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n");
           
      Console.WriteLine($"{rapfael.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      rapfael.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = rapfael.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(rapfael.GetInfo());
      Console.ReadKey();
    }
  }
}
