using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP,beforeAmmo, damage, hil, hilAmmo;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Hunter killian = new Hunter("Киллиан - древнее зло");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{killian.GetInfo()}\n");

      Console.WriteLine($"{killian.Name} использует зелье невидимости.\n");
      InvisibilityPotion newPotion = new InvisibilityPotion(1);
      killian += newPotion;

      Console.WriteLine($"Нынешнее состояние: \n" +
                         $"==================\n" +
                         $"{lancelot.GetInfo()}\n" +
                         $"{killian.GetInfo()}\n");

      Console.WriteLine($"{killian.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      killian.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = killian.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"{lancelot.Name} атакует {killian.Name}!");

      beforeHP = killian.HP;
      lancelot.Hit(killian);
      damage = beforeHP - killian.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}.\n");

      Console.WriteLine($"Нынешнее состояние: \n" +
                         $"==================\n" +
                         $"{lancelot.GetInfo()}\n" +
                         $"{killian.GetInfo()}\n");

      Console.WriteLine("Киллиан - древнее зло использует лечение.\n");
      HealthPotion hilpotion = new HealthPotion(5);
      beforeHP = killian.HP;
      killian += hilpotion; 
      hil = killian.HP - beforeHP;

      Console.WriteLine($"{killian.Name} лечится на {hil}.\n");

      Console.WriteLine("Киллиан - древнее зло использует пак снарядов.\n");
      AmmoPack ammoPack = new AmmoPack(5);
      beforeAmmo = killian.Ammo;
      killian += ammoPack;
      hilAmmo = killian.Ammo - beforeAmmo;

      Console.WriteLine($"{killian.Name} получает {hilAmmo} снарядов.\n");

      if (killian) {
        Console.WriteLine($"Итоговое состояние: \n" +
                          $"======================\n" +
                          $"{lancelot.GetInfo()}\n" +
                          $"{killian.GetInfo()}\n");
        Console.ReadKey();
      }

    }
  }
}
