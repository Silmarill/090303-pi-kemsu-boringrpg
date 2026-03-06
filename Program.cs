using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Druid name = new Druid("Ацилот");
      Druid artur = new Druid("Артур Пендрагон");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{name.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.WriteLine($"{name.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      name.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = name.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (name) {
        Console.WriteLine($"{name.Name} жив\n");
      } else {
        Console.WriteLine($"{name.Name} мёртв\n");
      }

      if (artur) {
        Console.WriteLine($"{artur.Name} жив\n");
      } else {
        Console.WriteLine($"{artur.Name} мёрт\n");
      }

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(name.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}