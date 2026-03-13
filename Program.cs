using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Berserker berserker = new Berserker("Берсерк");
      DummyClass target = new DummyClass("Цель");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{berserker.GetInfo()}\n" +
                        $"{target.GetInfo()}\n");

      Console.WriteLine($"HP до операций: {berserker.HP}");
      berserker = berserker + 20;
      Console.WriteLine($"После berserker + 20: {berserker.HP}");
      berserker = berserker - 15;
      Console.WriteLine($"После berserker - 15: {berserker.HP}\n");

      if (berserker) {
        Console.WriteLine($"Берсерк жив! (HP: {berserker.HP} > 0)");
      }
      else {
        Console.WriteLine($"Берсерк мертв! (HP: {berserker.HP} <= 0)");
      }

      Console.WriteLine("\nУменьшаем HP до 0...");
      berserker = berserker - berserker.HP;
      Console.WriteLine($"HP после уменьшения: {berserker.HP}");

      if (berserker) {
        Console.WriteLine($"Берсерк жив! (HP: {berserker.HP} > 0)");
      }
      else {
        Console.WriteLine($"Берсерк мертв! (HP: {berserker.HP} <= 0)");
      }

      Console.WriteLine("\nВосстанавливаем HP для битвы...");
      berserker = berserker + 140;
      Console.WriteLine($"HP после восстановления: {berserker.HP}\n");

      Console.WriteLine($"До расходников: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}\n");

      HealthPotion healthPotion = new HealthPotion(50);
      Console.WriteLine($"Используем: {healthPotion.GetDescription()}");
      berserker += healthPotion;

      ManaPotion manaPotion = new ManaPotion(30);
      Console.WriteLine($"\nИспользуем: {manaPotion.GetDescription()}");
      berserker += manaPotion;

      AmmoPack ammoPack = new AmmoPack(15);
      Console.WriteLine($"\nИспользуем: {ammoPack.GetDescription()}");
      berserker += ammoPack;

      Console.WriteLine($"\nПосле расходников: HP {berserker.HP}, MP {berserker.MP}, Ammo {berserker.Ammo}\n");

      BugPotion bugPotion = new BugPotion();
      Console.WriteLine($"Используем: {bugPotion.GetDescription()}");
      Console.WriteLine($"До бага: HP {berserker.HP}, Урон {berserker.Damage}, Крит {berserker.CritChance * 100}%");

      berserker++;

      Console.WriteLine($"\nПосле бага: HP {berserker.HP}, Урон {berserker.Damage}, Крит {berserker.CritChance * 100}%");

      Console.WriteLine($"{berserker.Name} атакует {target.Name}!");

      beforeHP = target.HP;
      berserker.Hit(target);
      damage = beforeHP - target.HP;

      critText = berserker.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(berserker.GetInfo());
      Console.WriteLine(target.GetInfo());
      Console.ReadKey();
    }
  }
}