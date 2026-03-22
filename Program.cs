using System;
using static BoringRPG.ConsumableItem;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Berserker berserker = new Berserker("Берсерк");
      DummyClass target = new DummyClass("Цель");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"{berserker.GetInfo()}\n" +
                        $"{target.GetInfo()}\n");

      Console.WriteLine($"{berserker.Name} атакует {target.Name}!");

      beforeHP = target.HP;
      berserker.Hit(target);
      damage = beforeHP - target.HP;

      critText = berserker.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"{target.Name} ранит {berserker.Name}.");
      berserker -= 15;
      Console.WriteLine($"Нанесено 15 урона");
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}\n");

      Console.WriteLine($"{berserker.Name} восстанавливает здоровье.");
      berserker += 20;
      Console.WriteLine($"Восстановлено 20 HP");
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ ПОСЛЕ БОЯ:");
      Console.WriteLine("======================");
      Console.WriteLine(berserker.GetInfo());
      Console.WriteLine(target.GetInfo());
      Console.WriteLine();

      if (berserker) {
        Console.WriteLine($"{berserker.Name} жив.\n");
      }
      else {
        Console.WriteLine($"{berserker.Name} мертв.\n");
      }

      Console.WriteLine("ИСПОЛЬЗОВАНИЕ РАСХОДНИКОВ:");

      HealthPotion healthPotion = new HealthPotion(50);
      berserker += healthPotion;
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}, Крит {berserker.CritChance * 100}%\n");

      ManaPotion manaPotion = new ManaPotion(30);
      berserker += manaPotion;
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}, Крит {berserker.CritChance * 100}%\n");

      AmmoPack ammoPack = new AmmoPack(15);
      berserker += ammoPack;
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}, Крит {berserker.CritChance * 100}%\n");

      CritPotion critPotion = new CritPotion(5);
      berserker += critPotion;
      Console.WriteLine($"{berserker.Name}: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}, Крит {berserker.CritChance * 100}%\n");

      Console.ReadKey();
    }
  }
}