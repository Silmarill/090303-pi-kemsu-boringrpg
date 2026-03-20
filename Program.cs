using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      int round = 1;

      Druid druid = new Druid("Паша техник");
      Druid artur = new Druid("Артур Пендрагон");

      HealthPotion healthPotion = new HealthPotion(30);
      ManaPotion manaPotion = new ManaPotion(20);
      AmmoPack ammoPack = new AmmoPack(15);
      BugPotion bugPotion = new BugPotion(25);

      Console.WriteLine($"=== НАЧАЛО БИТВЫ ===\n" +
                        $"Исходное состояние: \n" +
                        $"==================\n" +
                        $"{druid.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"\n=== ПЕРСОНАЖИ НАШЛИ ЗАЧАРОВАНЫЕ ПРЕДМЕТЫ ===\n");

      // Use наших предметов
      Console.WriteLine($"\n=== ИСПОЛЬЗОВАНИЕ ПРЕДМЕТОВ: ===\n" +
                        $"Паша техник хилиться на 30 HP!\n" +
                        $"Артур Пендрагон восстанавливает + 20 MP\n" +
                        $"Оба участника боя восстанавливают броню + 15 ARM");
      
      druid += healthPotion;
      artur += manaPotion;
      druid += ammoPack;
      artur += ammoPack;

      Console.WriteLine($"\n" + druid.GetInfo() + "\n" + artur.GetInfo() + "\n" +
                        $"\n=== АРТУР НАШЕЛ БЕЗУМНЫЙ ПРЕДМЕТ: ===\n" +
                        $"Артур Педрагон сократил или восстановил свое HP на неизвестное значение!");
      artur += bugPotion;

      Console.WriteLine($"\n" + druid.GetInfo() + "\n" + artur.GetInfo() +
                        $"\nНажмите любую клавишу для начала битвы...");
      Console.ReadKey();
      Console.Clear();

      Console.Clear();
      Console.WriteLine("=== Демонстрация скилов ===");

      Skill soulLink = new SoulLink();
      Skill manaDrain = new ManaDrain();
      Skill dramaAction = new DramaAction();

      Console.WriteLine("\n=== Применяем - SoulLink ===");
      druid.Use (soulLink, artur);

      Console.WriteLine("\n=== Применяем - ManaDrain ===");
      artur.Use (manaDrain, druid);

      Console.WriteLine("\n=== Применяем - DramaAction ===");
      druid.Use (dramaAction, artur);

      Console.WriteLine($"\n=== СОСТОЯНИЕ ПОСЛЕ НАВЫКОВ ===\n" +
                        $"{druid.GetInfo()}\n + { artur.GetInfo()}\n");

      // Бой пока оба живы
      while (druid.HP > 0 | artur.HP > 0) {
        Console.WriteLine($"\n$=== РАУНД {round} ===$");

        // Друид атакует Артура
        Console.WriteLine($"{druid.Name} атакует {artur.Name}!");
        beforeHP = artur.HP;
        druid.Hit(artur);
        damage = beforeHP - artur.HP;
        critText = druid.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");

        // Проверка после атаки друида
        Console.WriteLine("$--- Проверка после атаки Паши Техника ---$");
        if (druid) {
          Console.WriteLine($"{druid.Name} жив");
        } else {
          Console.WriteLine($"{druid.Name} мёртв");
        }

        if (artur) {
          Console.WriteLine($"{artur.Name} жив");
        } else {
          Console.WriteLine($"{artur.Name} мёртв");
          break;
        }

        // Артур атакует друида
        Console.WriteLine($"\n{artur.Name} атакует {druid.Name}!");
        beforeHP = druid.HP;
        artur.Hit(druid);
        damage = beforeHP - druid.HP;
        critText = artur.LastHitWasCrit ? " - $КРИТИЧЕСКИЙ УДАР!$" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");

        // Проверка после атаки Артура
        Console.WriteLine("$--- Проверка после атаки Артура Пендрагона ---$");
        if (druid) {
          Console.WriteLine($"{druid.Name} жив");
        } else {
          Console.WriteLine($"{druid.Name} мёртв");
          break;
        }

        if (artur) {
          Console.WriteLine($"{artur.Name} жив");
        } else {
          Console.WriteLine($"{artur.Name} мёртв");
        }

        // Лечение после раунда (используем перегрузку +)
        Console.WriteLine($"\n$--- Лечение после раунда ---$\n" +
                          $"{druid.Name} до лечения: HP {druid.HP}");
        druid += 10;
        Console.WriteLine($"{druid.Name} после +10: HP {druid.HP}\n" +
                          $"{artur.Name} до лечения: HP {artur.HP}");
        artur += 10;
        Console.WriteLine($"{artur.Name} после +10: HP {artur.HP}");

        // Случайный предмет каждые 3 раунда
        if (round % 3 == 0) {
          Console.WriteLine("\n=== НАЙДЕН ПРЕДМЕТ! ===");
          Random rand = new Random();
          int itemType = rand.Next(0, 4);

          switch (itemType) {
            case 0:
              druid += healthPotion;
              break;
            case 1:
              artur += manaPotion;
              break;
            case 2:
              druid += ammoPack;
              break;
            case 3:
              artur += bugPotion;
              break;
          }
          Console.WriteLine($"\n" + druid.GetInfo() + "\n" + artur.GetInfo() + "\n");
        }

        ++round;

        Console.WriteLine("\nНажмите любую клавишу для следующего раунда...");
        Console.ReadKey();
      }

      Console.WriteLine($"\n$=== БИТВА ОКОНЧЕНА ===$\n" +
                        $"ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        $"======================\n" +
                        $"{druid.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      // использование перегрузки true и false
      if (druid) {
        if (artur) {
          Console.WriteLine($"\nОба выжили!");
        } else {
          Console.WriteLine($"\nПобедитель: {druid.Name}");
        }
      } else {
        if (artur) {
          Console.WriteLine($"\nПобедитель: {artur.Name}");
        } else {
          Console.WriteLine($"\nОба погибли!");
        }
      }

      Console.ReadKey();
    }
  }
}