using System;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass artur = new DummyClass("Артур Пендрагон");
      Nekromaster dungeonMaster = new Nekromaster("Данжен Мастер");

      Console.WriteLine($"НАЧАЛО БИТВЫ\n" + $"ПЕРВЫЙ РАУНД\n" +
                        $"Исходное состояние: \n" +
                        $"==================\n" +
                        $"{dungeonMaster.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");


      Console.WriteLine($"{dungeonMaster.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      dungeonMaster.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = dungeonMaster.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      /////////////////////////////////////////

      Console.WriteLine($"\nВТОРОЙ РАУНД.");

      Console.WriteLine($"{artur.Name} атакует {dungeonMaster.Name}!");

      beforeHP = dungeonMaster.HP;
      artur.Hit(dungeonMaster);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      /////////////////////////////////////////////////////

      Console.WriteLine($"\nТРЕТИЙ РАУНД.");

      Console.WriteLine($"{dungeonMaster.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      dungeonMaster.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = dungeonMaster.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();



    }
  }
}