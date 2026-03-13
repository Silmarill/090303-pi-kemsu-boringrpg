using System;
using System.Runtime.ConstrainedExecution;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Hunter artur = new Hunter("Артур Пендрагон");
      Hunter cser = new Hunter("Красная линия");


      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{cser.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");


      Console.WriteLine($"{cser.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      cser.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = cser.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }

      // ==================================================================

      Console.WriteLine($"\nВторой РАУНД.");

      Console.WriteLine($"{artur.Name} атакует {cser.Name}!");

      beforeHP = cser.HP;
      artur.Hit(cser);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }

      // ===================================================================

      Console.WriteLine($"\nТретий раунд.");

      Console.WriteLine($"{cser.Name} атакует  {artur.Name}!");

      beforeHP = artur.HP;
      cser.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = cser.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }


    }
  }
}
