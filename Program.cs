using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Cleric lancelot = new Cleric("Чел");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ1. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"Тест перегрузки:\n" + $"ХП {lancelot.Name} уменьшено на 10\n");
      
      lancelot -= 10;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n" + $"ХП {lancelot.Name} увеличено на 100:\n");

      lancelot += 100;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n");

      Console.WriteLine("Проверка на живучесть:");

      if (lancelot){
        Console.WriteLine($"{lancelot.Name} жив\n");
      } else {
        Console.WriteLine($"{lancelot.Name} сдох. " + $"во лох\n");
      }

      Console.WriteLine("Нанесён смертельный урон\n");

      lancelot -= 1000;

      if (lancelot){
        Console.WriteLine($"{lancelot.Name} ещё живой\n");
      } else {
        Console.WriteLine($"{lancelot.Name} сдох. " + $"во лох\n");
      }

      Console.Write("Нажмите любую клавишу, чтобы продолжить.");
      Console.ReadKey();
    }
  }
}
