using System;
using System.Runtime.ConstrainedExecution;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      DummyClass artur = new DummyClass("Артур Пендрагон");
      Hunter cser = new Hunter("Красная линия");

      if (artur)
      {
        Console.WriteLine($"{artur.Name} пока не умер!");
      }
      else
      {
        Console.WriteLine($"{artur.Name} живчик");
      }

      if (cser)
      {
        Console.WriteLine($"{cser.Name} живее всех живых!");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }


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

    }
  }
}
