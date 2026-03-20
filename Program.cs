using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Archer artur = new Archer("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      HealthPotion healing = new HealthPotion(52);
      ManaPoint manaPoint = new ManaPoint(67);
      AmmoPack ammoPack = new AmmoPack(42);
      LitEnergy litEnergy = new LitEnergy(500);

			Console.Clear();
			Console.WriteLine("=== скиллы ===");

			Skill soulLink = new SoulLink();
			Skill manaDrain = new ManaDrain();
			Skill dramaAction = new DramaAction();

			Console.WriteLine("\n=== Используем SoulLink ===");
			lancelot.Use(soulLink, artur);

			Console.WriteLine("\n=== Использует ManaDrain ===");
			artur.Use(manaDrain, lancelot);

			Console.WriteLine("\n=== Применяем - DramaAction ===");
			lancelot.Use(dramaAction, artur);

			Console.WriteLine($"\n=== СОСТОЯНИЕ ПОСЛЕ НАВЫКОВ ===\n" +
												$"{lancelot.GetInfo()}\n{artur.GetInfo()}\n");

			if (lancelot.IsAlive) { 
        Console.WriteLine($"{lancelot.Name} готов к бою");
      } else { 
        Console.WriteLine($"{lancelot.Name} не может сражаться");
      }

      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      artur += healing;
      artur += ammoPack;
      artur += manaPoint;
      artur += litEnergy;

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (!artur.IsAlive) { 
        Console.WriteLine($"{artur.Name} разлетелся на атомы\n");
      } else { 
        Console.WriteLine($"{artur.Name} ЧТО?! он все еще стоит??? \n");
      }

      
            
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
