using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Necromancer necro = new Necromancer("Дэвид Харрис");
      DummyClass artur =  new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{necro.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{necro.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      necro.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = necro.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (necro) {  
        Console.WriteLine($"{necro.Name} жив и может быть исцелен!");
        necro += 10;  
        Console.WriteLine($"После исцеления: {necro.GetInfo()}");
    }
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ПРЕДМЕТОВ-РАСХОДНИКОВ ===");
            
      HealthPotion hpPotion = new HealthPotion(30);
      ManaPotion mpPotion = new ManaPotion(25);
      BugPotion bugPotion = new BugPotion(20);
  
      Console.WriteLine($"\nТекущее состояние некроманта:");
      Console.WriteLine(necro.GetInfo());
            
      // Используем HealthPotion
      Console.WriteLine($"\nИспользуем HealthPotion +{hpPotion.Value}:");
      necro += hpPotion;
      Console.WriteLine(necro.GetInfo());
            
      // Используем ManaPotion
      Console.WriteLine($"\nИспользуем ManaPotion +{mpPotion.Value}:");
      necro += mpPotion;
      Console.WriteLine(necro.GetInfo());

      // Используем BugPotion (безумный предмет)
      Console.WriteLine($"\nИспользуем BugPotion (безумный предмет!):");
      necro %= bugPotion;
      Console.WriteLine(necro.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}
