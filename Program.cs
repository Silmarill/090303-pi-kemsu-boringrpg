using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      int healing = 15;
      
      RogueClass lancelot = new RogueClass("Ланселот Ловкий");
      RogueClass rapfael = new RogueClass("Рафаэль Могучий");
      RogueClass optimus = new RogueClass("Оптимус Непрайм");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n" +
                        $"{optimus.GetInfo()}\n");
           
      Console.WriteLine($"{rapfael.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      rapfael.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = rapfael.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"{lancelot.Name} использовал лечение!");
      lancelot.HP = lancelot.HP + healing;
      Console.WriteLine($"{lancelot.Name} вылечился на {healing} HP!\n");

      Console.WriteLine($"{optimus.Name} попал в смертельную ловушку!");
      optimus.HP -= optimus.HP;

      if (optimus) { 
        Console.WriteLine($"{optimus.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{optimus.Name} пал смертью храбрых!\n");
      }
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n" +
                        $"{optimus.GetInfo()}");
      Console.ReadKey();
    }
  }
}
