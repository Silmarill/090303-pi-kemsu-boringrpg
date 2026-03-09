using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      int round = 1;
      
      Druid druid = new Druid("Паша техник");
      Druid artur = new Druid("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{druid.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
      
      // Бой пока оба живы
      while (druid.HP > 0 | artur.HP > 0) {
        Console.WriteLine($"\n$=== РАУНД {round} ===$");
        
        // Друид атакует Артура
        Console.WriteLine($"{druid.Name} атакует {artur.Name}!");
        beforeHP = artur.HP;
        druid.Hit(artur);
        damage = beforeHP - artur.HP;
        critText = druid.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");
        
        // Проверка после атаки друида
        Console.WriteLine("$--- Проверка после атаки Паши Техника ---$");
        if (druid) { 
          Console.WriteLine($"{druid.Name} жив");
        } else { 
          Console.WriteLine($"{druid.Name} мёртв");
        }

        if (artur) { 
          Console.WriteLine($"{artur.Name} жив");
        } else { 
          Console.WriteLine($"{artur.Name} мёртв");
          break;
        }
        
        // Артур атакует друида
        Console.WriteLine($"\n{artur.Name} атакует {druid.Name}!");
        beforeHP = druid.HP;
        artur.Hit(druid);
        damage = beforeHP - druid.HP;
        critText = artur.LastHitWasCrit ? " - $КРИТИЧЕСКИЙ УДАР!$" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");
        
        // Проверка после атаки Артура
        Console.WriteLine("$--- Проверка после атаки Артура Пендрагона ---$");
        if (druid) { 
          Console.WriteLine($"{druid.Name} жив");
        } else {
          Console.WriteLine($"{druid.Name} мёртв");
          break;
        }

        if (artur) {
          Console.WriteLine($"{artur.Name} жив");
        } else {
          Console.WriteLine($"{artur.Name} мёртв");
        }

        // Лечение после раунда (используем перегрузку +)
        Console.WriteLine("\n$--- Лечение после раунда ---$");
        Console.WriteLine($"{druid.Name} до лечения: HP {druid.HP}");
        druid += 10;
        Console.WriteLine($"{druid.Name} после +10: HP {druid.HP}");
        
        Console.WriteLine($"{artur.Name} до лечения: HP {artur.HP}");
        artur += 10;
        Console.WriteLine($"{artur.Name} после +10: HP {artur.HP}");
        
        ++round;
        
        Console.WriteLine("\nНажмите любую клавишу для следующего раунда...");
        Console.ReadKey();
      }
      
      Console.WriteLine($"\n$=== БИТВА ОКОНЧЕНА ===$");
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(druid.GetInfo());
      Console.WriteLine(artur.GetInfo());
      
      // использование перегрузки true и false
      if (druid) {
        if (artur) {
          Console.WriteLine($"\nОба выжили!");
        } else {
          Console.WriteLine($"\nПобедитель: {druid.Name}");
        }
      } else {
        if (artur) {
          Console.WriteLine($"\nПобедитель: {artur.Name}");
        } else {
          Console.WriteLine($"\nОба погибли!");
        }
      }

      Console.ReadKey();
    }
  }
}