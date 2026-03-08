using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage, heal = 10;

      DummyClass artur = new DummyClass("Артур Пендрагон");
      Mage skibidist = new Mage("Скибидист Вапапапич");

      Console.WriteLine($"НАЧАЛО БИТВЫ. " + $"ПЕРВЫЙ ХОД.\n"+
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
      if (skibidist) {
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();


      /////////////////////////////////////////

      Console.WriteLine($"\nВТОРОЙ ХОД.");

      Console.WriteLine($"{artur.Name} атакует {skibidist.Name}!");

      beforeHP = skibidist.HP;
      artur.Hit(skibidist);
      damage = beforeHP - skibidist.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      if (skibidist) {
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();


      //////////////////////////////////////////////////////

      Console.WriteLine($"\nТРЕТИЙ ХОД.");

      Console.WriteLine($"{skibidist.Name} пропускает ход и хилится!");

      beforeHP = skibidist.HP;
      skibidist += heal;
      Console.WriteLine($"ХП восстановленно до {skibidist.HP}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      if (skibidist) {
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();

      /////////////////////////////////////////

      Console.WriteLine($"\nЧЕТВЕРТЫЙ ХОД.");

      Console.WriteLine($"{artur.Name} атакует {skibidist.Name}!");

      beforeHP = skibidist.HP;
      artur.Hit(skibidist);
      damage = beforeHP - skibidist.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      if (skibidist) {
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();

      /////////////////////////////////////////
      ///
      Console.WriteLine($"\nПЯТЫЙ ХОД.");

      Console.WriteLine($"{skibidist.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      skibidist.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      if (skibidist) {
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();

      /////////////////////////////////////////

      Console.WriteLine($"\nШЕСТОЙ ХОД.");

      Console.WriteLine($"{artur.Name} атакует {skibidist.Name}!");

      beforeHP = skibidist.HP;
      artur.Hit(skibidist);
      damage = beforeHP - skibidist.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(skibidist.GetInfo());
      Console.WriteLine(artur.GetInfo());
      if (skibidist) {
        Console.WriteLine("БИТВА ОКОНЧЕНА, НИКТО НЕ ПОБЕДИЛ. НИЧЬЯ.");
      } else {
        Console.WriteLine($"{skibidist.Name} умирает");
        Console.WriteLine($"{artur.Name} ПОБЕЖДАЕТ!");
        return;
      }

      if (artur.HP >= 0) {
      } else {
        Console.WriteLine($"{artur.Name} умирает");
        Console.WriteLine($"{skibidist.Name} ПОБЕЖДАЕТ!");
        return;
      }

      Console.ReadKey();

      /////////////////////////////////////////
      ///


    }
  }
}
