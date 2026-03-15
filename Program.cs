using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {

      string critText;
      int beforeHP, damage;
      
      RogueClass lancelot = new RogueClass("Ланселот Ловкий");
      RogueClass rapfael = new RogueClass("Рафаэль Могучий");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ\nИсходное состояние:\n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n");

      HealthPotion healthPotion = new HealthPotion(20);
      ManaPotion manaPotion = new ManaPotion(10);
      AmmoPack ammoPack = new AmmoPack(5);
      GoldApple goldApple = new GoldApple(10);
      
      rapfael += ammoPack;

      Console.WriteLine($"{rapfael.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      rapfael.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = rapfael.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (lancelot) { 
        Console.WriteLine($"{lancelot.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{lancelot.Name} пал смертью храбрых!\n");
                        
        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                          "======================\n" +
                          $"{lancelot.GetInfo()}\n" +
                          $"{rapfael.GetInfo()}\n" +
                          $"{lancelot.Name} выбывает!\n" +
                          $"Поздравляем {rapfael.Name} с победой!\n");

        return;
      }

      lancelot += healthPotion;
      lancelot += manaPotion;

      Console.WriteLine($"{lancelot.Name} атакует {rapfael.Name}!");
      beforeHP = rapfael.HP;
      lancelot.Hit(rapfael);
      damage = beforeHP - rapfael.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (rapfael) { 
        Console.WriteLine($"{rapfael.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{rapfael.Name} пал смертью храбрых!\n");

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n" +
                        $"{rapfael.Name} выбывает!\n\n" +
                        $"Поздравляем {lancelot.Name} с победой!\n");

        return;
      }

      rapfael += goldApple;
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n");

      Console.WriteLine("БОЙ ОКОНЧЕН НИЧЬЕЙ!");
    }
  }
}
