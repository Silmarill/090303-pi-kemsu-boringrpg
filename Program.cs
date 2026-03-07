using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      archerClass lancelot = new archerClass("Ланселот Ловкий");
      DummyClass artur = new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
      if (lancelot.IsAlive) { 
        Console.WriteLine($"{lancelot.Name} готов к бою");
      } else { 
        Console.WriteLine($"{lancelot.Name} не может сражаться");
      }

      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}");

      if (!artur.IsAlive) { 
        Console.WriteLine($"{artur.Name} поврежден\n");
      } else { 
        Console.WriteLine($"{artur.Name} все еще держится\n");
      }

      damage = beforeHP - artur.HP;
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
