using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Necromancer necro = new Necromancer("Дэвид Харрис");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
            
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
    }
  }
}
