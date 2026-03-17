using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      int beforeMP, beforeDamage;

      DummyClass lancelot = new DummyClass("Рагнар Простой");
      Druid merlin = new Druid("Мерлин Друид");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
      $"======================\n" +
      $"{lancelot.GetInfo()}\n" +
      $"{merlin.GetInfo()}\n");

      Console.WriteLine($"\n=== ДЕМОНСТРАЦИЯ ПРЕДМЕТОВ ДЛЯ ДРУИДА ===\n");

      Console.WriteLine($"{merlin.Name} использует зелье здоровья.");
      HealthPotion healthPotion = new HealthPotion(15);
      beforeHP = merlin.HP;
      merlin += healthPotion;
      Console.WriteLine($"{merlin.Name} восстановил {merlin.HP - beforeHP} HP\n");

      Console.WriteLine($"{merlin.Name} использует зелье маны.");
      ManaPotion manaPotion = new ManaPotion(20);
      beforeMP = merlin.MP;
      merlin += manaPotion;
      Console.WriteLine($"{merlin.Name} восстановил {merlin.MP - beforeMP} MP\n");

      Console.WriteLine($"{merlin.Name} использует зелье природы.");
      NaturePotion naturePotion = new NaturePotion(5);
      beforeDamage = merlin.Damage;
      merlin += naturePotion;
      Console.WriteLine($"{merlin.Name} увеличил урон на {merlin.Damage + 5 - beforeDamage}\n");

      Console.WriteLine($"{merlin.Name} съедает лунную ягоду.");
      MoonBerry berry = new MoonBerry(15); 
      merlin += berry;
      Console.WriteLine();

      Console.WriteLine($"Состояние после использования всех предметов:");
      Console.WriteLine(merlin.GetInfo());
      Console.WriteLine();

      Console.WriteLine($"=== БИТВА ===\n");
      Console.WriteLine($"{merlin.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      merlin.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = merlin.LastHitWasCrit ? " – КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"=== ДЕМОНСТРАЦИЯ БЕЗУМНОГО ОПЕРАТОРА * ===\n");
      Console.WriteLine($"{merlin.Name} находит ещё две лунные ягоды и съедает их!");

      MoonBerry secondBerry = new MoonBerry(0);
      merlin *= secondBerry; 
      Console.WriteLine(merlin.GetInfo());
      Console.WriteLine();

      Console.WriteLine($"{merlin.Name} снова атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      merlin.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = merlin.LastHitWasCrit ? " – КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("==========================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(merlin.GetInfo());

      Console.ReadKey();
    }
  }
}