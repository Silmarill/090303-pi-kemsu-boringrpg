using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Warrior lancelot = new Warrior("Ланселот Ловкий");
      Warrior artur = new Warrior("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.WriteLine($"\nЗдоровье {artur.Name} до лечения: {artur.HP}");
      artur = artur + 20;
      Console.WriteLine($"Здоровье {artur.Name} после лечения (+20): {artur.HP}");
      artur = artur - 10;
      Console.WriteLine($"Здоровье {artur.Name} после урона (-10): {artur.HP}");

      if (artur) {
        Console.WriteLine($"{artur.Name} жив (HP > 0)");
      }
      else {
        Console.WriteLine($"{artur.Name} умер (HP <= 0)");
      }
      Console.WriteLine();

      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
