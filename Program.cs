using System;
namespace BoringRPG {

  internal class Program {

    static void Main(string[] args) {
      string critText;
      int beforeHPArtur, beforeHPLancelot, damageL, damageT;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      DummyClass artur = new DummyClass("Артур Пендрагон");
      Rogue torfin = new Rogue("Торфин Безопасный");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"{torfin.GetInfo()}\n");

      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");
      Console.WriteLine($"{lancelot.Name} атакует {torfin.Name}!");


      beforeHPArtur = artur.HP;
      beforeHPLancelot = lancelot.HP;
      torfin += 4;

      lancelot.Hit(torfin);
      lancelot.Hit(artur);
      torfin.Hit(lancelot);

      damageL = beforeHPArtur - artur.HP;
      damageT = beforeHPLancelot - lancelot.HP;

      Console.WriteLine($"\n{torfin.Name} хилится на 4 хп");

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"\nНанесено {damageT} урона");
      Console.WriteLine($"\nНанесено {damageL} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine(torfin.GetInfo());
      Console.ReadKey();
    }
  }
}
