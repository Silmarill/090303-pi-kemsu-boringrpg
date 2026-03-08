using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      //DummyClass skibidist = new DummyClass("Ланселот Ловкий");
      DummyClass artur = new DummyClass("Артур Пендрагон");
      Mage skibidist = new Mage("Скибидист Вапапапич");

      Console.WriteLine($"НАЧАЛО БИТВЫ." + $"ПЕРВЫЙ РАУНД \n"+
                        $" Исходное состояние: \n" +
                        $"==================\n" +
                        $"{skibidist.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");


      Console.WriteLine($"{skibidist.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      skibidist.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = skibidist.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());

      /////////////////////////////////////////
      ///
      Console.WriteLine($"ВТОРОЙ РАУНД. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{skibidist.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");


      Console.WriteLine($"{artur.Name} атакует {skibidist.Name}!");

      beforeHP = skibidist.HP;
      artur.Hit(skibidist);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
