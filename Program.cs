using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      int healing = 20;
      
      RogueClass lancelot = new RogueClass("Ланселот Ловкий");
      RogueClass rapfael = new RogueClass("Рафаэль Могучий");
      RogueClass optimus = new RogueClass("Оптимус Непрайм");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. ПЕРВЫЙ РАУНД\nИсходное состояние:\n" +
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

      if (lancelot) { 
        Console.WriteLine($"{lancelot.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{lancelot.Name} пал смертью храбрых!\n");

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n" +
                        $"{lancelot.Name} выбывает!\n\n" +
                        $"Поздравляем {rapfael.Name} с победой!\n");

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
                          $"{optimus.GetInfo()}\n\n" +
                          $"{lancelot.Name} выбывает!\n" +
                          $"{optimus.Name} выбывает!\n\n" +
                          $"Поздравляем {rapfael.Name} с победой!\n");

        return;
      }

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
                        $"{optimus.GetInfo()}\n\n" +
                        $"{optimus.Name} выбывает!\n");

      Console.WriteLine("Нажмите любую клавишу, чтобы начать следующий раунд . . .");
      Console.ReadKey();

      Console.WriteLine($"\nВТОРОЙ РАУНД\nИсходное состояние:\n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n");
      
      Console.WriteLine($"Кто-то выкрал все патроны у {rapfael.Name}: -{rapfael.Ammo} патронов! " + 
                        "Осталось патронов: 0!");
      rapfael.Ammo = 0;

      Console.WriteLine($"{rapfael.Name} использовал щит здоровья! Потрачено маны: 15");
      rapfael.MP -= 15;
      rapfael.HP += rapfael.HP;
      Console.WriteLine($"Текущее здоровье {rapfael.Name}: {rapfael.HP}\n");

      Console.WriteLine($"{lancelot.Name} использует прием \"Левый коронный, правый похоронный\"!");
      beforeHP = rapfael.HP;
      lancelot.Hit(rapfael);
      lancelot.Hit(rapfael);
      damage = beforeHP - rapfael.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона от спецприема!{critText}\n");

      if (rapfael) { 
        Console.WriteLine($"{rapfael.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{rapfael.Name} пал смертью храбрых!\n");

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n" +
                        $"{rapfael.Name} выбывает!\n\n" +
                        $"Поздравляем {lancelot.Name} с победой!\n");

        return;
      }

      Console.WriteLine("Нажмите любую клавишу, чтобы начать следующий раунд . . .");
      Console.ReadKey();

      Console.WriteLine($"\nТРЕТИЙ РАУНД\nИсходное состояние:\n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n");

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
                        $"{lancelot.Name} выбывает!\n\n" +
                        $"Поздравляем {rapfael.Name} с победой!\n");

        return;
      }

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
                        $"{rapfael.GetInfo()}\n" +
                        $"{rapfael.Name} выбывает!\n\n" +
                        $"Поздравляем {lancelot.Name} с победой!\n");

        return;
      }

      Console.WriteLine("БОЙ ОКОНЧЕН НИЧЬЕЙ!");
    }
  }
}
